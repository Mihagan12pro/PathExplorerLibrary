using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflactionNamespace = System.Reflection;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
namespace PathExplorerLibrary
{

    public class FilePath
    {
        public readonly string FileName;


        public readonly string ProjectFolder;

        protected List<DirectoryInfo> directories = new List<DirectoryInfo>();
        protected List<FileInfo>files = new List<FileInfo>();

       // public string B;
       
        public int Size 
        { 
            get
            {
                return directories.Count;
            }
        }

        protected string path;
        public string Path
        {
            get
            {
               
                return path;
            }
            protected set
            {
                path = value;
            }
        }

        
        protected void GetDirectories(string dir)
        {
         
            DirectoryInfo directory = new DirectoryInfo(dir);

            directories.Add(directory);

            foreach (var subDir in directory.GetDirectories())
            {
                GetDirectories(subDir.FullName);
            }
        }
       
        protected void GetFiles()
        {
            if (directories.Count > 0)
            {
                foreach(var dir in directories)
                {
                    foreach(var file in dir.GetFiles())
                    {
                        files.Add(file);
                    }
                }    
            }
        }

        public FilePath(string FileName)
        {

            Process currentProcess = Process.GetCurrentProcess();
         
         


            this.FileName = FileName;

            FileInfo fileEXE = new FileInfo(currentProcess.ProcessName+".exe");
            
            DirectoryInfo directoryBin = new DirectoryInfo(new DirectoryInfo( fileEXE.DirectoryName).Parent.FullName);



            ProjectFolder = new DirectoryInfo( directoryBin.Parent.FullName).FullName;

            
            if (new FileInfo(FileName).Exists == false)
            {
                GetDirectories(ProjectFolder);

                GetFiles();
              

                foreach(var file in files)
                {
                    if (file.Name == FileName)
                    {
                        Path = file.FullName;
                       
                        break;
                    }
                }
            }
            else
            {
                Path = new FileInfo(FileName).FullName;
            }
 
            if (Path == null)
            {
                throw new Exception("The file was not found!");
            }
        }
    }
}
