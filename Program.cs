using System;

namespace Projet_S3_POO
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("\n"+"\n");
            /*Console.WriteLine("      ███╗░░░███╗ ███████╗ ██╗░░░░░ ███╗░░░███╗ ░█████╗░ ████████╗"+"\n"+
                                "      ████╗░████║ ██╔════╝ ██║░░░░░ ████╗░████║ ██╔══██╗ ╚══██╔══╝"+"\n"+
                                "      ██╔████╔██║ █████╗░░ ██║░░░░░ ██╔████╔██║ ██║░░██║ ░░░██║░░░"+"\n"+ 
                                "      ██║╚██╔╝██║ ██╔══╝░░ ██║░░░░░ ██║╚██╔╝██║ ██║░░██║ ░░░██║░░░"+"\n"+ 
                                "      ██║░╚═╝░██║ ███████╗ ███████╗ ██║░╚═╝░██║ ╚█████╔╝ ░░░██║░░░"+"\n"+ 
                                "      ╚═╝░░░░░╚═╝ ╚══════╝ ╚══════╝ ╚═╝░░░░░╚═╝ ░╚════╝░ ░░░╚═╝░░░"+"\n"+
                                "      ____________________________________________________________"+"\n");
            */
            
            #region Ecriture MELMOT
            Console.ForegroundColor = ConsoleColor.Red;Console.Write("      ███╗░░░███╗");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;Console.Write(" ███████╗ ");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;Console.Write("██╗░░░░░");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;Console.Write(" ███╗░░░███╗");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;Console.Write(" ░█████╗░");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;Console.Write(" ████████╗");Console.ResetColor();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;Console.Write("      ████╗░████║");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;Console.Write(" ██╔════╝ ");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;Console.Write("██║░░░░░");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;Console.Write(" ████╗░████║");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;Console.Write(" ██╔══██╗");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;Console.Write(" ╚══██╔══╝");Console.ResetColor();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;Console.Write("      ██╔████╔██║");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;Console.Write(" █████╗░░ ");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;Console.Write("██║░░░░░");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;Console.Write(" ██╔████╔██║");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;Console.Write(" ██║░░██║");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;Console.Write(" ░░░██║░░░");Console.ResetColor();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;Console.Write("      ██║╚██╔╝██║");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;Console.Write(" ██╔══╝░░ ");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;Console.Write("██║░░░░░");Console.ResetColor(); 
            Console.ForegroundColor = ConsoleColor.Cyan;Console.Write(" ██║╚██╔╝██║");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;Console.Write(" ██║░░██║");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;Console.Write(" ░░░██║░░░");Console.ResetColor();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;Console.Write("      ██║░╚═╝░██║");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;Console.Write(" ███████╗ ");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;Console.Write("███████╗");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;Console.Write(" ██║░╚═╝░██║");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;Console.Write(" ╚█████╔╝");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;Console.Write(" ░░░██║░░░");Console.ResetColor();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;Console.Write("      ╚═╝░░░░░╚═╝");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;Console.Write(" ╚══════╝ ");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;Console.Write("╚══════╝");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;Console.Write(" ╚═╝░░░░░╚═╝");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;Console.Write(" ░╚════╝░");Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;Console.Write(" ░░░╚═╝░░░");Console.ResetColor();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;Console.Write("      ____________________________________________________________"+"\n");
            Console.ResetColor();
            #endregion
            
            Functions.InitRandom();
            //Menu for choosing language (English or French) and difficulty from 1 to 5
            Console.Write("      ");
            Console.Write("Choose your language 0 for English and 1 for French: ");
            int language = Convert.ToInt32(Console.ReadLine());
            Console.Write("      "); 
            Console.Write("Choose your difficulty (1 to 5): ");
            int difficulty = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n"+"      "+"You chose difficulty " + difficulty+"\n");
            Console.Write("      ");
            Console.Write("Press any key to continue: ");
            Console.ReadKey();
            Console.Clear();
            var jeu = new Jeu(language, difficulty);
            jeu.Start();
        }
    }
}