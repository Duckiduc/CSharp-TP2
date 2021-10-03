using System;
  
namespace CSharp_TP2
{  
    class VigenereCipher
	{
		// Key must be a alpha string
		public static string Exec(string input, string type, string key) 
		{
            try 
			{
                string result;
                if(type == "Encrypt") {              
                    result = VigenereCipher.Encrypt(input, key);
                } else {
                    result = VigenereCipher.Decrypt(input, key);
                } 
                return result;
            } 
            catch (Exception exc) 
			{
				// MessageBox.Show("Error : " + exc);
                return "Error";
            }
        }

		public static string Encrypt(string text, string key)
		{
			string EncryptedText = string.Empty;
			for (int i = 0; i < text.Length; i++)
			{
				if (!char.IsLetter(text[i]))
				{
					EncryptedText += text[i];
				}
				else
				{
					if (char.IsUpper(text[i]))
					{
						char ShiftedLetter = (char)((((text[i] + key[i % key.Length] - 97) - 65) % 26) + 65);
						EncryptedText += ShiftedLetter;
					}
					else
					{
						char ShiftedLetter = (char)((((text[i] + key[i % key.Length] - 97) - 97) % 26) + 97);
						EncryptedText += ShiftedLetter;
					}
				}
			}
			return EncryptedText;
		}

		public static string Decrypt(string text, string key)
		{
			string DecryptedText = string.Empty;
			for (int i = 0; i < text.Length; i++)
			{
				if (!char.IsLetter(text[i]))
				{
					DecryptedText += text[i];
				}
				else
				{
					if (char.IsUpper(text[i]))
					{
						char ShiftedLetter = (char)((((text[i] - (key[i % key.Length] - 97)) - 65) % 26 + 26) % 26 + 65);
						DecryptedText += ShiftedLetter;
					}
					else
					{
						char ShiftedLetter = (char)((((text[i] - (key[i % key.Length] - 97)) - 97) % 26 + 26) % 26 + 97);
						DecryptedText += ShiftedLetter;
					}
				}
			}
			return DecryptedText;
		}
	}
}
