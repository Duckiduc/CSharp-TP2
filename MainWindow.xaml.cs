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

            // Checks
            if(Utils.isInputInvalid(input)) {
                MessageBox.Show(" Your input must contain only alpha characters ! ");
                return;
            } else if (!Utils.isKeyParsable(key)) {
                MessageBox.Show(" Your key must be a digit !");
                return;
            } else if (Utils.isTypeInvalid(type)) {
                MessageBox.Show(" Please select a valid type !");
                return;
            }

            outputText.Document.Blocks.Clear();

            switch (method) {
                case "Caesar Cipher": 
                    // Call Caeser Cipher Method : Param needed input key method
                    // Check if the input can be parsed
                    try {
                        string result;
                        if(type == "Encrypt") {              
                            result = CaesarCipher.Encrypt(input, Int32.Parse(key));
                        } else {
                            result = CaesarCipher.Decrypt(input, Int32.Parse(key));
                        } 
                        outputText.Document.Blocks.Add(new Paragraph(new Run(result)));
                    } catch (Exception exc) {
                        if (exc.GetType().IsAssignableFrom(typeof(System.FormatException))) {
                            MessageBox.Show("Caesar Cipher key must be a valid digit !");
                        } else {
                            MessageBox.Show("An error occured ! Try again !");
                        }
                    }
                    break;
                case "Vigenere Cipher": 
                    // Call Vigenere Cipher Method
                    break;
                case "DES Encryption": 
                    // Call DES Encryption Method
                    break;
                default: 
                    MessageBox.Show("Invalid Method");
                    break;              
            }
        }
    }
}
