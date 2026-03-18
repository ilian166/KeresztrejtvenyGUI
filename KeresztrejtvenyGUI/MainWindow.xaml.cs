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
                };
            }
        }

        
    }

}