using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
using Microsoft.VisualBasic;

namespace HomeWork
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
        private void HandleCheck(object sender, RoutedEventArgs e)
        {
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
        }
        
        // private void HandleThirdState(object sender, RoutedEventArgs e)
        // {
        //     text1.Content = "The CheckBox is in the indeterminate state.";
        // }
        private void LogToFile(int i)
        {
            try
            {
                //Создание/открытие файла и объекта для взаимодействия с ним
                StreamWriter sw = new StreamWriter("log.txt", true);
                //Запись в файл
                string time = DateTime.Now.ToString("hh:mm:ss");
                if (i == 1)
                {
                    sw.WriteLine("***************************************");
                    sw.WriteLine(time);
                    sw.WriteLine("InputBoxContent: " + inputbox1.Text);
                    sw.WriteLine("ResultBoxContent: " + text1.Content);
                }
                else
                {
                    sw.WriteLine("***************************************");
                    sw.WriteLine(time);
                    sw.WriteLine("InputBoxContent: " + inputbox2.Text);
                    sw.WriteLine("ResultBoxContent: " + text2.Content);
                }
                //Закрытие файла
                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        private void OnText1Changed(object sender, TextChangedEventArgs e)
        {
            int num = -1;
            
            try
            {
                num = Int32.Parse(inputbox1.Text);
            }
            catch (Exception ex)
            {
                text1.Content = "Введите дни";
            }
            
            if (num >= 0)
            {
                text1.Content = num * 24 * 60 + " минут";
            }
            
            LogToFile(1);
        }
        private void OnText2Changed(object sender, TextChangedEventArgs e)
        {
            int num = -1;
            
            try
            {
                num = Int32.Parse(inputbox2.Text);
            }
            catch (Exception ex)
            {
                text2.Content = "Введите минуты";
            }

            if (num >= 0)
            {
                num = num / 24 / 60;
                int mod = num;
                if (num >= 10)
                {
                    mod = Convert.ToInt32(num % Math.Pow(10d, Convert.ToDouble(num.ToString().Length - 1)));
                }
                if (mod >= 5 && mod <= 9 || mod == 0 ||
                    num >= 10 && num <= 20)
                {
                    text2.Content = num + " дней";
                } else if (mod >= 2 && mod <= 4)
                {
                    text2.Content = num + " дня";
                }
                else
                {
                    text2.Content = num + " день";
                }
            }
            
            LogToFile(2);
        }
    }
}