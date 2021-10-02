using System;
  
namespace VigenereCipher
{  
    class VigenereCipher
	{
		public static string Encrypt(string key, string text)
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

		public static string Decrypt(string key, string text)
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
