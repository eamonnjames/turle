using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Turtle.Model;

namespace Turtle.Settings
{
    static class GameSettings
    {
        //static Tuple<int,int> _boardSize;

        public static BoardSetting GameSettingSetBoardSize(string setting, string fileName)
        {
            var FileContent = ReadSettings(fileName);
            var GetWidthAndHeight = showMatch(FileContent, @"" + setting + "\r\n[0-9],[0-9]", "" + setting + "\r\n");
            var BoardSettings = new BoardSetting();

            try
            {
                BoardSettings.width = GetWidthAndHeight.First();
                BoardSettings.height = GetWidthAndHeight.Last();

                return BoardSettings;
            }
            catch(Exception e)
            {
                Console.WriteLine("Excetion :{0}", e);
            }

            return BoardSettings;
        }

        public static Point GameSettingGetStartingPosition(string setting,string FileName)
        {
            var FileContent = ReadSettings(FileName);
            var StartingPosition = showMatch(FileContent, @"" + setting + "\r\n[0-9],[0-9]", "" + setting + "\r\n");
            var point = new Point();

            try
            {
                point.x = StartingPosition.First();
                point.y = StartingPosition.Last();
                

            }catch(Exception e)
            {
                Console.WriteLine("Exception : {0}", e);
            };

            return point;

        }

        public static List<Point> GameSettingGetMinesLocation(string setting, string FileName)
        {
            var FileContent = ReadSettings(FileName);
            var ListOfMines = showMatch(FileContent, @"" + setting + "\r\n[0-9],[0-9]\r\n[0-9],[0-9]\r\n[0-9],[0-9]", "" + setting + "\r\n");
            var Mines = new List<Point>();
            int counter = 1;

            try
            {
                for(int i = 0;i < ListOfMines.Count; i++)
                {
                    if(i == counter)
                    {
                        var point = new Point
                        {
                            x = ListOfMines[i],
                            y = ListOfMines[i - 1]

                        };

                        Mines.Add(point);
                        counter = counter + 2;
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            };

            return Mines;
        }
        private static List<int> showMatch(string text, string expr,string TextToRemove)
        {
            MatchCollection mc = Regex.Matches(text, expr);

            var removeBoardSizeText = mc[0].ToString().Replace(TextToRemove, "");

            var t1 = new List<int>();
            
            int n;

            foreach (char c in removeBoardSizeText)
            {

                bool isNumeric = int.TryParse(c.ToString(), out n);

                if (isNumeric)
                {
                    t1.Add(n);
                   
                }
            }            

            return t1;
            
        }


        private static string ReadSettings(string fileName)
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("./Settings/" + fileName + ".txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    //Console.WriteLine(line);
                    return line;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public static List<string> getMoves(string FileName)
        {
            var FileContent = ReadSettings(FileName);

            List<string> moves = FileContent.Split(",").ToList<string>();

            return moves;
        }        
    }
        
}
   
