using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Projet_S3_POO
{
    public class Jeu
    {
        private Joueur joueur1;
        private Joueur joueur2;
        private Plateau plateau;
        private List<Plateau> archive;
        private int turn;
        private int currentPlayer;
        private int langue;
        private int difficulty;
        
        
        public Jeu(int lang, int difficulty)
        {
            joueur1 = new Joueur();
            joueur2 = new Joueur();
            plateau = new Plateau(difficulty, lang);
            archive = new List<Plateau>();
            langue = lang;
            this.difficulty = difficulty;    
        }
        
        public void newGame()
        {
            archive.Add(plateau);
            plateau = new Plateau(difficulty, langue);
            
        }


        /// <summary>
        /// Ask the player for a word, coordinates and direction
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Turn()
        {
            Console.Clear();
            plateau.DisplayGrid();//Can also use DisplayGridWithAnswers() to see the answers
            DateTime end = DateTime.Now.AddMinutes(1);
            while (DateTime.Now < end)
            {
                Console.WriteLine("      "+"Tour du joueur " + currentPlayer);
                Console.Write("      "+"Merci de rentrer un mot: ");
                string mot = Console.ReadLine();
                
                mot = mot?.ToUpper();

                Console.Write("      " + "Entrez la");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" ligne");
                Console.ResetColor();
                Console.Write(" de la première lettre : ");
                int y = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                
                
                
                Console.Write("      " + "Entrez la");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" colonne");
                Console.ResetColor();
                Console.Write(" de la première lettre : ");
                int x = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                
                
                
                Console.Write("      "+"Entrez la direction du mot (N S E W etc...): ");
                string direction = Console.ReadLine();
                Console.WriteLine();
                if (plateau.CheckWordPosition(x, y, mot, direction)&& currentPlayer == 1)
                {
                    @plateau.MarkWord(x, y, mot, direction);
                    
                    joueur1.AddScore(mot.Length);
                    joueur1.AddWord(mot);
                    Console.WriteLine("      "+"Vous avez trouvé un mot Joueur 1 !");
                    Console.Write("      "+"Appuyez sur une touche pour continuer");
                    Console.ReadKey();
                    Console.WriteLine("");


                }
                else if(currentPlayer !=2)
                {
                    Console.WriteLine("      "+"Le mot n'est pas valide");
                    Console.Write("      "+"Appuyez sur une touche pour continuer");
                    Console.ReadKey();
                    break;
                }
                
                if (plateau.CheckWordPosition(x, y, mot, direction)&& currentPlayer == 2)
                {
                    @plateau.MarkWord(x, y, mot, direction);
                    
                    joueur2.AddScore(mot.Length);
                    joueur2.AddWord(mot);
                    Console.WriteLine("      "+"Vous avez trouvé un mot Joueur 2!");
                    Console.Write("      "+"Appuyez sur une touche pour continuer");
                    Console.ReadKey();
                    Console.WriteLine("");
                }
                else if(currentPlayer != 1)
                {
                    Console.WriteLine("      "+"Le mot n'est pas valide");
                    Console.Write("      "+"Appuyez sur une touche pour continuer");
                    Console.ReadKey();
                    break;
                }
                break;
            }
            if (joueur1.wordsFound.Count() == plateau.WorldList.Count)
            {
                joueur1.AddScore(3);
            }
            if (joueur2.wordsFound.Count() == plateau.WorldList.Count)
            {
                joueur2.AddScore(3);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("      "+"Le temps est écoulé");
            Console.ResetColor();
            turn++;
        }
        /// <summary>
        /// Initialize the game and start the turns until the end of the game
        /// </summary>
        public void Start()
        {
            currentPlayer = 1;
            DateTime end = DateTime.Now.AddMinutes(10);
            int i = 0;
            while (i<=6)
            {
                while (DateTime.Now < end && (joueur1.wordsFound.Count() < plateau.WorldList.Count))
                {
                    DateTime start = DateTime.Now.AddSeconds(60*difficulty);
                    while (start > DateTime.Now)
                    {
                        Turn();
                    }
                }
                Console.Clear();
                currentPlayer = 2;
                newGame();
                while (DateTime.Now < end && (joueur2.wordsFound.Count() < plateau.WorldList.Count))
                {
                    DateTime start = DateTime.Now.AddSeconds(60*difficulty);
                    while (start > DateTime.Now)
                    {
                        Turn();
                    }
                }
                if(DateTime.Now>= end)break;
                if(i!=5)difficulty++;
            }
            
            Console.WriteLine("      "+"Le jeu est terminé !");
            Console.WriteLine("      "+"Le joueur 1 a trouvé " + joueur1.wordsFound.Count() + " mots" + " pour un score de " + joueur1.Score);
            Console.WriteLine("      "+"Le joueur 2 a trouvé " + joueur2.wordsFound.Count() + " mots" + " pour un score de " + joueur2.Score);
            if (joueur1.Score > joueur2.Score)
            {
                Console.WriteLine("      "+"Le joueur 1 a gagné !");
            }
            else if (joueur1.Score < joueur2.Score)
            {
                Console.WriteLine("      "+"Le joueur 2 a gagné !");
            }
            else Console.WriteLine("      "+"Egalité !");
            
        }

        public static void Timer()
        {
            DateTime end = DateTime.Now.AddMinutes(1);
            while (DateTime.Now < end)
            {
                var test = Console.CursorTop;
                Console.SetCursorPosition(6, test+1);
                Console.Write("Il vous reste " + (end - DateTime.Now).Seconds + " secondes");
                Thread.Sleep(1000);
                Console.SetCursorPosition(6, test-1);
            }
            Console.WriteLine("Le temps est écoulé");
            
        }
    }
}