using System;
using System.Windows;
  
namespace CSharp_TP2
{  
    public class CaesarCipher
	{  
		public static char ShiftLetter(char character, int shift)
		{
			if (!char.IsLetter(character))
			{
				return character;
			} 
			else 
			{
				if (char.IsUpper(character))
				{
					char ShiftedLetter = (char)((((character + shift) - 65) % 26) + 65);
					return ShiftedLetter;
				}
				else
				{
					char ShiftedLetter = (char)((((character + shift) - 97) % 26) + 97);
					return ShiftedLetter;
				}
			}
		}

        public static string Encrypt(string text, int shift) 
		{  
            string ShiftedText = string.Empty;  
			foreach (char character in text)
			{
				ShiftedText += ShiftLetter(character, shift);
			}
			return ShiftedText;
        }
  
		public static string Decrypt(string text, int shift)
		{
			return Encrypt(text, 26 - shift);
		}

		public static string Exec(string input, string type, string key) {
            try 
			{
                string result;
                if(type == "Encrypt") {              
                    result = CaesarCipher.Encrypt(input, Int32.Parse(key));
                } else {
                    result = CaesarCipher.Decrypt(input, Int32.Parse(key));
                } 
                return result;
            } 
            catch (Exception exc) 
			{
                if (exc.GetType().IsAssignableFrom(typeof(System.FormatException))) {
                    // MessageBox.Show("Caesar Cipher key must be a valid digit !");
                    return "Error";
                } else {
                    // MessageBox.Show("An error occured ! Try again !");
                    return "Error";
                }
            }
        }
    }
}
