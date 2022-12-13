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
        
        
        public Jeu(int lang, int difficulty)
        {
            joueur1 = new Joueur();
            joueur2 = new Joueur();
            plateau = new Plateau(difficulty, lang);
            archive = new List<Plateau>();
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
                Console.WriteLine("      " + "Il vous reste " + (DateTime.Compare(end,DateTime.Now)) + " secondes");
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
                    if (DateTime.Now >= end)
                    {
                        currentPlayer = 2;
                    }
                    joueur1.AddScore(mot.Length);
                    joueur1.AddWord(mot);
                    Console.WriteLine("      "+"Vous avez trouvé un mot !");
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
                    if (DateTime.Now >= end)
                    {
                        currentPlayer = 1;
                    }
                    joueur2.AddScore(mot.Length);
                    joueur2.AddWord(mot);
                    Console.WriteLine("      "+"Vous avez trouvé un mot !");
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

                Console.WriteLine("");
                Console.Write("      "+"Appuyez sur une touche pour continuer votre tours");
                Console.ReadKey();
                break;
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
            DateTime end = DateTime.Now.AddMinutes(15);
            while (DateTime.Now < end &&
                   (joueur1.wordsFound.Count() + joueur2.wordsFound.Count() < plateau.WorldList.Count))
            {
                Turn();
            }
            Console.WriteLine("Le jeu est terminé !");
            Console.WriteLine("Le joueur 1 a trouvé " + joueur1.wordsFound.Count() + " mots");
            Console.WriteLine("Le joueur 2 a trouvé " + joueur2.wordsFound.Count() + " mots");
            if (joueur1.Score > joueur2.Score) Console.WriteLine("Le joueur 1 a gagné !");
            else if (joueur1.Score < joueur2.Score) Console.WriteLine("Le joueur 2 a gagné !");
            else Console.WriteLine("Egalité !");
            
        }

        public static void Timer()
        {
            //fais moi un programme qui affiche un timer en c# à une ligne donnée sans modifier le reste
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