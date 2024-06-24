using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Night_Launcher.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private string WebUrl = "http://127.0.0.1:5595";
        private string CosmeticsUrl = "https://fortnite-api.com/v2/cosmetics/br/";


        public Login()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            string Email = EmailBox.Text;
            string Password = PasswordBox.Password;
            var MainWindow = Window.GetWindow(this) as MainWindow;
            var SnackBarMessage = MainWindow.SnackBarMessage;
            var MainFrame = MainWindow.MainFrame;

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                SnackBarMessage.Show("Login Error", "Please enter both email and password.", Wpf.Ui.Common.SymbolRegular.CloudError28, Wpf.Ui.Common.ControlAppearance.Danger);
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri($"{WebUrl}");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var LoginData = new { Email = Email, Password = Password };
                    var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(LoginData), Encoding.UTF8, "application/json");
                    HttpResponseMessage Response = await client.PostAsync("/Night/routes/launcher/login", content);
                    string ResponseBody = await Response.Content.ReadAsStringAsync();
                    JObject DataInfo = JObject.Parse(ResponseBody);

                    if (Response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    {
                        SnackBarMessage.Show("Login Error", DataInfo["message"].ToString(), Wpf.Ui.Common.SymbolRegular.CloudError28, Wpf.Ui.Common.ControlAppearance.Danger);
                        return;
                    }

                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        SnackBarMessage.Show("Logging In", "Please wait...", Wpf.Ui.Common.SymbolRegular.AccessibilityCheckmark28, Wpf.Ui.Common.ControlAppearance.Success);
                        MainFrame.Navigate(new LoadingScreen());
                        accounts.Character = DataInfo["profile"]["Character"].ToString().Split(":")[1].Trim();
                        await Task.Delay(2000);
                        SnackBarMessage.Show("Login As:", DataInfo["data"]["DisplayName"].ToString(), Wpf.Ui.Common.SymbolRegular.AccessibilityCheckmark28, Wpf.Ui.Common.ControlAppearance.Success);
                        MainFrame.Navigate(new Home());
                        return;
                    }

                    if (Response.StatusCode == System.Net.HttpStatusCode.NotAcceptable)
                    {
                        SnackBarMessage.Show("Login Error", DataInfo["message"].ToString(), Wpf.Ui.Common.SymbolRegular.CloudError28, Wpf.Ui.Common.ControlAppearance.Danger);
                        return;
                    }

                    if (Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        SnackBarMessage.Show("Login Error", DataInfo["message"].ToString(), Wpf.Ui.Common.SymbolRegular.CloudError28, Wpf.Ui.Common.ControlAppearance.Danger);
                        return;
                    }

                    if (Response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        SnackBarMessage.Show("Login Error", DataInfo["message"].ToString(), Wpf.Ui.Common.SymbolRegular.CloudError28, Wpf.Ui.Common.ControlAppearance.Danger);
                        return;
                    }

                    Response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                SnackBarMessage.Show("Login Error", $"Error: {ex.Message}", Wpf.Ui.Common.SymbolRegular.CloudError28, Wpf.Ui.Common.ControlAppearance.Danger);
            }
        }
    }
}
