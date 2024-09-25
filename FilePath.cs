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

       // public string B;

        private string path;
        public string Path
        {
            get
            {
                if (!File.Exists(path))
                {
                    //DirectoryInfo projectDirectory = new DirectoryInfo(ProjectDir);

                   
                }


                return path;
            }
            private set
            {
                path = value;
            }
        }

        public FilePath(string FileName)
        {

            Process currentProcess = Process.GetCurrentProcess();

         


            this.FileName = FileName;

            FileInfo fileEXE = new FileInfo(currentProcess.ProcessName+".exe");
            
            DirectoryInfo directoryBin = new DirectoryInfo(new DirectoryInfo( fileEXE.DirectoryName).Parent.FullName);



            ProjectFolder = new DirectoryInfo( directoryBin.Parent.FullName).FullName;

 
        }
    }
}
