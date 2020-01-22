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
