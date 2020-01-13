using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TP3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ComboBoxItem SelectedcbItem { get; set; }
        public ObservableCollection<ComboBoxItem> cbItems { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            cbItems = new ObservableCollection<ComboBoxItem>();
            var cbItem = new ComboBoxItem { Content = "<--Pays-->" };
            //SelectedcbItem = cbItem;
            cbItems.Add(cbItem);
            
            string[] tokens;
            char[] separators = { ',' };
            string str = "";

            FileStream fs = new FileStream(@"D:\ECE\ing4\C#\CSharp\TP3\Capital.csv", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);

            while ((str = sr.ReadLine()) != null)
            {
                tokens = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                cbItems.Add(new ComboBoxItem { Content = tokens[0] });
            }
            
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(sender);
        }
    }
}
