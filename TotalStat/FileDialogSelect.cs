using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalStat
{
    public class FileDialogSelect
    {       
        public FileDialogSelect(string path)
        {
            Path = path;
            int index = path.LastIndexOf("\\");
            Name = (path.Substring(index+1));
        }
        public string Path { get; set; }
        public string Name { get; set; }
    }
}
