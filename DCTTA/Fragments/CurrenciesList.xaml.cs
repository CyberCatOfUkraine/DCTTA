using DCTTA.Models;
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

namespace DCTTA.Fragments
{
    /// <summary>
    /// Interaction logic for CurrenciesList.xaml
    /// </summary>
    public partial class CurrenciesList : UserControl
    {
        public List<Currency> Currencies { get; }

        public CurrenciesList(List<Currency> currencies)
        {
            InitializeComponent();
            Currencies = currencies;

            InitializeDataGrid();
        }


        private void InitializeDataGrid()
        {
            CryptoCurrenciesDataGrid.ItemsSource = Currencies;
        }
        public Action<Currency> OnCurrencyDetailsShow { get; set; }
        private void ShowDetails_Click(object sender, RoutedEventArgs e)
        {
            if (OnCurrencyDetailsShow == null)
            {
                MessageBox.Show("Хтось проспав ініцалізацію події що мала б показувати деталі по крипті, і хто ж це може бути ?");
            }
            OnCurrencyDetailsShow.Invoke((Currency)CryptoCurrenciesDataGrid.CurrentItem);
        }

    }

}
