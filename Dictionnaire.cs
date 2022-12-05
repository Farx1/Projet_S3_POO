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

        public string toString()
        {
            return "Le dictionnaire contient " + dictionary.Count + " mots de " + longeur + " lettres en " + (langue == 0 ? "anglais" : "français");
        }

        public List<string> AddAllWords(int longeur)
        {
            var term = new List<string>();
            if (langue == 0)
            {
                var ligne = CatchFile(@"..\..\MotsAnglais.txt").ToArray();
                var readligne = ligne[(2*longeur)-3];
                var dicofinal = readligne.Split(' ').ToList();
                term = dicofinal;
            }
            else
            {
                var ligne = CatchFile(@"..\..\MotsFrançais.txt").ToArray();
                var readligne = ligne[(2*longeur)-3];
                var dicofinal = readligne.Split(' ').ToList();
                term = dicofinal;
            }
            return term;
        }
        public static IEnumerable<string> CatchFile(string path)
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
        
        public override string ToString()
        {
            string str = "";
            foreach (var mot in dictionary)
            {
                str += mot + " ";
            }
            return str;
        }
        
        public bool RechDichoRecursif(string mot)
        {
            if (mot.Length != longeur)
            {
                return false;
            }
            else
            {
                int longueur = mot.Length;
                int min = 0;
                int max = longueur - 1;
                int milieu = (min + max) / 2;
                if (mot == Get(milieu))
                {
                    return true;
                }
                else
                {
                    if (mot.CompareTo(Get(milieu)) > 0)
                    {
                        for (int i = milieu; i < longueur; i++)
                        {
                            if (mot == Get(i))
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        for (int i = milieu; i >= 0; i--)
                        {
                            if (mot == Get(i))
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