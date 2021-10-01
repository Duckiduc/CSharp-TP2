using System;
  
namespace CSharp_TP2
{  
    class Utils
	{    
        // For all methods
        public static bool isInputValid(string input) {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    return false;
               
                }
            }
            return true;
        }

        // For Caeser Cipher only
        public static bool isKeyParsable(string key) {
            int number;
            return int.TryParse(key, out number);
        }

        // For Vigenere Cipher only
        public static bool isKeyValidString(string key) {
            for (int i = 0; i < key.Length; i++)
            {
                if (char.IsDigit(key[i]))
                {
                    return false;
               
                }
            }
            return true;
        }

        // For all methods 
        public static bool isTypeValid(string st) {
            if((st == "Encrypt") ^ (st == "Decrypt")) {
                return true;
            } 
            
            return false;
        }
    } 
}
