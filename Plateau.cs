using System;
using System.Collections.Generic;

namespace Projet_S3_POO
{
    public class Plateau
    {
        private char[,] plateau;
        private int colonne;
        private int ligne;
        private int niveaudiff;
        private List<string> listeMots;
        
        public Plateau(int niveaudiff,int ligne,int colonne)
        {
            this.colonne = colonne;
            this.ligne = ligne;
            this.niveaudiff = niveaudiff;
            this.plateau = new char[ligne, colonne];
            this.listeMots = new List<string>(); 
        }

        public char[,] DefPlateau()
        {
            
        }

        public override string ToString()
        {
            return "Le tableau est de taille " + ligne+"x"+colonne + " et de niveau de difficulté " + niveaudiff+"et il y a "+listeMots.Count+" mots à trouver.";
        }

        public void ToFile(string nomFile)
        {
            //méthode qui sauvegarde l’instance du plateau dans un fichier .csv
            
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\Projet S3 POO\"+nomFile+".csv"))
            {
                file.Write(this.niveaudiff+";");
                file.Write(this.ligne+";");
                file.Write(this.colonne+";");
                file.Write(this.listeMots.Count);
                for (int i = 0; i < this.listeMots.Count-4; i++)
                {
                    file.WriteLine(";");
                }
                for (int i = 0; i < this.listeMots.Count; i++)
                {
                    file.WriteLine(this.listeMots[i]);
                    if (i != this.listeMots.Count - 1)
                    {
                        file.Write(";");
                    }
                        
                }
            }
        }
    }
}