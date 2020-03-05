using System;
using System.IO;

namespace TotalStat
{
    public class AppSizeGeometry       //вынести парсинг в парсер, добавить Localize
    {
        private const string _appSize = "AppSize";
        private const string _appGeometry = "AppGeometry";
        private const string _redactorGeometry = "RedactorGeometry";
        private const char _delimeter = 'x';        
        public static int AppWindowHeight { get; set; }        
        public static int AppWindowWidth { get; set; }        
        public static double AppWindowTop { get; set; }        
        public static double AppWindowLeft { get; set; }        
        public static double RedactorWindowTop { get; set; }
        public static double RedactorWindowLeft { get; set; }
        public AppSizeGeometry()
        {
            ReadSizeAndGeometry();            
        }        
        private void ReadSizeAndGeometry()
        {
            string line;
            try 
            {
                if(File.Exists(Directory.GetCurrentDirectory() + "\\configuration.txt"))
                {
                    StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "\\configuration.txt");
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] splitArr = line.Split(' ');
                        if(splitArr.Length > 1)
                        {
                            if (splitArr[0] == _appSize)
                            {
                                string[] temp = splitArr[1].Split(_delimeter);
                                if(temp.Length > 1)
                                {
                                    AppWindowHeight =  Int32.TryParse(temp[0], out int height) ? height : 400;
                                    AppWindowWidth = Int32.TryParse(temp[1], out int width) ? width : 400;
                                }
                            }
                            if(splitArr[0] == _appGeometry)
                            {
                                string[] temp = splitArr[1].Split(_delimeter);
                                if (temp.Length > 1)
                                {
                                    AppWindowTop = Double.TryParse(temp[0], out double top) ? top : 300;
                                    AppWindowLeft = Double.TryParse(temp[1], out double left) ? left : 300;
                                }
                            }
                            if (splitArr[0] == _redactorGeometry)
                            {
                                string[] temp = splitArr[1].Split(_delimeter);
                                if (temp.Length > 1)
                                {
                                    RedactorWindowTop = Double.TryParse(temp[0], out double top) ? top : 300;
                                    RedactorWindowLeft = Double.TryParse(temp[1], out double left) ? left : 300;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }            
        }
        public static void SaveSizeAndGeometry()
        {
            try
            {
                StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + "\\configuration.txt", false);
                writer.WriteLine(_appSize + " " + AppWindowHeight + _delimeter + AppWindowWidth);
                writer.WriteLine(_appGeometry + " " + AppWindowTop + _delimeter + AppWindowLeft);
                writer.WriteLine(_redactorGeometry + " " + RedactorWindowTop + _delimeter + RedactorWindowLeft);

                writer.Close();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
