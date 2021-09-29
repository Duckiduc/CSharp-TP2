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
            var method = methodBox.Text;

            // Encryption or Decryption Text Box
            var type = typeBox.Text;

            // Key content
            var key = keyBox.Text;

            // Rich Text Box input
            TextRange richTextBoxInput = new TextRange(inputText.Document.ContentStart, inputText.Document.ContentEnd);
            var input = richTextBoxInput.Text;

            // Rich Text Box output
            TextRange richTextBoxOutput = new TextRange(outputText.Document.ContentStart, outputText.Document.ContentEnd);
            var output = richTextBoxOutput.Text;

            // Check if one the needed value is empty or not
            var message = "You selected" + method + " Method ! \nYour key is : " + key + "\nYour input is : " + input ;

            switch (method) {
                case "Caesar Cipher": 
                    // Call Caeser Cipher Method : Param needed input key method
                    // Check if the input can be parsed
                    try {
                        if(type == "Encrypt") {
                            MessageBox.Show("Your result is : " + CaesarCipher.Encrypt(input, Int32.Parse(key)));
                        } else {
                            MessageBox.Show("Your result is : " + CaesarCipher.Decrypt(input, Int32.Parse(key)));
                        }
                        
                    } catch (Exception exc) {
                        if (exc.GetType().IsAssignableFrom(typeof(System.FormatException))) {
                            MessageBox.Show("Please use a digit key !");
                        } else {
                            MessageBox.Show("An error occured ! Try again !");
                        }
                    }
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
