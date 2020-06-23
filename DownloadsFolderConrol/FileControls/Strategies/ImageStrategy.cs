using System;
using System.Collections.Generic;
using System.IO;

namespace DownloadsFolderConrol.FileControls.Strategies
{
    public enum ImageCommand
    {
        NoCommand = 0,
        WallPapers = 1,
        SavedImages = 2,
    }

    public class ImageStrategy : IStrategy
    {
        #region - Fields & Properties
        public FileManager FileManager { get; set; }
        public Command CurrentCommand { get; set; }
        public Dictionary<string, ImageCommand> CommandTable { get; set; } = new Dictionary<string, ImageCommand>
        {
            { "", ImageCommand.NoCommand },
            { "wallpaper", ImageCommand.WallPapers },
            { "saved", ImageCommand.SavedImages }
        };
        public string[] ExtensionWhiteList { get; private set; } = new string[]
        {
            ".jpeg", "png", ".svg"
        };
        #endregion

        #region - Constructors
        public ImageStrategy( )
        { 
            FileManager = FileManager.Instance;
        }
        #endregion

        #region - Methods
        public string[] Run( )
        {
            try
            {
                string destination = ParseCommand(GetImageCommand());
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
                    destination
                );
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private ImageCommand GetImageCommand( )
        {
            Console.WriteLine("Enter Save Location, Enter nothing to use dafult location:");
            foreach (var command in CommandTable.Keys)
            {
                if (command.Length > 0)
                {
                    Console.WriteLine(command);
                }
            }
            return CommandSelector.SelectCommand(Console.ReadLine(), CommandTable);
        }

        private string ParseCommand( ImageCommand cmd )
        {
            switch (cmd)
            {
                case ImageCommand.NoCommand:
                    return PathSettings.Default.SavedImages;
                case ImageCommand.WallPapers:
                    return PathSettings.Default.WallPapers;
                case ImageCommand.SavedImages:
                    return PathSettings.Default.SavedImages;
                default:
                    return PathSettings.Default.SavedImages;
            }
        }
        #endregion

        #region - Full Properties

        #endregion
    }
}
