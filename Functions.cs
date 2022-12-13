using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projet_S3_POO
{
    public static class Functions
    {
        private static Random rand;
        /// <summary>
        /// Get a random number between min and max
        /// </summary>
        /// <param name="min"></param> Minimum value
        /// <param name="max"></param> Maximum value
        /// <returns></returns>
        public static int GetRandomInt(int min, int max)
        {
            return rand.Next(min, max);
        }
        /// <summary>
        /// Initialize the random number generator
        /// </summary>
        public static void InitRandom()
        {
            rand = new Random();
        }
        /// <summary>
        /// Return a random letter of the alphabet
        /// </summary>
        /// <returns></returns>
        public static char RandomLetter()
        {
            int randomLetter = GetRandomInt(0, 26);
            char letter = Convert.ToChar('a' + randomLetter);
            return char.ToUpper(letter);
        }
        /// <summary>
        /// Clear the console
        /// </summary>
        public static void ClearConsole()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
        }
        /// <summary>
        /// Return inputed words after a specific message
        /// </summary>
        /// <param name="message"></param> Message to display
        /// <returns></returns>
        public static string Prompt(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        /// <summary>
        /// Same function ReadFile as in the dictionary class for debug purposes
        /// </summary>
        /// <param name="path"></param> Path of the file
        /// <returns></returns>
        /// <exception cref="IOException"></exception>
        public static IEnumerable<string> ReadFile(string path)
        {
            var lines = new Stack<string>();
            try
            {
                using var sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Push(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                throw new IOException();
                
            }

            return lines.ToArray().Reverse();
        }
        /// <summary>
        /// Write a file with a specific path and content
        /// </summary>
        /// <param name="lines"></param> Content of the file
        /// <param name="path"></param> Path of the file
        /// <exception cref="IOException"></exception>
        public static void WriteFile(IEnumerable<string> lines, string path)
        {
            try
            {
                using var sw = new StreamWriter(path);
                foreach (var line in lines)
                {
                    sw.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured while trying to write file");
                Console.WriteLine(e.Message);
                throw new IOException();
            }
        }
        
    }
}