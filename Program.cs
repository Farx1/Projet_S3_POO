using System;

namespace Projet_S3_POO
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Functions.InitRandom();
            //Menu for choosing language (English or French) and difficulty from 1 to 5
            Console.WriteLine("Choose your language 0 for English and 1 for French");
            int language = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose your difficulty (1 to 5)");
            int difficulty = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You chose difficulty " + difficulty);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            
            
            var jeu = new Jeu(language, difficulty);
            jeu.Start();
        }
    }
}