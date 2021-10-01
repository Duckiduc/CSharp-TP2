using System;
  
namespace CSharp_TP2
{  
    public class Utils
	{    
        // For all methods
        public static bool isValidString(string input) {
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

        // For all methods 
        public static bool isTypeValid(string st) {
            if((st == "Encrypt") ^ (st == "Decrypt")) {
                return true;
            }  
            return false;
        }
    } 
}
