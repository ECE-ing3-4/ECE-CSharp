namespace Projet
{
    public class Product
    {
        private string picture_url;
        private string name;
        private string quantity;
        private string brand;

        public string Name { get => name; set => name = value; }
        public string Picture_url { get => picture_url; set => picture_url = value; }
        public string Quantity { get => quantity; set => quantity = value; }
        public string Brand { get => brand; set => brand = value; }
    }
}