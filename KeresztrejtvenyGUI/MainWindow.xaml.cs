using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeresztrejtvenyGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 6; i <= 15; i++)
            {
                cbSorok.Items.Add(i);
                cbOszlopok.Items.Add(i);
            }
            cbSorok.SelectedItem = 15;
            cbOszlopok.SelectedItem = 15;

            for (int i = 1; i <= 10; i++)
            {
                cbMentesIndex.Items.Add(i);
            }
            cbMentesIndex.SelectedIndex = 2;
        }
        private void btnLetrehozas_Click(object sender, RoutedEventArgs e)
        {
            icRacs.Items.Clear();

            int sor = (int)cbSorok.SelectedItem;
            int oszlop = (int)cbOszlopok.SelectedItem;

            var factory = new FrameworkElementFactory(typeof(UniformGrid));
            factory.SetValue(UniformGrid.RowsProperty, sor);
            factory.SetValue(UniformGrid.ColumnsProperty, oszlop);
            icRacs.ItemsPanel = new ItemsPanelTemplate(factory);

            for (int i = 0; i < sor * oszlop; i++)
            {
                TextBox tb = new TextBox
                {
                    Text = "-",
                    Width = 30,
                    Height = 30,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    MaxLength = 1
                };


                tb.MouseDoubleClick += Mezo_MouseDoubleClick;

                icRacs.Items.Add(tb);
            }
        }
        private void Mezo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBox tb)
            {
                tb.Text = (tb.Text == "-") ? "#" : "-";

                tb.SelectionStart = tb.Text.Length;
            }
        }




        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = (int)cbMentesIndex.SelectedItem;
                string fajlnev = $"kr{index}.txt";
                int oszlopDb = (int)cbOszlopok.SelectedItem;

                List<string> sorok = new List<string>();
                string aktualisSor = "";

                for (int i = 0; i < icRacs.Items.Count; i++)
                {
                    var tb = (TextBox)icRacs.Items[i];
                    aktualisSor += tb.Text;

                    if ((i + 1) % oszlopDb == 0)
                    {
                        sorok.Add(aktualisSor);
                        aktualisSor = "";
                    }
                }

                System.IO.File.WriteAllLines(fajlnev, sorok);
                MessageBox.Show("Sikeres mentés!", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba: {ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}