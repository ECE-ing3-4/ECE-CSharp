﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using iTextSharp.text.pdf;
using Newtonsoft.Json.Linq;

namespace Projet
{
    public partial class MainWindow : Window
    {
        //private object pictureBox;

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

        public JToken getProducts(string url)
        {
            var json = new WebClient().DownloadString(url);

            return JObject.Parse(json);
        }
        private JToken getAllProducts()
        {
            const string url = "https://fr.openfoodfacts.org/categorie/pains.json";
            return getProducts(url);
        }

        private void putInTheList(JToken jtokens)
        {
            ListBoxItem product;
            Product prod1 = new Product();

            foreach (JToken jtoken in jtokens)
            {
                //MessageBox.Show(jtoken.ToString());
                //string picture = (string)jtoken["image_front_thumb_url"];
                prod1.Name = (string)jtoken["product_name"];
                prod1.Quantity = (string)jtoken["quantity"];
                prod1.Brand = (string)jtoken["brands"];

                if (!String.IsNullOrEmpty(prod1.Name))
                {

                    product = new ListBoxItem();
                    product.Content = prod1.Name + " : " + prod1.Quantity + " : " + prod1.Brand;
                    //product.Source= picture;
                    ProductsList.Add(product);
                }
            }
        }

        private void putOneInTheList(JToken jtoken)
        {
            ListBoxItem product;
            Product prod1 = new Product();
            
            //MessageBox.Show("hey");
            //MessageBox.Show(jtoken.ToString());
            //string picture = (string)jtoken["image_front_thumb_url"];
            prod1.Name = (string)jtoken["product_name"];
            prod1.Quantity = (string)jtoken["quantity"];
            prod1.Brand = (string)jtoken["brands"];
            //test1.Picture_url = 
            //string name = (string)jtoken["product_name"];
            //string quantity = (string)jtoken["quantity"];
            //string brands = (string)jtoken["brands"];

            if (!String.IsNullOrEmpty(prod1.Name))
            {

                product = new ListBoxItem();
                product.Content = prod1.Name + " : " + prod1.Quantity + " : " + prod1.Brand;
                MessageBox.Show(prod1.Name + " : " + prod1.Quantity + " : " + prod1.Brand);
                MessageBox.Show(ProductsList.Count.ToString());
                ProductsList.Add(product);
            }
        }

        private void loadAllProducts()
        {
            JToken jtokens = getAllProducts()["products"];
            putInTheList(jtokens);
        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {

            ProductsList = new List<ListBoxItem>();
            this.ListBox1.DataContext = this;
            loadAllProducts();
            MessageBox.Show("nfekm");
        }

        private void GetBarCode_Click(object sender, RoutedEventArgs e)
        {
            ProductsList = new List<ListBoxItem>();
            string code = Barcode.Text;
            string url = "https://ssl-api.openfoodfacts.org/api/v0/product/"+code;
            string status;
            JToken result;

            if (code.All(char.IsDigit))
            {
                result = getProducts(url);
                status = result["status"].ToString();
                //result = result["product"];
                if (status == "1"){
                    //MessageBox.Show(result.ToString());
                    putOneInTheList(result);
                }
                else
                {
                    MessageBox.Show("Product not found");
                }
            }
            else
                MessageBox.Show("The Barcode is unvalid");
        }
    }

       
    }
