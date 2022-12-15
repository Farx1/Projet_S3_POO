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
            
            Console.WriteLine("\n");
            Functions.InitRandom();
            //Menu for choosing language (English or French) and difficulty from 1 to 5
            Console.Write("      "+"Choisissez votre langue (0 pour anglais, 1 pour français) : ");
            int language = Convert.ToInt32(Console.ReadLine());
            Console.Write("      "+"Choisissez la difficulté de la première partie (1-5): ");
            int difficulty = Convert.ToInt32(Console.ReadLine());
            //Console.Write("\n"+"      "+"Vous avez choisis la difficulté: " + difficulty+"\n");
            
            Console.Write("\n"+"      "+"Joueur 1: Entrez votre nom: ");
            string name1 = Console.ReadLine();
            Console.Write("      "+"Vous avez choisis " + name1+" comme nom de joueur.\n");
            
            Console.Write("\n"+"      "+"Joueur 2: Entrez votre nom: ");
            string name2 = Console.ReadLine();
            Console.Write("      "+"Vous avez choisis " + name2+" comme nom de joueur.\n\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("      "+"Appuyez sur une touche pour commencer la partie!");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            var jeu = new Jeu(language, difficulty, name1, name2);
            jeu.Start();
        }
    }
}