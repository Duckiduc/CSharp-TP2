using System;
  
namespace CSharp_TP2
{  
    class Utils
	{    
        public static bool isInputInvalid(string input) {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    return true;
               
                }
            }
            return false;
        }

        public static bool isKeyParsable(string key) {
            int number;
            return int.TryParse(key, out number);
        }

        public static bool isTypeInvalid(string st) {
            if((st == "Encrypt") ^ (st == "Decrypt")) {
                return false;
            } 
            
            return true;
        }
    } 
}
