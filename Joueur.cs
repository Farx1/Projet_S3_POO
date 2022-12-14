using System;
using System.Collections.Generic;

namespace Projet_S3_POO
{
    public class Joueur
    {
        private string name;
        public List<string> wordsFound;
        private string[] history;
        

        public Joueur()
        {
            wordsFound = new List<string>();
            Score = 0;
        }
        
        
        public int Score { get; private set; }

        public string[] History
        {
            get => history;
            set => history = value;
        }
        /// <summary>
        /// Add the score to the player's score
        /// </summary>
        /// <param name="score"></param>
        public void AddScore(int score)
        {
            this.Score += score;
        }
        /// <summary>
        /// Add a word to the player's list of words found
        /// </summary>
        /// <param name="word"></param>
        public void AddWord(string word)
        {
            wordsFound.Add(word);
        }
        /// <summary>
        /// Add a a History to the player's list of History
        /// </summary>
        /// <param name="word"></param>
        public void AddHistory(string word)
        {
            Array.Resize(ref history, history.Length + 1);
            history[history.Length - 1] = word;
        }
        /// <summary>
        /// 
        /// </summary>
        public void DisplayScore()
        {
            Console.Write(Score);
        }

        public void DisplayWordsfound()
        {
            Console.WriteLine("Mots trouvés : ");
            for (int i = 0; i < wordsFound.Count; i++)
            {
                Console.WriteLine(wordsFound[i]);
            }
        }

        public void DisplayHistory()
        {
            Console.WriteLine("Historique : ");
            for (int i = 0; i < history.Length; i++)
            {
                Console.WriteLine(history[i]);
            }
        }
        
        public override string ToString()
        {
            return "Joueur " + this.name + " a un score de " + this.Score + " points.";
        }
    }
}