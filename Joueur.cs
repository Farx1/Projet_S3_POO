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

        public void AddScore(int score)
        {
            this.Score += score;
        }
        
        public void AddWord(string word)
        {
            wordsFound.Add(word);
        }

        public void AddHistory(string word)
        {
            Array.Resize(ref history, history.Length + 1);
            history[history.Length - 1] = word;
        }

        public void DisplayScore()
        {
            Console.WriteLine("Score : " + Score);
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