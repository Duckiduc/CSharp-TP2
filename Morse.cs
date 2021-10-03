using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

					
public class Program
{
    static Dictionary<char, String> morseCode = new Dictionary<char, String>()
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
    static String encrypt(String input)
    {
        String result = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            result += " ";
            if (morseCode.ContainsKey(input[i]))
            {
                result += morseCode[input[i]];
            }
        }
        return result;
    }
    static String decrypt(String input)
    {
        String[] words = input.Split('/');
        String result = string.Empty;

        for (int i = 0; i < words.Length; i++)
        {
            String[] letters = words[i].Split(' ');

            for(int j = 0; j<letters.Length;j++)
            {
                result += morseCode.FirstOrDefault(x => x.Value == letters[j]).Key;
            }
            result += " ";
            Console.Write(result);
        }
        return result;
    }
	
}