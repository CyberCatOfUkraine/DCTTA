using DCTTA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for Currency.xaml
    /// </summary>
    public partial class CurrencyDetails : UserControl
    {
        public Currency Currency { get; }

        public CurrencyDetails(Currency currency)
        {
            InitializeComponent();
            Currency = currency;

            CodeLabel.Content = currency.Code;
            NameLabel.Content = currency.Name;
            PriceLabel.Content = currency.Price;
            VolumeLabel.Content = currency.Volume;
            PriceChangeLabel.Content = currency.PriceChange;

            foreach (var market in currency.Markets)
            {
                var btn = new MarketButton(market.Name, currency.BaseId);
                btn.Content = $"{market.Name} ціна:{market.Price}";
                btn.Click += btn.MarketClick;
                MarketsPanel.Children.Add(btn);
            }
        }
        public Action OnMainPageReturn;

        private void GoToMainPage_Click(object sender, RoutedEventArgs e)
        {
            OnMainPageReturn.Invoke();
        }
    }

    internal class MarketButton : Button
    {
        public string Name { get; }
        public string CryptoCurrency { get; }

        public MarketButton(string name, string cryptoCurrency)
        {
            Name = name;
            CryptoCurrency = cryptoCurrency;
        }

        internal void MarketClick(object sender, RoutedEventArgs e)
        {
            var url = "http://www.google.com/search?q=" + Name + "+" + CryptoCurrency + "+buy";

            /*
             * Microsoft Edge - msedge
             * Internet Explorer - iexplore
             * Chrome - chrome
             * Firefox - firefox
             */
            System.Diagnostics.Process.Start("explorer.exe", $"\"{url}\"");
            /* try
             {
                 System.Diagnostics.Process.Start("msedge.exe", url);
             }
             catch (Exception)
             {

                 try
                 {
                     System.Diagnostics.Process.Start("chrome.exe", url);
                 }
                 catch (Exception)
                 {

                     try
                     {
                         System.Diagnostics.Process.Start("firefox.exe", url);
                     }
                     catch (Exception)
                     {

                         try
                         {
                             System.Diagnostics.Process.Start("iexplore.exe", url);
                         }
                         catch (Exception)
                         {
                             MessageBox.Show("Встановіть нормальний браузер і перейдіть за адресою: " + url);
                         }
                     }
                 }
             }*/
        }
    }
}
