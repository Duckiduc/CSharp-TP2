using System;
  
namespace VigenereCipher
{  
    class VigenereCipher
	{  
		private static bool CheckKey(string key, string text)
        {
            if (key.Length > text.Length)
            {
                return false;
            } 
            else
            {
                return true;
            }
        }

        public static string Encrypt(string key, string text)
        {
            string EncryptedText = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                int letterIndex = (key[i] + text[i]) % 26;
                letterIndex += 'A';
                EncryptedText += (char)letterIndex;
            }
            return EncryptedText;
        }

        public static string Decrypt(string key, string text)
        {
            string DecryptedText = string.Empty;
            for (int i = 0; i < key.Length && i < text.Length; i++)
            {
                int letterIndex = (text[i] - key[i] + 26) % 26;
                letterIndex += 'A';
                DecryptedText += (char)letterIndex;
            }
            return DecryptedText;
        }
    }
}
