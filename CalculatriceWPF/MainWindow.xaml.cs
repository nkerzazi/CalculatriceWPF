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
        Double resultCalcul = 0;    // variable pour stocker la valeur intermediaire pour le calcul
        string typeOperation = "";  // les operateurs + - * /
        bool isOperationCliked = false; // pour savoir si on est en train de saisir des chiffres apres operateur. exemple 2+?
        public MainWindow()
        {
            InitializeComponent();
        }

        // Cette méthode est appelée par l'evenement click de tous les boutons chiffres et virgule
        private void bouttonChiffre_Click(object sender, RoutedEventArgs e)
        {
            if ((txt_Resultat.Text == "0") || (isOperationCliked)) // si le texte est a 0 OU on est apres un operateur(+ - * /)
                txt_Resultat.Clear();   // effacer le contenu du controle Resultat


            Button b = (Button)sender;  // on recupere l'objet qui a envoyer l'evenement click. On sais que c'est un bouton alors on cast

            if (b.Content.ToString() == ",") // traitement des chiffres décimaux
            {
                if (!txt_Resultat.Text.Contains(",")) // si le chiffre saisi ne contient pas déjà une virgule
                {
                    txt_Resultat.Text += b.Content.ToString(); // ajouter le chiffre saisi au chiffre qui est dans le TextBox
                    labelCurrentOperation.Content = txt_Resultat.Text; // actualiser le contenu du label qui affiche toute l'opération
                }
                
            }
            else // saisi d'un chiffre de 0 a 9
            {
                txt_Resultat.Text += b.Content.ToString();
                labelCurrentOperation.Content += b.Content.ToString();

            }


        }
        // le bouton +/- pour inverser le signe
        private void btn_InvSigne_Click(object sender, RoutedEventArgs e)
        {
            // si le chiffre n'est pas en negatif alors ajoute un signe negatif devant le chiffre
            if (!txt_Resultat.Text.Contains("-"))
               txt_Resultat.Text = "-" + txt_Resultat.Text;
                
            else
            
                // si c'est deja negatif alors enleve le signe -
                txt_Resultat.Text = txt_Resultat.Text.Substring(1, txt_Resultat.Text.Length-1);
            
            resultCalcul *= -1; // inverser aussi le contenu de la variable
        }
        // click sur un des operateurs +  - *  /
        private void Operateur_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (resultCalcul !=0) // si on a deja saisi un chiffre
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

        // initialisation du calcul remettre tout a zero
        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            txt_Resultat.Text = "0";
            labelCurrentOperation.Content = "";
            resultCalcul = 0;
            typeOperation = "";
            isOperationCliked = false;

        }
        // le bouton egale qui calcul les operations de base + - * /
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

                //default: // pas besoin de default ici
                //    break;
            }

            // actualisation de la variable intermediaire avec le resultat du calcul et affichage de l'operation dans le label
            resultCalcul = Double.Parse(txt_Resultat.Text);
            labelCurrentOperation.Content += "=" + resultCalcul;


        }
    }
}
