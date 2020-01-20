using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using Newtonsoft.Json;

namespace Projet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            const string url = "https://fr.openfoodfacts.org/categorie/pains.json";
            var json = new WebClient().DownloadString(url);
            dynamic magic = JsonConvert.DeserializeObject(json);
            string name;
            for (int i = 0; i < 20; i++)
            {
                name = magic["products"][i]["generic_name"];
                _ = MessageBox.Show(name);
                //Label1.Content = magic["products"][i]["generic_name"];
            }
            
        }
    }
}
