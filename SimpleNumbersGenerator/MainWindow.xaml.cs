using System;
using System.Collections.Generic;
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

namespace SimpleNumbersGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //MainFrame.Source = new Uri("Pages/pageMain.xaml", UriKind.RelativeOrAbsolute);

        //    //label.Content = "Hello World!";

        //    int lNum;

        //    if(lowNumber.Text != "")
        //        lNum = int.Parse(lowNumber.Text);
        //    else
        //        lNum = 2;

        //    int hNum = int.Parse(highNumber.Text);

        //    for (int i = lNum; i <= hNum; i++)
        //    {
        //        if (isSimple(i))
        //        {
        //            label.Text += " " + i.ToString();
        //        }
        //    }
        //}

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            label.Text = "";

            int lNum;

            if (lowNumber.Text != "")
                lNum = int.Parse(lowNumber.Text);
            else
                lNum = 2;

            int hNum;

            if (highNumber.Text != "")
                hNum = int.Parse(highNumber.Text);
            else
                hNum = int.MaxValue;

            //for (int i = lNum; i <= hNum; i++)
            //{
            //    if (isSimple(i))
            //    {
            //        label.Text += " " + i.ToString();
            //    }
            //}

            int prime;

            while (true)
            {
                prime = await Task.Run(() => nextPrime(lNum));

                label.Text += " " + prime.ToString();

                lNum = prime;

                if(prime >= hNum)
                {
                    break;
                }
            }

        }


        //метод который определяет простое число или нет
        //private static bool isSimple(int N)
        //{
        //    for (int i = 2; i < (int)(N / 2); i++)
        //    {
        //        if (N % i == 0)
        //            return false;
        //    }
        //    return true;
        //}

        private static int nextPrime(int N)
        {
            while (true)
            {
                for (int i = 2; i < (int)(N / 2); i++)
                {
                    if (N % i == 0)
                    {
                        N++;
                        continue;
                    }
                }
                return N;
            }    
        }
    }
}
