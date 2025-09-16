using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Taschenrechner
{
    /// <summary>
    /// Logik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double zahl1 = 0;
        private double zahl2 = 0;
        private string letzterOperator = "";
        private bool istNeueEingabe = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Zahl_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (istNeueEingabe)
            {
                ErgebnisTextBox.Text = "";
                istNeueEingabe = false;
            }
            ErgebnisTextBox.Text += btn.Content.ToString();
        }

        private void Komma_Click(object sender, RoutedEventArgs e)
        {
            if (!ErgebnisTextBox.Text.Contains(","))
            {
                if (ErgebnisTextBox.Text == "")
                    ErgebnisTextBox.Text = "0";
                ErgebnisTextBox.Text += ",";
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (double.TryParse(ErgebnisTextBox.Text, out zahl1))
            {
                letzterOperator = btn.Content.ToString();
                istNeueEingabe = true;
            }
        }

        private void Gleich_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ErgebnisTextBox.Text, out zahl2))
            {
                double ergebnis = 0;
                switch (letzterOperator)
                {
                    case "+":
                        ergebnis = zahl1 + zahl2;
                        break;
                    case "-":
                        ergebnis = zahl1 - zahl2;
                        break;
                    case "*":
                        ergebnis = zahl1 * zahl2;
                        break;
                    case "/":
                        if (zahl2 != 0)
                            ergebnis = zahl1 / zahl2;
                        else
                        {
                            ErgebnisTextBox.Text = "Fehler: Division durch 0";
                            istNeueEingabe = true;
                            return;
                        }
                        break;
                }
                ErgebnisTextBox.Text = ergebnis.ToString(CultureInfo.CurrentCulture);
                istNeueEingabe = true;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ErgebnisTextBox.Text = "";
            zahl1 = 0;
            zahl2 = 0;
            letzterOperator = "";
            istNeueEingabe = true;
        }
    }
}