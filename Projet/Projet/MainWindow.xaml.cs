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
        public int sortState=0;
        public ObservableCollection<Product> ProductsList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

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
            Product prod1 = new Product();
            //MessageBox.Show(jtokens.ToString());
            foreach (JToken jtoken in jtokens)
            {
                prod1 = new Product();
                //MessageBox.Show(jtoken.ToString());
                //string picture = (string)jtoken["image_front_thumb_url"];
                prod1.Name = (string)jtoken["product_name"];
                prod1.Quantity = (string)jtoken["quantity"];
                prod1.Brand = (string)jtoken["brands"];
                prod1.Picture_url = (string)jtoken["image_thumb_url"];
                prod1.Nutriscore = display_nutriscore((string)jtoken["nutriscore_grade"]); 

                if (!String.IsNullOrEmpty(prod1.Name))
                {
                    ProductsList.Add(prod1);
                }
            }
        }

        private void putOneInTheList(JToken jtoken)
        {
            Product prod1 = new Product();

            //MessageBox.Show("hey");
            //MessageBox.Show(jtoken.ToString());
            prod1.Name = (string)jtoken["product"]["product_name"];
            prod1.Quantity = (string)jtoken["product"]["quantity"];
            prod1.Brand = (string)jtoken["product"]["brands"];
            prod1.Picture_url = (string)jtoken["product"]["image_thumb_url"];
            prod1.Nutriscore = display_nutriscore((string)jtoken["product"]["nutriscore_grade"]);
            
            if (!String.IsNullOrEmpty(prod1.Name))
            {
                ProductsList.Add(prod1);
            }
        }

        private void loadAllProducts()
        {
            JToken jtokens = getAllProducts()["products"];
            putInTheList(jtokens);
        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {
            //sortState = 0;
            //SortButton.Content = "Sort";
            ProductsList = new ObservableCollection<Product>();
            loadAllProducts();
            this.ListBox1.ItemsSource = ProductsList;
        }

        public string display_nutriscore(string value)
        {
            //MessageBox.Show(value);
            try
            {
                value = value.ToLower();
            }
            catch (Exception ex)
            {
                //No nutriscore
                return "./Pictures/nutrition_none.jpg";
            }

            switch (value)
            {
                case "a":
                    return "./Pictures/nutrition_A.jpg";
                case "b":
                    return "./Pictures/nutrition_B.jpg";
                case "c":
                    return "./Pictures/nutrition_C.jpg";
                case "d":
                    return "./Pictures/nutrition_D.jpg";
                case "e":
                    return "./Pictures/nutrition_E.jpg";
                default:
                    return "./Pictures/nutrition_none.jpg";

            };

        }
        
        private void GetBarCode_Click(object sender, RoutedEventArgs e)
        {
            //sortState = 0;
            //SortButton.Content = "Sort";

            ProductsList = new ObservableCollection<Product>();
            string code = Barcode.Text;
            Barcode.Text = "";
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
            //sortState = 0;
            //SortButton.Content = "Sort";
            //ProductsList.Clear();
            ProductsList = new ObservableCollection<Product>();

            this.ListBox1.ItemsSource = ProductsList;
        }

        private void GetDesc_Click(object sender, RoutedEventArgs e)
        {
            //sortState = 0;
            //SortButton.Content = "Sort";
            ProductsList = new ObservableCollection<Product>();
            string desc = Description.Text;
            Description.Text = "";
            string url = "https://fr.openfoodfacts.org/cgi/search.pl?search_terms=" + desc + "&search_simple=1&action=process&json=1";


            JToken result;

            result = getProducts(url);
            if (Int32.TryParse(result["count"].ToString(), out int count))
                if (count > 1)
                {
                    //MessageBox.Show(result.ToString());
                    putInTheList(result["products"]);
                }
                else
                {
                    MessageBox.Show("Product not found");
                }
            else
                Console.WriteLine("Count string could not be parsed.");

            

            this.ListBox1.ItemsSource = ProductsList;
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            switch (sortState)
            {
                case 0:
                    sortState = 1;
                    break;
                case 1:
                    sortState = 2;
                    break;
                case 2:
                    sortState = 1;
                    break;
            }

            if (sortState == 1)
            {
                SortButton.Content = "Sort ↑";
                this.ListBox1.Items.SortDescriptions.Clear();
                this.ListBox1.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Nutriscore", System.ComponentModel.ListSortDirection.Ascending));
            }
            else if (sortState == 2)
            {
                SortButton.Content = "Sort ↓";
                this.ListBox1.Items.SortDescriptions.Clear();
                this.ListBox1.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Nutriscore", System.ComponentModel.ListSortDirection.Descending));
            }
        }


    }
}
