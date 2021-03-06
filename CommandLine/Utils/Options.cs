using System.Collections.Generic;
using CommandLine;

namespace Danmu.CommandLine.Utils
{
    public class Options
    {
        [Option('v', "version", Required = false, HelpText = "程序版本")]
        public bool Version { get; set; }

        [Option('m', "menu", Required = false, HelpText = "开启菜单")]
        public bool Menu { get; set; }
    }
}
