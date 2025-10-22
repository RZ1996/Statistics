using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Statistics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stats stats = new Stats();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void inputForNumbers_TextChanged(object sender, TextChangedEventArgs e)
        {
            stats.GetNumbers(inputForNumbers.Text);
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            bool ok = stats.GetNumbers(inputForNumbers.Text.Trim());

            if (!ok || stats.Numbers == null || stats.Numbers.Count == 0)
            {
                MessageBoxResult r = MessageBox.Show(
                    "Invalid number",
                    "Input error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                if (r == MessageBoxResult.OK)
                {
                    inputForNumbers.Clear();
                    inputForNumbers.Focus();

                    SumOfNumbers.Text = "";
                    SmallestNumber.Text = "";
                    LargestNumber.Text = "";
                    AvgNumber.Text = "";
                    SortedNumbers.Text = "";
                }
                return;
            }

            CultureInfo culture = CultureInfo.GetCultureInfo("cs-CZ");

            SumOfNumbers.Text = stats.Sum().ToString(culture);
            SmallestNumber.Text = stats.SmallestNumber().ToString(culture);
            LargestNumber.Text = stats.BiggestNumber().ToString(culture);
            AvgNumber.Text = stats.Avg().ToString(culture);

            if (comboBox.SelectedIndex == 0)
            {
                SortedNumbers.Text = stats.SortedAsc();
            }
            else if (comboBox.SelectedIndex == 1)
            {
                SortedNumbers.Text = stats.SortedDesc();
            }
            else
            {
                SortedNumbers.Text = "";
            }
        }

    }
}