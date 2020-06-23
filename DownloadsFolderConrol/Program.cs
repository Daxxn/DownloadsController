using DownloadsFolderConrol.FileControls;
using DownloadsFolderConrol.FileControls.Strategies;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DownloadsFolderConrol
{
    class Program
    {
        public static FileManager FileManager { get; set; } = FileManager.Instance;
        public static Command CurrentCommand { get; set; }

        #region Console Colors
        public static ConsoleColor BaseColor { get; set; } = Console.ForegroundColor;
        public static ConsoleColor Background { get; set; } = Console.BackgroundColor;
        public static ConsoleColor ErrorColor { get; set; } = ConsoleColor.Red;
        public static ConsoleColor SyntaxColor { get; set; } = ConsoleColor.Yellow;
        public static ConsoleColor ResultsForeColor { get; set; } = Console.ForegroundColor;
        public static ConsoleColor resultsBackColor { get; set; } = Console.BackgroundColor;
        public static int LineSpacing { get; set; } = 1;
        #endregion

        static void Main( string[] args )
        {

            InitializeConsole();

            bool isRunning = true;
            while (isRunning)
            {
                CurrentCommand = GetUserInput();
                try
                {
                    switch (CurrentCommand)
                    {
                        case Command.Exit:
                            isRunning = false;
                            break;

                        case Command.Clear:
                            Console.Clear();
                            break;

                        case Command.ImageMode:
                            var imageController = new ImageStrategy();
                            PrintResults(imageController.Run());
                            break;

                        case Command.MusicMode:
                            var musicController = new MusicStrategy();
                            PrintResults(musicController.Run());
                            break;

                        case Command.AllMode:
                            imageController = new ImageStrategy();
                            PrintResults(imageController.Run());

                            musicController = new MusicStrategy();
                            PrintResults(musicController.Run());
                            break;

                        case Command.HelpMode:
                            var helpController = new HelpStrategy();
                            PrintResults(helpController.Run());
                            break;

                        case Command.NoCommand:
                            PrintSyntaxMessage("No command found.");
                            break;

                        default:
                            throw new Exception("Unknown command parse error! Dats BAD!");
                    }
                }
                catch (Exception e)
                {
                    PrintErrorMessage(e.Message);
                }
            }
        }

        public static Command GetUserInput( )
        {
            Console.WriteLine("Enter Command:");
            string input = Console.ReadLine();
            return CommandSelector.SelectCommand(input);
        }

        public static void PrintResults( string[] results )
        {
            StringBuilder builder = new StringBuilder("--- Results:\n");
            if (results.Length > 0)
            {
                foreach (var item in results)
                {
                    builder.Append(item);
                }
            }
            else
            {
                builder.AppendLine("No results returned...");
            }
            Console.ForegroundColor = ResultsForeColor;
            Console.BackgroundColor = resultsBackColor;
            Console.WriteLine(builder.ToString());
            Console.ForegroundColor = BaseColor;
            Console.BackgroundColor = Background;
        }

        public static void PrintCommands<T>( Dictionary<string, T> commands )
        {
            Console.WriteLine("Valid Commands: ");
            foreach (var cmd in commands.Keys)
            {
                Console.WriteLine(cmd);
            }
            Console.WriteLine("\n");
        }

        public static void PrintSyntaxMessage( string message )
        {
            Console.ForegroundColor = SyntaxColor;
            Console.Write("SYNTAX: : ");
            Console.ForegroundColor = BaseColor;
            Console.WriteLine(message);
        }

        public static void PrintErrorMessage( string message )
        {
            Console.ForegroundColor = ErrorColor;
            Console.Write("ERROR: : ");
            Console.ForegroundColor = BaseColor;
            Console.WriteLine(message);
        }

        public static void InitializeConsole( )
        {
            try
            {
                BaseColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), ConsoleSettings.Default.ForegroundColorBase, true);
                Console.ForegroundColor = BaseColor;
                Background = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), ConsoleSettings.Default.Background, true);
                Console.BackgroundColor = Background;
                ErrorColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), ConsoleSettings.Default.ErrorColor, true);
                SyntaxColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), ConsoleSettings.Default.SyntaxColor, true);
                ResultsForeColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), ConsoleSettings.Default.ResultsForeColor, true);
                resultsBackColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), ConsoleSettings.Default.ResultsBackColor, true);
                LineSpacing = ConsoleSettings.Default.LineSpacing;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
