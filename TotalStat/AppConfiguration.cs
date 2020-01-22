using System;
using System.IO;

namespace TotalStat
{
    public class AppConfiguration
    {
        public static int appwindowheight = 400;
        public static int appwindowwidth = 400;
        public static double appwindowTop = 150;
        public static double appwindowLeft = 150;
        public static int AppWindowHeight
        {
            get { return appwindowheight; }
            set { appwindowheight = value; }
        }
        
        public static int AppWindowWidth
        {
            get { return appwindowwidth; }
            set { appwindowwidth = value; }
        }
        
        public static double AppWindowTop
        {
            get { return appwindowTop; }
            set { appwindowTop = value; }
        }
        
        public static double AppWindowLeft
        {
            get { return appwindowLeft; }
            set { appwindowLeft = value; }
        }

        public static double redactorwindowTop = 150;
        public static double redactorwindowLeft = 150;
        public static double RedactorWindowTop
        {
            get { return redactorwindowTop; }
            set { redactorwindowTop = value; }
        }
        public static double RedactorWindowLeft
        {
            get { return redactorwindowLeft; }
            set { redactorwindowLeft = value; }
        }

        public AppConfiguration()
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
                        string[] split_arr = line.Split(' ');
                        if(split_arr.Length > 1)
                        {
                            if(split_arr[0] == "AppSize")
                            {
                                string[] temp = split_arr[1].Split('x');
                                if(temp.Length > 1)
                                {
                                    Int32.TryParse(temp[0], out appwindowheight);
                                    Int32.TryParse(temp[1], out appwindowwidth);
                                }                                
                            }
                            if(split_arr[0] == "AppGeometry")
                            {
                                string[] temp = split_arr[1].Split('x');
                                if (temp.Length > 1)
                                {
                                    Double.TryParse(temp[0], out appwindowTop);
                                    Double.TryParse(temp[1], out appwindowLeft);
                                }
                            }
                            if (split_arr[0] == "RedactorGeometry")
                            {
                                string[] temp = split_arr[1].Split('x');
                                if (temp.Length > 1)
                                {
                                    Double.TryParse(temp[0], out redactorwindowTop);
                                    Double.TryParse(temp[1], out redactorwindowLeft);
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
                writer.WriteLine("AppSize" + " " + AppWindowHeight + "x" + AppWindowWidth);
                writer.WriteLine("AppGeometry" + " " + AppWindowTop + "x" + AppWindowLeft);
                writer.WriteLine("RedactorGeometry" + " " + RedactorWindowTop + "x" + RedactorWindowLeft);

                writer.Close();
            }
            catch(Exception ex)
            {

            }
            


        }
    }
}
