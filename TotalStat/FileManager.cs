using System;
using System.Collections.Generic;
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
            Name = (path.Substring(index + 1));
        }
        public string Path { get; set; }
        public string Name { get; set; }
    }
    public class FileManager
    {        
        public FileDialogSelect FileDialogSingle(string filter)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = filter;
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == true)
            {                
                return new FileDialogSelect(dlg.FileName);
            }
            else
            {
                return null;
            }
        }
        public List<FileDialogSelect> FileDialogMulti(string filter)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = filter;
            dlg.Multiselect = true;
            List<FileDialogSelect> fileDialogSelect = new List<FileDialogSelect>();
            if (dlg.ShowDialog() == true)
            {                
                foreach (string filename in dlg.FileNames)
                {
                    fileDialogSelect.Add(new FileDialogSelect(filename));
                }
                return fileDialogSelect;
            }
            else
            {
                return new List<FileDialogSelect>();
            }
        }
    }
}
