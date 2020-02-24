using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace Projet
{
    public partial class MainWindow : Window
    {
        //private object pictureBox;

        public ObservableCollection<Product> ProductsList { get; set; }
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
            //ListBoxItem product;
            Product prod1 = new Product();

            foreach (JToken jtoken in jtokens)
            {
                prod1 = new Product();
                //MessageBox.Show(jtoken.ToString());
                //string picture = (string)jtoken["image_front_thumb_url"];
                prod1.Name = (string)jtoken["product_name"];
                prod1.Quantity = (string)jtoken["quantity"];
                prod1.Brand = (string)jtoken["brands"];
                prod1.Picture_url = (string)jtoken["image_thumb_url"];
                prod1.Nutriscore = (string)jtoken["nutriscore_grade"]; 

                if (!String.IsNullOrEmpty(prod1.Name))
                {

                    //product = new ListBoxItem();
                    //product.Content = prod1.Name + " : " + prod1.Quantity + " : " + prod1.Brand;
                    //product.Source= picture;
                    ProductsList.Add(prod1);
                }
            }
        }

        private void putOneInTheList(JToken jtoken)
        {
            //ListBoxItem product;
            Product prod1 = new Product();

            //MessageBox.Show("hey");
            MessageBox.Show(jtoken.ToString());
            //string picture = (string)jtoken["image_front_thumb_url"];
            prod1.Name = (string)jtoken["product"]["product_name"];
            prod1.Quantity = (string)jtoken["product"]["quantity"];
            prod1.Brand = (string)jtoken["product"]["brands"];
            prod1.Picture_url = (string)jtoken["product"]["image_thumb_url"];
            prod1.Nutriscore = display_nutriscore((string)jtoken["product"]["nutriscore_grade"]);
            //test1.Picture_url = 
            //string name = (string)jtoken["product_name"];
            //string quantity = (string)jtoken["quantity"];
            //string brands = (string)jtoken["brands"];
            //MessageBox.Show((string)jtoken["product_name"]);
            //MessageBox.Show(prod1.Name);

            if (!String.IsNullOrEmpty(prod1.Name))
            {

                //product = new ListBoxItem();
                //product.Content = prod1.Name + " : " + prod1.Quantity + " : " + prod1.Brand;
                //MessageBox.Show(prod1.Name + " : " + prod1.Quantity + " : " + prod1.Brand);
                //MessageBox.Show(ProductsList.Count.ToString());
                ProductsList.Add(prod1);
                //MessageBox.Show(ProductsList.Count.ToString());
            }
        }

        private void loadAllProducts()
        {
            JToken jtokens = getAllProducts()["products"];
            putInTheList(jtokens);
        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {

            ProductsList = new ObservableCollection<Product>();
            loadAllProducts();
            this.ListBox1.ItemsSource = ProductsList;
        }

        public string display_nutriscore(string value)
        {
            value = value.ToLower();
            switch (value)
            {
                case "a":
                    return "D:/Documents/ECE/ing4/C#/CSharp/Pictures/nutrition_A.jpg";
                case "b":
                    return "D:/Documents/ECE/ing4/C#/CSharp/Pictures/nutrition_B.jpg";
                case "c":
                    return "D:/Documents/ECE/ing4/C#/CSharp/Pictures/nutrition_C.jpg";
                case "d":
                    return "D:/Documents/ECE/ing4/C#/CSharp/Pictures/nutrition_D.jpg";
                case "e":
                    return "D:/Documents/ECE/ing4/C#/CSharp/Pictures/nutrition_E.jpg";
                default:
                    return ("");

            };

        }
        
        private void GetBarCode_Click(object sender, RoutedEventArgs e)
        {
            ProductsList = new ObservableCollection<Product>();
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

            this.ListBox1.ItemsSource = ProductsList;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {  
            //ProductsList.Clear();
            ProductsList = new ObservableCollection<Product>();

            this.ListBox1.ItemsSource = ProductsList;
        }

        private void GetDesc_Click(object sender, RoutedEventArgs e)
        {
            
            ProductsList = new ObservableCollection<Product>();
            string desc = Description.Text;
            string url = "https://fr.openfoodfacts.org/cgi/search.pl?search_terms=" + desc + "&search_simple=1&action=process&json=1";


            JToken result;

            result = getProducts(url);
            if (Int32.TryParse(result["count"].ToString(), out int count))
                if (count > 1)
                {
                    //MessageBox.Show(result.ToString());
                    putOneInTheList(result);
                }
                else
                {
                    MessageBox.Show("Product not found");
                }
            else
                Console.WriteLine("Count string could not be parsed.");

            

            this.ListBox1.ItemsSource = ProductsList;
        }
    }

       
    }
