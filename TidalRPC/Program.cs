using System.Diagnostics;
using System.Timers;
using DiscordRPC;
using System.Windows.Forms;
using System.Reflection;
using TidalRPC.Tidal;
using TidalRPC.Tidal.Models;
using System.Runtime.InteropServices;

namespace TidalRPC
{
    internal static class Program
    {
        private static Process p;
        private static string songName = "";
        private static string songAuthor = "";
        private static DiscordRpcClient rpcClient = new("923066535449354240");
        private static string tidalToken;

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool FreeConsole();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Fetch console
            AllocConsole();
            Console.WriteLine("Please enter your Tidal API token: ");
            tidalToken = Console.ReadLine();
            FreeConsole();

            // Setup tray icon
            ApplicationConfiguration.Initialize();
            ContextMenuStrip cms = new();
            System.ComponentModel.Container components = new();
            NotifyIcon trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.TidalIcon,
                ContextMenuStrip = cms,
                Text = "Tidal RPC",
                Visible = true
            };
            cms.Items.Add("Exit", null, delegate
            {
                Application.Exit();
                trayIcon.Visible = false;
            });

            // Fetch Tidal process
            Process? process = GetProcess();
            if (process == null)
            {
                MessageBox.Show("Failed to find process. Please open Tidal.", "Error");
                trayIcon.Visible = false;
                Application.Exit();
                return;
            }
            else
            {
                p = process;
            }

            // Start timer to get window title every second
            if (rpcClient.Initialize())
            {
                System.Timers.Timer t = new();
                t.AutoReset = true;
                t.Interval = 1000;
                t.Elapsed += UpdateInfo;
                t.Start();
            }
            else
            {
                MessageBox.Show("Failed to start Discord RPC", "Error");
                trayIcon.Visible = false;
                Application.Exit();
            }

            // Start the application
            Application.Run();
        }

        private static void UpdateInfo(object? sender, ElapsedEventArgs e)
        {
            // Get updated process info
            p.Refresh();

            // No song is playing
            if (p.MainWindowTitle == "TIDAL")
            {
                songName = songAuthor = "";
                rpcClient.SetPresence(new()
                {
                    Details = "Paused",
                    Assets = new Assets
                    {
                        LargeImageKey = "tidalrpc"
                    }
                });
                return;
            }

            if (p.MainWindowTitle.LastIndexOf("-") < 0) return;
            string name = p.MainWindowTitle.Substring(0, p.MainWindowTitle.LastIndexOf("-")).Trim();
            string author = p.MainWindowTitle.Substring(p.MainWindowTitle.LastIndexOf("-") + 1).Trim();
            if (name != songName || songAuthor != author)
            {
                // Create the presence object
                RichPresence presence = new()
                {
                    Details = name,
                    State = author,
                    Timestamps = new Timestamps
                    {
                        Start = DateTime.UtcNow
                    },
                    Assets = new Assets
                    {
                        LargeImageKey = "tidalrpc"
                    }
                };
                
                // Get URL of song and create listen button
                SearchResponse? search = Api.Search(tidalToken, new()
                {
                    Query = p.MainWindowTitle
                });
                if (search?.Tracks.Items.Length > 0)
                {
                    presence.Buttons = new DiscordRPC.Button[]
                    {
                        new DiscordRPC.Button
                        {
                            Label = "Listen",
                            Url = search.Tracks.Items[0].Url
                        }
                    };
                }
                rpcClient.SetPresence(presence);
            }
            songName = name;
            songAuthor = author;
        }

        private static Process? GetProcess()
        {
            Process[] processes = Process.GetProcessesByName("TIDAL");
            foreach (Process p in processes)
            {
                if (!string.IsNullOrEmpty(p.MainWindowTitle)) return p;
            }
            return null;
        }
    }
}