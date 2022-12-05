using System;

namespace Projet_S3_POO
{
    public class Joueur
    {
        private string name; 
        private string[] wordsfound;
        private int score;
        private string[] history;
        
        public Joueur(string name, string[] wordsfound, int score)
        {
            this.name = name;
            this.wordsfound = wordsfound;
            this.score = score;
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string[] Wordsfound
        {
            get { return wordsfound; }
            set { wordsfound = value; }
        }
        
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        
        public string[] History
        {
            get { return history; }
            set { history = value; }
        }

        public void AddScore(int score)
        {
            this.score += score;
        }

        public void AddWordsfound(string word)
        {
            Array.Resize(ref wordsfound, wordsfound.Length + 1);
            wordsfound[wordsfound.Length - 1] = word;
        }

        public void AddHistory(string word)
        {
            Array.Resize(ref history, history.Length + 1);
            history[history.Length - 1] = word;
        }

        public void DisplayScore()
        {
            Console.WriteLine("Score : " + score);
        }

        public void DisplayWordsfound()
        {
            Console.WriteLine("Mots trouvés : ");
            for (int i = 0; i < wordsfound.Length; i++)
            {
                Console.WriteLine(wordsfound[i]);
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
            return "Joueur " + this.name + " a un score de " + this.score + " points.";
        }
    }
}