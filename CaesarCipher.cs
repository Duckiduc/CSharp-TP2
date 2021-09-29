using System;
  
namespace CSharp_TP2
{  
    class CaesarCipher
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
    }
}
