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

<<<<<<< HEAD
        private void Exception()
        {
            throw new NotImplementedException();
        }


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
        }

=======
>>>>>>> b5f7770811848073e0c759a9e0dcdf94dc77af48
        private JToken getAllProducts()
        {
            const string url = "https://fr.openfoodfacts.org/categorie/pains.json";
            var json = new WebClient().DownloadString(url);

            return JObject.Parse(json);
        }

        private void LoadProducts()
        {

            JToken jtokens = getAllProducts()["products"];

            ListBoxItem product;


            foreach (JToken jtoken in jtokens)
            {
                string picture = (string)jtoken["image_front_thumb_url"];
                /*string name = (string)jtoken["generic_name"];
                string quantity = (string)jtoken["quantity"];
                string brands = (string)jtoken["brands"];

                if (!String.IsNullOrEmpty(name))*/
                {
                  
                    product = new ListBoxItem();
                    // product.Content = name + " : " + quantity + " : " + brands;
                    product.Source= picture;
                    ProductsList.Add(product);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ProductsList = new List<ListBoxItem>();
            this.ListBox1.DataContext = this;
            LoadProducts();

        }
    }

       
    }
