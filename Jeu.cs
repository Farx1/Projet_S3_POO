using System;
using System.Collections.Generic;
using System.Linq;

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
            plateau.DisplayGridWithAnswers();//Can also use DisplayGridWithAnswers() to see the answers
            DateTime end = DateTime.Now.AddSeconds(60);
            while (DateTime.Now < end)
            {
                Console.WriteLine("Tour du joueur " + currentPlayer);
                Console.WriteLine("La case en haut à gauche est la case (0,0)");
                Console.WriteLine("Merci de rentrer un mot:");
                string mot = Console.ReadLine();
                mot = mot?.ToUpper();
                Console.WriteLine("Entrez la ligne de la première lettre : ");
                int y = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                Console.WriteLine("Entrez la colonne de la première lettre : ");
                int x = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                Console.WriteLine("Entrez la direction du mot (N S E W etc...: ");
                string direction = Console.ReadLine();
                if(plateau.CheckWordPosition(x, y, mot, direction)) @plateau.MarkWord(x, y, mot, direction);
                else
                {
                    Console.WriteLine("Le mot n'est pas valide");
                    break;
                }
                Console.WriteLine("Vous avez trouvé un mot !");
                if (currentPlayer == 1)
                {
                    currentPlayer = 2;
                    joueur1.AddScore(mot.Length);
                    joueur1.AddWord(mot);
                }
                else
                {
                    currentPlayer = 1;
                    joueur2.AddScore(mot.Length);
                    joueur2.AddWord(mot);
                }
                break;
            }
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
    }
}