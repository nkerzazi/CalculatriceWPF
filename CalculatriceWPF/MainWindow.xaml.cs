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

namespace CalculatriceWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Double resultCalcul = 0;
        string typeOperation = "";
        bool isOperationCliked = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bouttonChiffre_Click(object sender, RoutedEventArgs e)
        {
            if ((txt_Resultat.Text == "0") || (isOperationCliked))
                txt_Resultat.Clear();


            Button b = (Button)sender;

            if (b.Content.ToString() == ",")
            {
                if (!txt_Resultat.Text.Contains(","))
                {
                    txt_Resultat.Text += b.Content.ToString();
                    labelCurrentOperation.Content = txt_Resultat.Text;
                }
                
            }
            else
            {
                txt_Resultat.Text += b.Content.ToString();
                labelCurrentOperation.Content += b.Content.ToString();

            }


        }

        private void btn_InvSigne_Click(object sender, RoutedEventArgs e)
        {
            if (!txt_Resultat.Text.Contains("-"))
                txt_Resultat.Text = "-" + txt_Resultat.Text;
            else
                txt_Resultat.Text = txt_Resultat.Text.Substring(1, txt_Resultat.Text.Length-1);
        }

        private void Operateur_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (resultCalcul !=0)
            {
                typeOperation = b.Content.ToString();
                isOperationCliked = true;
                labelCurrentOperation.Content += typeOperation;
            }
            else
            {
                typeOperation = b.Content.ToString();
                resultCalcul = Double.Parse(txt_Resultat.Text);
                labelCurrentOperation.Content = resultCalcul + " " + typeOperation; 
                isOperationCliked = true;
            }
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            txt_Resultat.Text = "0";
            labelCurrentOperation.Content = "";
            resultCalcul = 0;
            typeOperation = "";
            isOperationCliked = false;

        }

        private void egale_Click(object sender, RoutedEventArgs e)
        {
            switch(typeOperation)
            {
                case "+":
                    txt_Resultat.Text = (resultCalcul + Double.Parse(txt_Resultat.Text)).ToString();
                    break;
                case "-":
                    txt_Resultat.Text = (resultCalcul - Double.Parse(txt_Resultat.Text)).ToString();
                    break;
                case "*":
                    txt_Resultat.Text = (resultCalcul * Double.Parse(txt_Resultat.Text)).ToString();
                    break;
                case "/":
                    txt_Resultat.Text = (resultCalcul / Double.Parse(txt_Resultat.Text)).ToString();
                    break;

                //default:
                //    break;
            }
            resultCalcul = Double.Parse(txt_Resultat.Text);
            labelCurrentOperation.Content += "=" + resultCalcul;


        }
    }
}
