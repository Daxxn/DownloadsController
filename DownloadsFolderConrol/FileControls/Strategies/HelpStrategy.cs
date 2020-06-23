using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsFolderConrol.FileControls.Strategies
{
    public class HelpStrategy : IStrategy
    {
        #region - Fields & Properties
        public string[] ExtensionWhiteList { get; } = new string[]
        {
            "These are the extensions to allow.",
            "Going to build a file reader to allow this to change."
        };
        public Command CurrentCommand { get; set; }
        public Dictionary<string, string> CommandListing { get; private set; } = new Dictionary<string, string>
        {
            { "exit", "Exit the program." },
            { "image", "Move images from the downloads folder to where the Path settings Images point" }
        };
        #endregion

        #region - Constructors
        public HelpStrategy( ) { }
        #endregion

        #region - Methods
        public string[] Run( )
        {
            List<string> output = new List<string>
            {
                "Commands:"
            };

            output.AddRange(Enum.GetNames(typeof(Command)));
            output.Add("\n");

            output.Add("Extension White List:");
            output.AddRange(ExtensionWhiteList);
            output.Add("\n");

            output.Add("Results:");
            output.Add("Results from the Commands are then printed");
            output.Add("With a status code denoting a problem");
            output.Add("\n");

            return output.ToArray();
        }
        #endregion

        #region - Full Properties

        #endregion
    }
}
