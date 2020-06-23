using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsFolderConrol.FileControls
{
    public class FileManager
    {
        #region - Fields & Properties
        private static FileManager _instance;
        #endregion

        #region - Constructors
        private FileManager( ) { }
        #endregion

        #region - Methods
        public string[] GetFiles( string path )
        {
            try
            {
                return Directory.GetFiles(path);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string[] FilterByExtensions( string[] files, string[] extensions )
        {
            return files.Where(file => extensions.Contains(Path.GetExtension(file))).ToArray();
        }

        public string[] MoveFiles( string[] files, string destination )
        {
            try
            {
                if (files.Length is 0)
                {
                    throw new Exception("No files found.");
                }

                return ProcessFiles(files, destination);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string[] ProcessFiles( string[] files, string destination )
        {
            List<string> results = new List<string>();
            foreach (var file in files)
            {
                try
                {
                    File.Move(file, BuildNewPath(file, destination));
                    results.Add($"Moved: {Path.GetFileName(file)}");
                }
                catch (Exception e)
                {
                    results.Add($"Stopped: {Path.GetFileName(file)} : {e.Message}");
                }
            }
            return results.ToArray();
        }

        private string BuildNewPath( string file, string destination )
        {
            try
            {
                return Path.Combine(destination, Path.GetFileName(file));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region - Full Properties
        public static FileManager Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new FileManager();
                }
                return _instance;
            }
        }
        #endregion
    }
}
