using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

namespace Night_Launcher.Tabs
{
    /// <summary>
    /// Interaction logic for Tab.xaml
    /// </summary>
    public partial class Tab : UserControl
    {
        public Tab()
        {
            InitializeComponent();
            ApplyCosmetics();
        }

        private async void ApplyCosmetics()
        {
            var imageUrl = $"https://fortnite-api.com/images/cosmetics/br/{accounts.Character}/icon.png";
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imageUrl, UriKind.Absolute);
            bitmapImage.EndInit();

            ProfileIcon.Source = bitmapImage;
        }
    }
}
