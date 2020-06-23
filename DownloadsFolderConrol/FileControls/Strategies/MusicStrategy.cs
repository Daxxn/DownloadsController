using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsFolderConrol.FileControls.Strategies
{
    public class MusicStrategy : IStrategy
    {
        #region - Fields & Properties
        public FileManager FileManager { get; set; } = FileManager.Instance;
        public string[] ExtensionWhiteList { get; } =
        {
            ".mp3", ".mp4", "wav", "ogg"
        };
        public Command CurrentCommand { get; set; }
        #endregion

        #region - Constructors
        public MusicStrategy( ) { }
        public string[] Run( )
        {
            var originFolder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.UserProfile),
                    PathSettings.Default.Downloads
            );
            string[] filteredFiles = FileManager.FilterByExtensions(
                Directory.GetFiles(originFolder),
                ExtensionWhiteList
            );
            var results = FileManager.MoveFiles(
                filteredFiles,
                PathSettings.Default.Music
            );
            return results;
        }
        #endregion

        #region - Methods

        #endregion

        #region - Full Properties

        #endregion
    }
}
