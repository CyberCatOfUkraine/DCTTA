using ApiScraper.Scrapper;
using DCTTA.Fragments;
using DCTTA.Mappers;
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

namespace DCTTA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            Task<List<Currency>> task = new(() =>
            {
                CoinCapScraper scraper = new();
                scraper.Initialize();
                return scraper.GetAll.Convert();
            });
            task.Start();
            Container.Content = new CurrenciesList(task.Result);
        }
    }
}
