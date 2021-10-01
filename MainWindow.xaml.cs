﻿using System;
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
            if(!Utils.isInputValid(input)) {
                MessageBox.Show(" Your input must contain only alpha characters ! ");
                return;
            } else if (!Utils.isTypeValid(type)) {
                MessageBox.Show(" Please select a valid type !");
                return;
            }

            outputText.Document.Blocks.Clear();

            switch (method) {
                case "Caesar Cipher": 
                    if (!Utils.isKeyParsable(key)) {
                        MessageBox.Show(" Your key must be a digit !");
                        break;
                    }
                    outputText.Document.Blocks.Add(new Paragraph(new Run(CaesarCipher.Exec(input, type, key))));
                    break;
                case "Vigenere Cipher": 
                    // Call Vigenere Cipher Method
                    if (!Utils.isKeyValidString(key)) {
                        MessageBox.Show(" Your key must be a digit !");
                        break;
                    }
                    outputText.Document.Blocks.Add(new Paragraph(new Run(CaesarCipher.Exec(input, type, key))));
                    break;
                case "DES Encryption": 
                    // Call DES Encryption Method
                    outputText.Document.Blocks.Add(new Paragraph(new Run(CaesarCipher.Exec(input, type, key))));
                    break;
                default: 
                    MessageBox.Show("Invalid Method");
                    break;              
            }
        }
    }
}
