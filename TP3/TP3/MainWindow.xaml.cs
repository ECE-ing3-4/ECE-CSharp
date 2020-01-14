using System.Windows;

namespace TP3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new VM();
            VM.run();
        }

        private void ComboBox1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string pays = (ComboBox1.SelectedItem.ToString()).Split(' ')[1];
            Label1.Content = pays;
        }
    }
}
