using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KPO_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in MainRoot.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str == "CE")
            {
                ResultLabel.Text = "";
            }
            else if (str == "=")
            {
                string expression = ResultLabel.Text.Replace(",", "."); // Делаем это для устранение ошибок при подсчёте
                string value = new DataTable().Compute(expression, null).ToString();
                ResultLabel.Text = value;
            }
            else if (str == "del")
            {
                if (ResultLabel.Text.Length > 0)
                {
                    ResultLabel.Text = ResultLabel.Text.Substring(0, ResultLabel.Text.Length - 1);
                }
            }
            else
            {
                ResultLabel.Text += str;
            }


        }
    }
}
