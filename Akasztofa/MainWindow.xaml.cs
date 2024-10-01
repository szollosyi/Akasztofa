using System;
using System.Collections.Generic;
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

namespace Akasztofa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string szo = "Bajnok";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void JatekterInit(object sender, RoutedEventArgs e)
        {
            stpBetuk.Children.Clear();
            foreach (char betu in szo)
            {
                FeladvanyButton ujButton = new FeladvanyButton()
                {
                    Tartalom = betu.ToString(),
                    Content = "_",
                    Width = 50,
                    Height = 50
                };
                stpBetuk.Children.Add(ujButton);
            }
            {
                
            }
        }

        private void TippClick(object sender, RoutedEventArgs e)
        {
            foreach (FeladvanyButton item in stpBetuk.Children)
            {
                if (item.Tartalom.ToLower() == (sender as Button).Content.ToString())
                {
                    item.Felfed();
                }
            }
            if (Vege())
            {
                MessageBox.Show($"Gratulálok, kitaláltad a szót! {szo}");
            }
        }

        private bool Vege(object sender, RoutedEventArgs e)
        {
            foreach (FeladvanyButton item in stpBetuk.Children)
            {
                if (item.Content.ToString() == "_")
                    return false;
            }
            return true;
        }
    }
}
