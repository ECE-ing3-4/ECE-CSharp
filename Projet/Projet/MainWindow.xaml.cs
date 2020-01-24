using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json.Linq;

namespace Projet
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            const string url = "https://fr.openfoodfacts.org/categorie/pains.json";
            var json = new WebClient().DownloadString(url);

            var jObject = JObject.Parse(json);
            JToken jtokens = jObject["products"];

            ListBoxItem itm;
            
            foreach (JToken jtoken in jtokens)
            {
                string name = (string)jtoken["generic_name"];
                string quantity = (string)jtoken["quantity"];

                if (!String.IsNullOrEmpty(name))
                {
                    itm = new ListBoxItem();
                    itm.Content = name + " : " + quantity;
                    ListBox1.Items.Add(itm);
                }
            }

            /*
            dynamic magic = JsonConvert.DeserializeObject(json);
            string name;
            for (int i = 0; i < 20; i++)
            {
                name = magic["products"][i]["generic_name"];
                _ = MessageBox.Show(name);
                //Label1.Content = magic["products"][i]["generic_name"];
            }
            */
        }
    }
}
