using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projet_S3_POO
{
    public class Dictionnaire
    {
        private List<string> dictionary;
        private int langue;//0 = anglais, 1 = français
        private int longeur;
        
        public Dictionnaire(int langue, int longeur)
        {
            this.langue = langue;
            this.longeur = longeur;
            dictionary = AddAllWords(longeur); 
        }
        
        public void Add(string mot)
        {
            if (mot.Length == longeur)
            {
                dictionary.Add(mot);
            }
        }

        public override string ToString()
        {
            return "Le dictionnaire contient " + dictionary.Count + " mots de " + longeur + " lettres en " + (langue == 0 ? "anglais" : "français");
        }
        /// <summary>
        /// Return a list of all the words in a specified dictionary
        /// </summary>
        /// <param name="longeur"></param> The length of the words
        /// <returns></returns>
        public List<string> AddAllWords(int longeur)
        {
            var term = new List<string>();
            if (langue == 0)
            {
                var ligne = ReadFile(@"../../MotsAnglais.txt").ToArray();
                var readligne = ligne[(2*longeur)-3];
                var dicofinal = readligne.Split(' ').ToList();
                term = dicofinal;
            }
            else
            {
                var ligne = ReadFile(@"../../MotsFrançais.txt").ToArray();
                var readligne = ligne[(2*longeur)-3];
                var dicofinal = readligne.Split(' ').ToList();
                term = dicofinal;
            }
            return term;
        }
        /// <summary>
        /// Will read a file and return a list of string
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="IOException"></exception>
        public static IEnumerable<string> ReadFile(string path)
        {
            var lignes = new Stack<string>();
            try
            {
                using var sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()!) != null)
                {
                    lignes.Push(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Le fichier n'as pas pu être lu, veuillez réessayer");
                Console.WriteLine(e.Message);
                throw new IOException();
            }

            return lignes.ToArray().Reverse();
        }
        
        public string Get(int index)
        {
            return dictionary[index];
        }
        
        public int Count()
        {
            return dictionary.Count;
        }  
          
        public int Langue
        {
            get { return langue; }
        }
        
        public int Longeur
        {
            get { return longeur; }
        }
        /// <summary>
        /// Display the dictionary
        /// </summary>
        /// <returns></returns>
        public string Display()
        {
            string str = "";
            foreach (var mot in dictionary)
            {
                str += mot + " ";
            }
            return str;
        }
        /// <summary>
        /// Search a word in the dictionary 
        /// </summary>
        /// <param name="word"></param> word:The word to search
        /// <returns></returns>
        public bool RechDichoRecursif(string word)
        {
            if (word.Length != longeur)
            {
                return false;
            }
            else
            {
                int longueur = word.Length;
                int max = longueur - 1;
                int milieu = (0 + max) / 2;
                if (word == Get(milieu))
                {
                    return true;
                }
                else
                {
                    if (word.CompareTo(Get(milieu)) > 0)
                    {
                        for (int i = milieu; i < longueur; i++)
                        {
                            if (word == Get(i))
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        for (int i = milieu; i >= 0; i--)
                        {
                            if (word == Get(i))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}