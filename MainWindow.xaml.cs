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

namespace CSharp_TP2
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

        private void Button_Click(object sender, RoutedEventArgs e) {
            
            // Encryption Method content
            var method = comboBox.Text;

            // Key content
            var key = tbSettingText.Text;

            // Rich Text Box input
            TextRange richTextBoxInput = new TextRange(inputText.Document.ContentStart, inputText.Document.ContentEnd);
            var input = richTextBoxInput.Text;

            // Rich Text Box output
            TextRange richTextBoxOutput = new TextRange(resultText.Document.ContentStart, resultText.Document.ContentEnd);
            var output = richTextBoxOutput.Text;

            // Check if one the needed value is empty or not
            var message = "You selected" + method + " Method ! \nYour key is : " + key + "\nYour input is : " + input ;

            switch (method) {
                case "Caesar Cipher": 
                    // Call Caeser Cipher Method : Param needed input key method
                    MessageBox.Show(message);
                    break;
                case "Vigenere Cipher": 
                    // Call Vigenere Cipher Method
                    MessageBox.Show(message);
                    break;
                case "DES Encryption": 
                    // Call DES Encryption Method
                    MessageBox.Show(message);
                    break;
                default: 
                    MessageBox.Show("Invalid Method");
                    break;
                
            }

        }
    }
}
