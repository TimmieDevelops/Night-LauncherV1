using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Night_Launcher.Pages;
using Night_Launcher.Tabs;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Appearance;

namespace Night_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string WebUrl = "http://127.0.0.1:5595";
        private string FilePath = "Builds.json";

        public MainWindow()
        {
            InitializeComponent();
            ApplyBackground();
            ApplyLauncherFrame();
            CheckVersion();
        }

        private void ApplyBackground()
        {
            Accent.ApplySystemAccent();
            Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Mica);
        }

        private void ApplyLauncherFrame()
        {
            MainFrame.Navigate(new Login());
        }
        
        private async void CheckVersion()
        {
            try
            {
                string version = await GetVersionAsync();
                if (version == "1.0.0")
                {
                    MainFrame.Navigate(new Login());
                }
                else
                {
                    SnackBarMessage.Show("A new version is available", "Please update the application", Wpf.Ui.Common.SymbolRegular.Warning28, Wpf.Ui.Common.ControlAppearance.Danger);
                }
            } catch
            {
                await Task.Delay(2000);
                SnackBarMessage.Show("Version Check Error:", $"Could not check the version. Please try again later.", Wpf.Ui.Common.SymbolRegular.Warning28, Wpf.Ui.Common.ControlAppearance.Danger);
            }
        }

        private async Task<string> GetVersionAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage Response = await client.GetAsync($"{WebUrl}/Night/routes/launcher/version");
                Response.EnsureSuccessStatusCode();
                string ResponseBody = await Response.Content.ReadAsStringAsync();
                JObject VersionInfo = JObject.Parse(ResponseBody);
                return VersionInfo["version"].ToString();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}