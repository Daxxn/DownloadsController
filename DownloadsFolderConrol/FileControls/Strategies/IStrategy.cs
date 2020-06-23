using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsFolderConrol.FileControls.Strategies
{
    public interface IStrategy
    {
        string[] ExtensionWhiteList { get; }
        Command CurrentCommand { get; set; }
        string[] Run( );
    }
}
