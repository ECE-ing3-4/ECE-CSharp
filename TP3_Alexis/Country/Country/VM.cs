using System;
using System.IO;
using System.Text;
using System.Windows;


namespace Country
{
    internal class VM
    {
        public VM()
        {
        }

        public static void opening()
        {
            string[] tokens = [""];
            char[] separators = { ';' };
            string str = "";

            FileStream fs = new FileStream(@"D:\Documents\ECE\ing4\C#\CSharp\TP3_Alexis\Country\listePays.csv",
                                       FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);

            while ((str = sr.ReadLine()) != null)
            {
                tokens = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                //MessageBox.Show(tokens[0]);
                //MessageBox.Show(tokens[1]);

            }
            MessageBox.Show(tokens[1]);
        }
    }
}