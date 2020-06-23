using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsFolderConrol.FileControls.FileReading
{
    public static class PathFileController
    {
        #region - Fields & Properties
        public static Dictionary<string, string> SaveLocations { get; set; }
        private static char separator = '|';
        #endregion

        #region - Methods
        public static void Save( )
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(PathSettings.Default.SaveLocDict))
                {
                    foreach (var item in SaveLocations)
                    {
                        writer.WriteLine($"{item.Key}{separator}{item.Value}");
                    }
                    writer.Flush();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Load( )
        {
            try
            {
                using (StreamReader reader = new StreamReader(PathSettings.Default.SaveLocDict))
                {
                    SaveLocations = new Dictionary<string, string>();
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] split = line.Split(separator);
                        if (split.Length == 2)
                        {
                            SaveLocations.Add(split[ 0 ], split[ 1 ]);
                        } else
                        {
                            throw new Exception($"File format is wrong. Separator should be '{separator}' and lines cannot be incomplete.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region - Full Properties

        #endregion
    }
}
