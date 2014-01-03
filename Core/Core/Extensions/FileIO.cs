using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Map;
using System.IO;

namespace Core.Extensions
{
    public static class FileIO
    {
        static int WaweNum;
        static int CurrentWawe { get; set;}
        static string[] arrayStringMask;

        static FileIO()
        {
            WaweNum = -1;
        }

        public static char[,] GetLevelMask()
        {
            var mask = new char[Ground.MapWidth, Ground.MapHeight];
               string stringMask = string.Empty;
                using (var stream = File.OpenRead(@"Map.txt"))
                {
                    var reader = new StreamReader(stream);
                    stringMask = reader.ReadToEnd();
                }
                var arrayStringMask = stringMask.Split('\n', '\r').Where(x => x != "").ToArray<string>();
                for (int i = 0; i < Ground.MapHeight; i++)
                {
                    for (int j = 0; j < Ground.MapWidth; j++)
                    {
                        mask[j, i] = arrayStringMask[i][j];
                    }
                }
            
            return mask;
        }

        public static string GetWawe()
        {
            if (WaweNum == -1)
            {
                string stringMask = string.Empty;
                using (var stream = File.OpenRead(@"Wawes.txt"))
                {
                    var reader = new StreamReader(stream);
                    stringMask = reader.ReadToEnd();
                }
                arrayStringMask = stringMask.Split('\n', '\r').Where(x => x != "").ToArray<string>();
                CurrentWawe = 1;
                WaweNum = Int32.Parse(arrayStringMask[0]);
            }
            if (CurrentWawe > WaweNum) return "NO";
            return arrayStringMask[CurrentWawe++];
        }
        
    }
}
