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

namespace IndovinaNumero
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numDaIndovinare, tentativi, tentatifiEseguiti;
        //livelli
        int facile = 15, intermedio = 10, difficile = 5;

        
        public MainWindow()
        {
            InitializeComponent();
            inizializzazione();
        }

        private void inizializzazione(){
            btGioca.IsEnabled = false;
            lbTesto.Content = "Sfida il computer e indovina il numero compreso tra 1 e 100";
            rbIntermedio.IsChecked = true;
            lbTentativi.Content = intermedio.ToString();
            tbxNumero.Text = "";
            lbNumeroPrecedente.Content = "";
        }

        private void btInizia_Click(object sender, RoutedEventArgs e)
        {
            numDaIndovinare = generateNumber();
            if (rbFacile.IsChecked == true)
                tentativi = facile;
            if (rbIntermedio.IsChecked == true)
                tentativi = intermedio;
            if (rbDifficile.IsChecked == true)
                tentativi = difficile;

            lbTentativi.Content = tentativi;
            tentatifiEseguiti = 0;

            pbTentativi.Maximum = tentativi;
            btGioca.IsEnabled = true;
        }

        private void btGioca_Click(object sender, RoutedEventArgs e)
        {
            int numero;

            if (int.TryParse(tbxNumero.Text, out numero) == false)
            {
                MessageBox.Show("Errore nell'inserimento del numero");
                tbxNumero.Text = "";
                tbxNumero.Focus();
                return;
            }

            if (numero == numDaIndovinare)
            {
                MessageBox.Show("Hai VINTO!!!");
                return;
            }
            if (numero < numDaIndovinare)
                MessageBox.Show("                RIPROVA!!\nNumero troppo piccolo");
            else
                MessageBox.Show("                RIPROVA!!\nNumero troppo grande");

            //tentativiFatti++;

            lbTentativi.Content = --tentativi;
            pbTentativi.Value = tentativi;

            //MessageBox.Show("Tentativi:" + tentativi);

            if (tentatifiEseguiti == tentativi)
            {
                MessageBox.Show("Spiacente, hai perso! Il numero da indovinare era " + numDaIndovinare);
                btGioca.IsEnabled = false;
            }

            lbNumeroPrecedente.Content = "Il numero inserito precedentemente è " + tbxNumero.Text;
            tbxNumero.Clear(); 

        }

        private int generateNumber()
        {
            int numero = 0;
            //generazione del numero da indovinare, compreso fra 1 e 100
            Random rd = new Random();
            numero = rd.Next(1, 101);
            return numero;
        }
    }
}
