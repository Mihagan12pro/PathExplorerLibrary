using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PathExplorerLibrary
{
    public class Explorer
    {
        public Explorer(FilePath filePath)
        {
            
        }
    }

    //public  class FilePath
    //{
    //    public readonly string FileName;

    //    public readonly string ProjectName;

    //    public readonly  string ProjectDir;


    //    private string path;
    //    public string Path
    //    {
    //        get
    //        {
    //            if (!File.Exists(path))
    //            {
    //               DirectoryInfo projectDirectory = new DirectoryInfo(ProjectDir);


    //            }


    //            return path;
    //        }
    //        private set
    //        {
    //            path = value;
    //        }
    //    }

    //    public FilePath(string FileName,string ProjectName)
    //    {
    //        this.FileName = FileName;
    //        this.ProjectName = ProjectName;

    //        string projectExe = new FileInfo(ProjectName).FullName;

         
    //        DirectoryInfo debugDir = new DirectoryInfo(projectExe.Replace(ProjectName,""));
          
    //        DirectoryInfo binDir = new DirectoryInfo(debugDir.Parent.FullName);

          
    //        ProjectDir = new DirectoryInfo(binDir.Parent.FullName).FullName;
    //    }
    //}
}
