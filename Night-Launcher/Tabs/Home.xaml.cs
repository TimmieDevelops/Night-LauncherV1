using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Windows.Threading;
using Wpf.Ui.Controls;

namespace Night_Launcher.Tabs
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : System.Windows.Controls.UserControl
    {
        private DispatcherTimer DispatcherTimer;
        public StackPanel BuildPanel1 => this.BuildPanel;
        public Home()
        {
            InitializeComponent();
            Loaded += Home_Loaded;
        }

        private void Home_Loaded(object sender, RoutedEventArgs e)
        {
            ApplyTimer();
            LoadBuildBored();
        }

        private void ApplyTimer()
        {
            DispatcherTimer = new DispatcherTimer();
            DispatcherTimer.Tick += new EventHandler(UpdateTimerLabel);
            DispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            DispatcherTimer.Start();
            return;
        }

        private void UpdateTimerLabel(object sender, EventArgs e)
        {
            TimerLabel.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CreateBuildBored(JObject BuildInfo)
        {
            string ImagePath = BuildInfo["Images"]?.ToString();
            string VersionName = BuildInfo["Name"]?.ToString();

            Border border = new Border();
            border.Background = System.Windows.Media.Brushes.Gray;
            border.CornerRadius = new System.Windows.CornerRadius(35);
            border.BorderThickness = new System.Windows.Thickness(10);
            border.Height = 75;
            border.Margin = new System.Windows.Thickness(5);
            border.Name = "BoredBuild";

            Grid grid = new Grid();

            System.Windows.Controls.Label VersionLabel = new System.Windows.Controls.Label();
            VersionLabel.Content = VersionName;
            VersionLabel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            VersionLabel.VerticalAlignment = VerticalAlignment.Center;
            VersionLabel.FontSize = 38;
            VersionLabel.Foreground = System.Windows.Media.Brushes.White;
            VersionLabel.FontStyle = FontStyles.Normal;
            VersionLabel.FontFamily = new FontFamily("Arial Black");
            VersionLabel.Name = "VersionLabel";

            Wpf.Ui.Controls.Button PlayButton = new Wpf.Ui.Controls.Button();
            PlayButton.Content = "Play";
            PlayButton.Margin = new System.Windows.Thickness(0, 10, 20, 0);
            PlayButton.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            PlayButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            PlayButton.Background = System.Windows.Media.Brushes.DarkGray;
            PlayButton.Click += PlayButton_Click;

            Wpf.Ui.Controls.Button RemoveButton = new Wpf.Ui.Controls.Button();
            RemoveButton.Content = "Remove";
            RemoveButton.Margin = new System.Windows.Thickness(0, 10, 70, 0);
            RemoveButton.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            RemoveButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            RemoveButton.Background = System.Windows.Media.Brushes.DarkGray;
            RemoveButton.Click += RemoveButton_Click;

            System.Windows.Controls.Image Image = new System.Windows.Controls.Image();
            Image.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Image.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            Image.Margin = new System.Windows.Thickness(15, 0, 0, 0);
            Image.Source = new BitmapImage(new System.Uri(ImagePath, System.UriKind.RelativeOrAbsolute));

            grid.Children.Add(VersionLabel);
            grid.Children.Add(PlayButton);
            grid.Children.Add(RemoveButton);
            grid.Children.Add(Image);

            border.Child = grid;

            BuildPanel.Children.Add(border);
        }

        private void LoadBuildBored()
        {
            var MainWindow = Window.GetWindow(this) as MainWindow;
            var SnackBarMessage = MainWindow.SnackBarMessage;

            JArray BuildArray;
            
            if (File.Exists("Builds.json"))
            {
                string ExistingContent = File.ReadAllText("Builds.json");
                BuildArray = JArray.Parse(ExistingContent);

                foreach (JObject BuildInfo in BuildArray.Children<JObject>())
                {
                    CreateBuildBored(BuildInfo);
                }
            }
            else
            {
                //nothing in here so yw
            }
        }

        private void AddBuild_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = Window.GetWindow(this) as MainWindow;
            var MainFrame = MainWindow.MainFrame;
            var SnackBarMessage = MainWindow.SnackBarMessage;

            JArray BuildArray;

            if (File.Exists("Builds.json"))
            {
                string ExistingContent = File.ReadAllText("Builds.json");
                BuildArray = JArray.Parse(ExistingContent);
            }
            else
            {
                BuildArray = new JArray();
            }

            bool Exists = false;
            foreach (JObject obj in BuildArray.Children<JObject>())
            {
                string build = obj["Build"]?.ToString();
                string name = obj["Name"]?.ToString();

                if (build == FortnitePath.Text || name == VersionName.Text)
                {
                    Exists = true;
                    break;
                }
            }

            if (!Exists)
            {
                JObject newBuild = new JObject(
                    new JProperty("Build", FortnitePath.Text),
                    new JProperty("Name", VersionName.Text),
                    new JProperty("Images", FortnitePath.Text + @"\FortniteGame\Content\Splash\Splash.bmp")
                );
                BuildArray.Add(newBuild);

                string JsonContent = BuildArray.ToString(Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("Builds.json", JsonContent);

                CreateBuildBored(newBuild);
                SnackBarMessage.Show("Success", "Build has been updated", Wpf.Ui.Common.SymbolRegular.Warning28, Wpf.Ui.Common.ControlAppearance.Success);
            }
            else
            {
                SnackBarMessage.Show("Error", "Build or VersionName Already Exist", Wpf.Ui.Common.SymbolRegular.Warning28, Wpf.Ui.Common.ControlAppearance.Danger);
            }

            BackgroundImage.Visibility = Visibility.Visible;
            TimerLabel.Visibility = Visibility.Visible;
            AddBuildButton.Visibility = Visibility.Visible;
            ScrollerViewer.Visibility = Visibility.Visible;
            BuildFrame.Visibility = Visibility.Hidden;
        }

        private void AddPath_Click(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    var SelectedFolderPath = folderBrowserDialog.SelectedPath;
                    FortnitePath.Text = SelectedFolderPath;
                }
            }
        }

        private void ExitBuild_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = Window.GetWindow(this) as MainWindow;
            var MainFrame = MainWindow.MainFrame;

            BackgroundImage.Visibility = Visibility.Visible;
            TimerLabel.Visibility = Visibility.Visible;
            AddBuildButton.Visibility = Visibility.Visible;
            ScrollerViewer.Visibility = Visibility.Visible;
            BuildFrame.Visibility = Visibility.Hidden;
        }

        private void AddBuild1_Click(object sender, RoutedEventArgs e)
        {
            BackgroundImage.Visibility = Visibility.Hidden;
            TimerLabel.Visibility = Visibility.Hidden;
            AddBuildButton.Visibility = Visibility.Hidden;
            ScrollerViewer.Visibility = Visibility.Hidden;
            BuildFrame.Visibility = Visibility.Visible;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
 
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = Window.GetWindow(this) as MainWindow;
            var SnackBarMessage = MainWindow.SnackBarMessage;
            

            SnackBarMessage.Show("Test", "Test", Wpf.Ui.Common.SymbolRegular.Warning28, Wpf.Ui.Common.ControlAppearance.Danger);
        }
    }
}
