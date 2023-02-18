using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Old_Phone
{   
    /// <summary>
    /// This class provides a way to convert Numpad Keypresses into human readable text.
    /// </summary>
    public class Old_Phone_Converter
    {

        public Old_Phone_Converter() { }

        /// <summary>
        /// Provides a Dictionary that mimics an old phone number pad.
        /// </summary>
        /// <returns>Dictionary that mimics an old phone number pad.</returns>
        /// <remarks>Number pad is according to the image in the challenge description.</remarks>
        private static IDictionary<char, char[]> GetNumPad()
        {
            IDictionary<char, char[]> numPad = new Dictionary<char, char[]>();
            numPad.Add('1', new char[] { '&', '\'', '('});
            numPad.Add('2', new char[] { 'A', 'B', 'C' });
            numPad.Add('3', new char[] { 'D', 'E', 'F' });
            numPad.Add('4', new char[] { 'G', 'H', 'I' });
            numPad.Add('5', new char[] { 'J', 'K', 'L' });
            numPad.Add('6', new char[] { 'M', 'N', 'O' });
            numPad.Add('7', new char[] { 'P', 'Q', 'R','S'});
            numPad.Add('8', new char[] { 'T', 'U', 'V' });
            numPad.Add('9', new char[] { 'W', 'X', 'Y','Z'});
            numPad.Add('0', new char[] { ' ', '\'', '(' });
            return numPad;
        }

        /// <summary>
        /// Takes in string of button presses and returns a human readable string.
        /// </summary>
        /// <param name="input">String of button presses.</param>
        /// <returns>Human readable string.</returns>
        /// <exception>Throws invalid input error.</exception>
        public static string OldPhonePad(String input)
        {
            if (!InputIsValid(input))
            {
                Console.Error.WriteLine("ERROR: INVALID INPUT! Only Numberals, Spaces and the # symbol are allowed");
                return "Fix input and try again";

            }
            List<string> tokens = TokenizeString(input);
            
            StringBuilder decodedText = new StringBuilder();
            foreach(string t in tokens)
            {
                if (t[0] == '*')
                {
                    decodedText.Remove(decodedText.Length - t.Length, t.Length); // backspace
                }else if (t[0]=='#')
                {
                    break; //pressed send
                }
                else if(t[0]==' ')
                {
                    continue;
                }
                else
                {
                    if(t[0]=='7' || t[0] == '9')
                    {
                        decodedText.Append(SetReferencedString(t, 4));
                    }
                    else
                    {
                        decodedText.Append(SetReferencedString( t, 4));
                    }
                }
            }
            return decodedText.ToString();
        }

        /// <summary>
        /// Converts same-number string tokens into alphabetical string using the numpad
        /// </summary>
        /// <param name="prompt">Same-number string token. </param>
        /// <param name="numLimit">Limit of presses that a key can take before traversing all character options.</param>
        /// <returns>Alphabetical string.</returns>
        private static string SetReferencedString(string prompt, int numLimit)
        {
            IDictionary<char, char[]> numPad = GetNumPad();
            int remainingClicks = prompt.Length % numLimit;
            char buttonNum = prompt[0];
            int epochs = prompt.Length / numLimit;
            StringBuilder typed = new StringBuilder();
            if (epochs == 1)
            {
                typed.Append(numPad[buttonNum][prompt.Length-1]);
            }
            else
            {
                for (int i = 0; i < epochs-1; i++)
                {
                    typed.Append(numPad[buttonNum][numLimit - 1]);
                }
                typed.Append(numPad[buttonNum][remainingClicks-1]);
            }
            return typed.ToString();
        }

        /// <summary>
        /// Splits a string into same-character tokens.
        /// </summary>
        /// <param name="input">String of button presses.</param>
        /// <returns>List of token strings.</returns>
        private static List<string> TokenizeString(string input)
        {
            List<string> tokens = new List<string>();
            if (string.IsNullOrWhiteSpace(input))
            {
                return tokens;
            }

            char lastChar = input[0];
            StringBuilder currentToken = new StringBuilder(lastChar.ToString());
            for (int i = 1; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar == lastChar)
                {
                    currentToken.Append(currentChar);
                }
                else
                {
                    tokens.Add(currentToken.ToString());
                    currentToken.Clear();
                    currentToken.Append(currentChar);
                    lastChar = currentChar;
                }
            }
            tokens.Add(currentToken.ToString());

            return tokens;
        }


        /// <summary>
        /// Validates string of button presses
        /// </summary>
        /// <param name="input">String of button presses</param>
        /// <returns>True if input is valid and False if not.</returns>
        private static bool InputIsValid(string input) 
        {
            const string InputPattern = @"^[0-9# *]+$"; //Only allows for numbers spaces and the pound symbol (#)
            bool v = Regex.IsMatch(input, InputPattern, RegexOptions.IgnoreCase);
            return v;
        }
        
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            
            //Console.WriteLine("Please input the number string input for decoding. (Only Numberals, Spaces and the # symbol are allowed)");
            //string input = Console.ReadLine();
            //Console.WriteLine(Old_Phone_Converter.OldPhonePad(input));
        }
    }
}
