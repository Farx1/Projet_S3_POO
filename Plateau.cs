using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Projet_S3_POO
{
    public class Plateau
    {
        private char[,] grid;
        private char[,] wordGrid;
        private bool[,] foundGrid;
        private int width;
        private int height;
        private int difficultyLevel;
        private List<string> worldList;

        public char[,] Grid
        {
            get => grid;
            set => grid = value;
        }

        public char[,] WordGrid
        {
            get => wordGrid;
            set => wordGrid = value;
        }

        public bool[,] FoundGrid
        {
            get => foundGrid;
            set => foundGrid = value;
        }

        public int Width
        {
            get => width;
            set => width = value;
        }

        public int Height
        {
            get => height;
            set => height = value;
        }

        public int DifficultyLevel
        {
            get => difficultyLevel;
            set => difficultyLevel = value;
        }

        public List<string> WorldList
        {
            get => worldList;
            set => worldList = value;
        }

        public Dictionary<int, Dictionnaire> Dictionnaires
        {
            get => dictionnaires;
            set => dictionnaires = value;
        }

        private Dictionary<int, Dictionnaire> dictionnaires;

        public Plateau(int difficultyLevel, int lang)
        {
            //Set size according to 5 difficulty levels and worldList length
            this.difficultyLevel = difficultyLevel;
            int worldCount;
            int maxLength = 15;
            switch (difficultyLevel)
            {
                case 1:
                    worldCount = 5;
                    width = 10;
                    height = 10;
                    maxLength = 10;
                    break;
                case 2:
                    worldCount = 7;
                    width = 15;
                    height = 15;
                    break;
                case 3:
                    worldCount = 10;
                    width = 20;
                    height = 20;
                    break;
                case 4:
                    worldCount = 12;
                    width = 25;
                    height = 25;
                    break;
                case 5:
                    worldCount = 15;
                    width = 30;
                    height = 30;
                    break;
                default:
                    worldCount = 5;
                    width = 10;
                    height = 10;
                    maxLength = 10;
                    break;
            }


            grid = new char[height, width];
            wordGrid = new char[height, width];
            foundGrid = new bool[height, width];
            LoadDictionnaries(lang);
            
            //Select random words from dictionnary
            worldList = new List<string>();
            for (int i = 0; i < worldCount; i++)
            {
                worldList.Add(GetRandomWorld(2, maxLength));
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    grid[i, j] = ' ';
                }
            }
            GenerateGrid();
            //Fill in the grid with random letters
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (grid[i, j] == ' ')
                    {
                        grid[i, j] = Functions.RandomLetter();
                    }
                }
            }
            
            //Check the grid if there isn't a random word that is not in the wordlist and place them into the wordGrid
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    string wordAndDirection = GetWord(i, j);
                    if (wordAndDirection == "") continue;
                    var wordArgs = wordAndDirection.Split(' ');
                    var word = wordArgs[0];
                    int direction = Convert.ToInt32(wordArgs[1]);
                    string directionString = null;
                    switch (direction)
                    {
                        case 0: //SOUTH
                            directionString = "S";
                            break;
                        case 1: //SE
                            directionString = "SE";
                            break;
                        case 2: //EAST
                            directionString = "E";
                            break;
                        case 3: //NE
                            directionString = "NE";
                            break;
                        case 4: //NORTH
                            directionString = "N";
                            break;
                        case 5: //NW
                            directionString = "NW";
                            break;
                        case 6: //WEST
                            directionString = "W";
                            break;
                        case 7: //SW
                            directionString = "SW";
                            break;
                    }
                    if (!worldList.Contains(word))
                    {
                        PlaceWorld(i, j, word, directionString);
                        worldList.Add(word);
                    }
                }
            }
        }
        /// <summary>
        /// Load a save from a path file
        /// </summary>
        /// <param name="path"></param>
        public Plateau(string path)
        {
            LoadDictionnaries(0);
            LoadSave(path);
        }
        /// <summary>
        /// Display all the words in the wordlist
        /// </summary>
        public void DisplayWordList()
        {
            Console.WriteLine("Liste des mots :");
            foreach (string word in worldList)
            {
                Console.WriteLine(word);
            }
        }
        /// <summary>
        /// Check if a new word is in the grid for all directions
        /// </summary>
        /// <param name="x"></param> X position of the first letter
        /// <param name="y"></param> Y position of the first letter
        /// <returns></returns>
        private string GetWord(int x, int y)
        {
            string word;
            for (int i = 0; i < 8; i++)
            {
                word = "";
                int tempX = x;
                int tempY = y;
                for (int j = 0; j < 15; j++)
                {
                    word += grid[tempX, tempY];
                    switch (i)
                    {
                        case 0: //SOUTH
                            tempX++;
                            break;
                        case 1: //SE
                            tempX++;
                            tempY++;
                            break;
                        case 2: //EAST
                            tempY++;
                            break;
                        case 3: //NE
                            tempX--;
                            tempY++;
                            break;
                        case 4: //NORTH
                            tempX--;
                            break;
                        case 5: //NW
                            tempX--;
                            tempY--;
                            break;
                        case 6: //WEST
                            tempY--;
                            break;
                        case 7: //SW
                            tempX++;
                            tempY--;
                            break;
                    }
                    if (word.Length > 1 && worldList.Contains(word))
                    {
                        return word + " " + i;
                    }
                    if (tempX < 0 || tempX >= height || tempY < 0 || tempY >= width)
                    {
                        break;
                    }
                }
                if (word.Length > 1 && worldList.Contains(word))
                {
                    return word + " " + i;
                }
            }
            return "";
        }


        public override string ToString()
        {
            return "Le tableau est de taille " + height+"x"+width + " et de niveau de difficulté " + difficultyLevel+"et il y a "+worldList.Count+" mots à trouver.";
        }

        /// <summary>
        /// Check if word overlaps with other words, if the intersection is with the same letter
        /// </summary>
        /// <param name="x"></param> X position of the word
        /// <param name="y"></param> Y position of the word
        /// <param name="world"></param> Word to check
        /// <param name="direction"></param> Direction of the word
        /// <returns></returns>
        public bool CheckWordPosition(int x, int y, string world, string direction)
        {
            switch (direction)
            {
                case "N":
                    if (y - world.Length < 0)
                    {
                        return false;
                    }
                    for (int i = 0; i < world.Length; i++)
                    {
                        if (grid[y - i, x] != ' ' && grid[y - i, x] != world[i])
                        {
                            return false;
                        }
                    }
                    break;
                case "S":
                    if (y + world.Length > height)
                    {
                        return false;
                    }
                    for (int i = 0; i < world.Length; i++)
                    {
                        if (grid[y + i, x] != ' ' && grid[y + i, x] != world[i])
                        {
                            return false;
                        }
                    }
                    break;
                case "E":
                    if (x + world.Length > width)
                    {
                        return false;
                    }
                    for (int i = 0; i < world.Length; i++)
                    {
                        if (grid[y, x + i] != ' ' && grid[y, x + i] != world[i])
                        {
                            return false;
                        }
                    }
                    break;
                case "W":
                    if (x - world.Length < 0)
                    {
                        return false;
                    }
                    for (int i = 0; i < world.Length; i++)
                    {
                        if (grid[y, x - i] != ' ' && grid[y, x - i] != world[i])
                        {
                            return false;
                        }
                    }
                    break;
                case "NE":
                    if (x + world.Length > width || y - world.Length < 0)
                    {
                        return false;
                    }
                    for (int i = 0; i < world.Length; i++)
                    {
                        if (grid[y - i, x + i] != ' ' && grid[y - i, x + i] != world[i])
                        {
                            return false;
                        }
                    }
                    break;
                case "NW":
                    if (x - world.Length < 0 || y - world.Length < 0)
                    {
                        return false;
                    }
                    for (int i = 0; i < world.Length; i++)
                    {
                        if (grid[y - i, x - i] != ' ' && grid[y - i, x - i] != world[i])
                        {
                            return false;
                        }
                    }
                    break;
                case "SE":
                    if (x + world.Length > width || y + world.Length > height)
                    {
                        return false;
                    }
                    for (int i = 0; i < world.Length; i++)
                    {
                        if (grid[y + i, x + i] != ' ' && grid[y + i, x + i] != world[i])
                        {
                            return false;
                        }
                    }
                    break;
                case "SW":
                    if (x - world.Length < 0 || y + world.Length > height)
                    {
                        return false;
                    }
                    for (int i = 0; i < world.Length; i++)
                    {
                        if (grid[y + i, x - i] != ' ' && grid[y + i, x - i] != world[i])
                        {
                            return false;
                        }
                    }
                    break;
            }
            return true;
        }
        
        /// <summary>
        /// Mark a word on the grid in the specified direction and at the specified position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="world"></param>
        /// <param name="direction"></param>
        public void MarkWord(int x, int y, string world, string direction)
        {
            switch (direction)
            {
                case "N":
                    for (int i = 0; i < world.Length; i++)
                    {
                        foundGrid[y - i, x] = true;
                    }
                    break;
                case "S":
                    for (int i = 0; i < world.Length; i++)
                    {
                        foundGrid[y + i, x] = true;
                    }
                    break;
                case "E":
                    for (int i = 0; i < world.Length; i++)
                    {
                        foundGrid[y, x + i] = true;
                    }
                    break;
                case "W":
                    for (int i = 0; i < world.Length; i++)
                    {
                        foundGrid[y, x - i] = true;
                    }
                    break;
                case "NE":
                    for (int i = 0; i < world.Length; i++)
                    {
                        foundGrid[y - i, x + i] = true;
                    }
                    break;
                case "NW":
                    for (int i = 0; i < world.Length; i++)
                    {
                        foundGrid[y - i, x - i] = true;
                    }
                    break;
                case "SE":
                    for (int i = 0; i < world.Length; i++)
                    {
                        foundGrid[y + i, x + i] = true;
                    }
                    break;
                case "SW":
                    for (int i = 0; i < world.Length; i++)
                    {
                        foundGrid[y + i, x - i] = true;
                    }
                    break;
            }
        }


        /// <summary>
        /// Place a word on the grid at a given position and direction
        /// </summary>
        /// <param name="x"></param> x position
        /// <param name="y"></param> y position
        /// <param name="world"></param> word to place
        /// <param name="direction"></param> direction of the word
        private void PlaceWorld(int x, int y, string world, string direction)
        {
            switch (direction)
            {
                case "N":
                    for (int i = 0; i < world.Length; i++)
                    {
                        grid[y - i, x] = world[i];
                        wordGrid[y - i, x] = world[i];
                    }
                    break;
                case "S":
                    for (int i = 0; i < world.Length; i++)
                    {
                        grid[y + i, x] = world[i];
                        wordGrid[y + i, x] = world[i];
                    }
                    break;
                case "E":
                    for (int i = 0; i < world.Length; i++)
                    {
                        grid[y, x + i] = world[i];
                        wordGrid[y, x + i] = world[i];
                    }
                    break;
                case "W":
                    for (int i = 0; i < world.Length; i++)
                    {
                        grid[y, x - i] = world[i];
                        wordGrid[y, x - i] = world[i];
                    }
                    break;
                case "NE":
                    for (int i = 0; i < world.Length; i++)
                    {
                        grid[y - i, x + i] = world[i];
                        wordGrid[y - i, x + i] = world[i];
                    }
                    break;
                case "NW":
                    for (int i = 0; i < world.Length; i++)
                    {
                        grid[y - i, x - i] = world[i];
                        wordGrid[y - i, x - i] = world[i];
                    }
                    break;
                case "SE":
                    for (int i = 0; i < world.Length; i++)
                    {
                        grid[y + i, x + i] = world[i];
                        wordGrid[y + i, x + i] = world[i];
                    }
                    break;
                case "SW":
                    for (int i = 0; i < world.Length; i++)
                    {
                        grid[y + i, x - i] = world[i];
                        wordGrid[y + i, x - i] = world[i];
                    }
                    break;
            }
        }
        /// <summary>
        /// Generate grid with difficulty level. 1 = (S, E), 2 = (S, E, W, N), 3 = (S, E, W, N, SW), 4 = (S, E, W, N, SW, SE); 5 = (S, E, W, N, NE, NW, SW, SE)
        /// </summary>
        private void GenerateGrid()
        {
            var directions = new [] {"S", "E", "W", "N", "SW", "SE", "NE", "NW"};
            foreach (string world in worldList)
            {
                bool placed = false;
                while (!placed)
                {
                    int x = Functions.GetRandomInt(0, width);
                    int y = Functions.GetRandomInt(0, height);
                    string direction = "";
                    switch (difficultyLevel)
                    {
                        case 1:
                            direction = directions[Functions.GetRandomInt(0, 2)];
                            break;
                        case 2:
                            direction = directions[Functions.GetRandomInt(0, 4)];
                            break;
                        case 3:
                            direction = directions[Functions.GetRandomInt(0, 6)];
                            break;
                        case 4:
                            direction = directions[Functions.GetRandomInt(0, 8)];
                            break;
                        case 5:
                            direction = directions[Functions.GetRandomInt(0, 8)];
                            break;
                    }
                    if (CheckWordPosition(x, y, world, direction))
                    {
                        PlaceWorld(x, y, world, direction);
                        placed = true;
                    }
                }
            }
        }
        /// <summary>
        /// Display the grid
        /// </summary>
        public void DisplayGrid()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("      X");
            Console.ForegroundColor = ConsoleColor.Red;
            for(int k=0; k<width; k++)
            {
                if (k<=10)
                {
                    Console.Write("  " + k);
                }
                else
                {
                    Console.Write(" " + k);
                }
            }
            Console.WriteLine();
            for (int i = 0; i < height; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                if (height > 9 || width > 9)
                {
                    if(i<10)Console.Write("      "+(i)+"  ");
                    else Console.Write("      "+(i)+" ");
                }
                else Console.Write("     "+(i)+" ");
                Console.ResetColor();
                for (int j = 0; j < width; j++)
                {
                    if (foundGrid[i, j])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(grid[i, j] + " ");
                        if(height >9|| width>9 ) Console.Write(" ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(grid[i, j] + " ");
                        if(height >9|| width>9 ) Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n"+"\n");
        }
        
        /// <summary>
        /// Display grid with the answers
        /// </summary>
        public void DisplayGridWithAnswers()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("      X");
            Console.ForegroundColor = ConsoleColor.Red;
            for(int k=0; k<width; k++)
            {
                Console.Write(" " + k);
            }
            Console.WriteLine();
            for (int i = 0; i < height; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if(i<10) Console.Write("      "+(i)+" ");
                else Console.Write("     "+(i)+" ");
                Console.ResetColor();
                for (int j = 0; j < width; j++)
                {
                    if (wordGrid[i, j] != '\0')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(wordGrid[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(grid[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n"+"\n");
        }
        
        /// <summary>
        /// Load all words in the dictionaries
        /// </summary>
        /// <param name="lang"></param> Language of the dictionary
        public void LoadDictionnaries(int lang)
        {
            dictionnaires = new Dictionary<int, Dictionnaire>();
            for (int i = 2; i <= 15; i++)
            {
                dictionnaires.Add(i, new Dictionnaire(lang, i));
            }
        }
        
        /// <summary>
        /// Get a random word from the dictionary
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public string GetRandomWorld(int min, int max)
        {
            if (min < 2)
            {
                min = 2;
            }
            if (max > 15)
            {
                max = 15;
            }
            var randomWorldLength = Functions.GetRandomInt(min, max);
            var randomWorldIndex = Functions.GetRandomInt(0, dictionnaires[randomWorldLength].Count());
            return dictionnaires[randomWorldLength].Get(randomWorldIndex);
        }
        
        /// <summary>
        /// Save game in a file
        /// </summary>
        public void SaveGrid()
        {
            //Level of difficulty, height, width, words to find
            var stringCsv = $"{difficultyLevel};{height};{width};{worldList.Count}\n";
            //Words to find
            foreach (string world in worldList)
            {
                stringCsv += $"{world};";
            }
            stringCsv += "\n";
            //Grid
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    stringCsv += $"{grid[i, j]};";
                }
                stringCsv += "\n";
            }
            File.WriteAllText("../../save.csv", stringCsv);
        }
        /// <summary>
        /// Load grid from csv
        /// </summary>
        /// <param name="path"></param> Path to csv file
        public void LoadSave(string path)
        {
            var save = File.ReadAllLines(path);
            var saveData = save[0].Split(';');
            difficultyLevel = int.Parse(saveData[0]);
            height = int.Parse(saveData[1]);
            width = int.Parse(saveData[2]);
            var worldCount = int.Parse(saveData[3]);
            worldList = new List<string>();
            
            var savedWords = save[1].Split(';');
            for (int i = 0; i < worldCount; i++)
            {
                worldList.Add(savedWords[i]);
            }
            
            grid = new char[height, width];
            wordGrid = new char[height, width];
            foundGrid = new bool[height, width];
            for (int i = 0; i < height; i++)
            {
                var savedLine = save[i + 2].Split(';');
                for (int j = 0; j < width; j++)
                {
                    grid[i, j] = savedLine[j][0];
                }
            }
            
            //Discover all words and place them into the wordGrid
            foreach (string world in worldList)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (grid[i, j] == world[0])
                        {
                            if (CheckWordPosition(j, i, world, "S"))
                            {
                                PlaceWorld(j, i, world, "S");
                            }
                            else if (CheckWordPosition(j, i, world, "E"))
                            {
                                PlaceWorld(j, i, world, "E");
                            }
                            else if (CheckWordPosition(j, i, world, "W"))
                            {
                                PlaceWorld(j, i, world, "W");
                            }
                            else if (CheckWordPosition(j, i, world, "N"))
                            {
                                PlaceWorld(j, i, world, "N");
                            }
                            else if (CheckWordPosition(j, i, world, "NE"))
                            {
                                PlaceWorld(j, i, world, "NE");
                            }
                            else if (CheckWordPosition(j, i, world, "NW"))
                            {
                                PlaceWorld(j, i, world, "NW");
                            }
                            else if (CheckWordPosition(j, i, world, "SE"))
                            {
                                PlaceWorld(j, i, world, "SE");
                            }
                            else if (CheckWordPosition(j, i, world, "SW"))
                            {
                                PlaceWorld(j, i, world, "SW");
                            }
                        }
                    }
                }
            }
        }
    }
}