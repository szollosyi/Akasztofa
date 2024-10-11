using Akasztofa.Controllers;
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
        static string szo = "Alma";
        static int tippSzam = 0;
        static int hibaSzam = 0;
        const int MAXHIBA = 8;
        public MainWindow()
        {
            InitializeComponent();
        }

        private static void ValasztujSzo()
        {
            List<string> list = new SzoController().SzoListFromFile();
            Random rnd = new Random();
            szo = list[rnd.Next(list.Count)];
        }

        private void JatekterInit(object sender, RoutedEventArgs e)
        {
            ValasztujSzo();
            tippSzam = 0;
            hibaSzam = 0;
            BitmapImage ujKep = new BitmapImage();
            ujKep.BeginInit();
            ujKep.UriSource = new Uri($"\\Images\\0.png", UriKind.Relative);
            ujKep.EndInit();
            imgBito.Source = ujKep;
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
            miInditas.IsEnabled = false;
        }

        private void TippClick(object sender, RoutedEventArgs e)
        {
            tippSzam++;
            bool talalt = false;
            foreach (FeladvanyButton item in stpBetuk.Children)
            {
                if (item.Tartalom.ToLower() == (sender as Button).Content.ToString())
                {
                    item.Felfed();
                    talalt = true;
                }
            }
            if (!talalt)
            {
                MessageBox.Show("Hiba!!!");
                hibaSzam++;
                BitmapImage ujKep = new BitmapImage();
                ujKep.BeginInit();
                ujKep.UriSource = new Uri($"\\Images\\{hibaSzam}.png", UriKind.Relative);
                ujKep.EndInit();
                imgBito.Source = ujKep;
            }
            if (Vege())
            {
                if (hibaSzam < MAXHIBA)
                {
                    MessageBox.Show($"Gratulálok, kitaláltad a szót! {szo}\nTippek száma: {tippSzam}");
                    miInditas.IsEnabled = true;
                    NevMentes mentes = new NevMentes();
                    mentes.Show();
                }
                else
                {
                    MessageBox.Show($"Sajnos vesztetél. Próbálkozások száma: {tippSzam}.");
                    foreach (FeladvanyButton item in stpBetuk.Children)
                    {
                        item.Felfed();
                    }
                }

                miInditas.IsEnabled = true;
                miInditas.Header = "Új játék";
                tippSzam = 0;
            }
        }

        private bool Vege()
        {
            foreach (FeladvanyButton item in stpBetuk.Children)
            {
                if (item.Content.ToString() == "_" && hibaSzam < MAXHIBA)
                    return false;
            }
            return true;
        }
    }
}
