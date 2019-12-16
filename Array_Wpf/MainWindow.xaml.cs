using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Array_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("Array.txt"))
                using (System.IO.StreamReader reader = new System.IO.StreamReader("Array.txt"))
                {
                    string line = reader.ReadLine();
                    txt_Lunghezza.Text = $"{line}";
                    int[] array = new int[int.Parse(line)];
                    int i = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        array[i++] = int.Parse(line);
                    }
                    StampaArray(array);
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int l = int.Parse(txt_Lunghezza.Text);
            int[] Array = new int[l];
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = random.Next();
            }
            StampaArray(Array);
            StreamWriter sw = new StreamWriter("Array.txt", false, Encoding.UTF8);

            sw.WriteLine(Array.Length);
            for (int i = 0; i < Array.Length; i++)
            {
                sw.WriteLine(Array[i]);
            }
            sw.Flush();
            sw.Close();
        }

        private void StampaArray(int[] Array)
        {
            lbl_risposta.Content += "[";
            for (int i = 0; i < Array.Length; i++)
            {
                if (i <= Array.Length - 2)
                {
                    lbl_risposta.Content += $"{ Array[i]}, ";
                }
                else
                    lbl_risposta.Content += $" { Array[i]} ";
            }
            lbl_risposta.Content += "]";
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            lbl_risposta.Content = "";
            txt_Lunghezza.Clear();
            string  = null;
        }
    }
}
