using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json.Linq;

namespace Projet
{
    public partial class MainWindow : Window
    {
        private object pictureBox;

        public List<ListBoxItem> ProductsList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exception()
        {
            throw new NotImplementedException();
        }
        /*
        private void OpenImage(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    pictureBox.Image = new Bitmap(response.GetResponseStream);
                }
            }
            catch Exception(){ }
            }
        }*/

        private JToken getProducts(string url)
        {
            var json = new WebClient().DownloadString(url);

            return JObject.Parse(json);
        }
        private JToken getAllProducts()
        {
            const string url = "https://fr.openfoodfacts.org/categorie/pains.json";
            return getProducts(url);
        }

        private void LoadProducts()
        {

            JToken jtokens = getAllProducts()["products"];

            ListBoxItem product;


            foreach (JToken jtoken in jtokens)
            {
                //string picture = (string)jtoken["image_front_thumb_url"];
                string name = (string)jtoken["generic_name"];
                string quantity = (string)jtoken["quantity"];
                string brands = (string)jtoken["brands"];

                if (!String.IsNullOrEmpty(name))
                {
                  
                    product = new ListBoxItem();
                    product.Content = name + " : " + quantity + " : " + brands;
                    //product.Source= picture;
                    ProductsList.Add(product);
                }
            }
        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {

            ProductsList = new List<ListBoxItem>();
            this.ListBox1.DataContext = this;
            LoadProducts();

        }

        private void GetBarCode_Click(object sender, RoutedEventArgs e)
        {
            string code = Barcode.Text;
            string url = "https://ssl-api.openfoodfacts.org/api/v0/product/"+code;
            if (Int32.TryParse(code,out int c))
                MessageBox.Show(code);
            else
                MessageBox.Show("The Barcode is unvalid");
        }
    }

       
    }
