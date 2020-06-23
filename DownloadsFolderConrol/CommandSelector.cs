using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsFolderConrol
{
    public enum Command
    {
        Exit = 0,
        ImageMode = 1,
        MusicMode = 2,
        AllMode = 3,
        HelpMode = 4,
        Clear = 5,
        NoCommand = Int16.MaxValue,
    }

    public static  class CommandSelector
    {
        #region - Fields & Properties
        private static Dictionary<string, Command> CommandMenu { get; set; } = new Dictionary<string, Command>
        {
            { "", Command.NoCommand },
            { "exit", Command.Exit },
            { "clear", Command.Clear },
            { "image", Command.ImageMode },
            {"music", Command.MusicMode },
            { "all", Command.AllMode },
            { "help", Command.HelpMode }
        };
        #endregion

        #region - Methods
        public static Command SelectCommand( string input )
        {
            try
            {
                return CommandMenu[ input ];
            }
            catch (Exception)
            {
                return Command.NoCommand;
            }
        }

        public static T SelectCommand<T>( string input, Dictionary<string, T> command )
        {
            try
            {
                return command[ input ];
            }
            catch (Exception)
            {
                return command[ "" ];
            }
        }
        #endregion

        #region - Full Properties

        #endregion
    }
}
