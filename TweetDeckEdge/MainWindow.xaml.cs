using System;
using System.Windows;

namespace TweetDeckEdge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadConfig();
            webView.Source = new Uri(Properties.Settings.Default.WebViewSource);
        }

        private void webView_CoreWebView2Ready(object sender, EventArgs e)
        {
            webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;

            webView.CoreWebView2.NewWindowRequested += (sender, e) =>
            {
                var openPath = new Uri(e.Uri);

                if ("http" == openPath.Scheme || "https" == openPath.Scheme)
                {
                    var proc = new System.Diagnostics.Process();

                    proc.StartInfo.FileName = e.Uri;
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                }

                e.GetDeferral();
                e.Handled = true;
            };
        }

        private void LoadConfig()
        {
            // 設定値の取得
            Application.Current.MainWindow.Height = Properties.Settings.Default.WindowsPositionHeight;
            Application.Current.MainWindow.Width = Properties.Settings.Default.WindowsPositionWidth;
            Application.Current.MainWindow.Top = Properties.Settings.Default.WindowsPositionTop;
            Application.Current.MainWindow.Left = Properties.Settings.Default.WindowsPositionLeft;
        }

        private void SaveConfig()
        {
            Properties.Settings.Default.WindowsPositionHeight = Application.Current.MainWindow.Height;
            Properties.Settings.Default.WindowsPositionWidth = Application.Current.MainWindow.Width;
            Properties.Settings.Default.WindowsPositionTop = Application.Current.MainWindow.Top;
            Properties.Settings.Default.WindowsPositionLeft = Application.Current.MainWindow.Left;
            Properties.Settings.Default.Save();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveConfig();
        }
    }
}
