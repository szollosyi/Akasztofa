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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Akasztofa
{
    /// <summary>
    /// Interaction logic for NevMentes.xaml
    /// </summary>
    public partial class NevMentes : Window
    {
        public NevMentes()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd\tHH:mm:ss");

            string name = tbxFelhasználónév.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Kérlek, add meg a neved!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string filePath = "dates.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{name}\t{currentDateTime}");
                }

                MessageBox.Show("Név és dátum sikeresen mentve!", "Mentés", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a fájl mentése közben: {ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
