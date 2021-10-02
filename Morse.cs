using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

					
public class Program
{
	public static void Main()
	{
		   Dictionary<char, String> morseCode = new Dictionary<char, String>()
            {
                {'A' , ".-"},
                {'B' , "-..."},
                {'C' , "-.-."},
                {'D' , "-.."},
                {'E' , "."},
                {'F' , "..-."},
                {'G' , "--."},
                {'H' , "...."},
                {'I' , ".."},
                {'J' , ".---"},
                {'K' , "-.-"},
                {'L' , ".-.."},
                {'M' , "--"},
                {'N' , "-."},
                {'O' , "---"},
                {'P' , ".--."},
                {'Q' , "--.-"},
                {'R' , ".-."},
                {'S' , "..."},
                {'T' , "-"},
                {'U' , "..-"},
                {'V' , "...-"},
                {'W' , ".--"},
                {'X' , "-..-"},
                {'Y' , "-.--"},
                {'Z' , "--.."},
                {'0' , "-----"},
                {'1' , ".----"},
                {'2' , "..---"},
                {'3' , "...--"},
                {'4' , "....-"},
                {'5' , "....."},
                {'6' , "-...."},
                {'7' , "--..."},
                {'8' , "---.."},
                {'9' , "----."},
			   	{' ' , "/"},
            };
			Console.WriteLine("Do you want to encode or decode ?");
			if(Console.ReadLine()=="decode"){
				Console.WriteLine("Write your secret message to decode :");
            	String[] words = Console.ReadLine().Split('/');

				for (int i = 0; i < words.Length; i++)
				{
					String[] letters = words[i].Split(' ');

					for(int j = 0; j<letters.Length;j++){
						Console.Write(morseCode.FirstOrDefault(x => x.Value == letters[j]).Key);
					}
					Console.Write(" ");
				}
			}else{
				Console.WriteLine("Write your secret message to encode :");
            	String input = Console.ReadLine().ToUpper();
				for (int i = 0; i < input.Length; i++)
				{
					Console.Write(' ');
					if (morseCode.ContainsKey(input[i]))
						Console.Write(morseCode[input[i]]);
				}
			}
	}
}