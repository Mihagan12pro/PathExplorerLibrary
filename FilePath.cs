using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflactionNamespace = System.Reflection;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.CodeDom;
using System.Data;
namespace PathExplorerLibrary
{

    public class FilePath
    {
        public readonly string FileName;
        public readonly string FolderName;


        public readonly string ProjectFolder;

        protected List<DirectoryInfo> directories = new List<DirectoryInfo>();
        protected List<FileInfo>files = new List<FileInfo>();

        protected readonly string folderPath;


        protected readonly Exception eFileNotFound = new Exception("The file was not found!");
        protected readonly Exception eFolderNotFount = new Exception("The folder was not found!");
        protected readonly Exception eDublicateFiles = new Exception("Two files with the same name were found");

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

        public FilePath(string FileName,string FolderName)
        {
            Process currentProcess = Process.GetCurrentProcess();




            this.FileName = FileName;
            this.FolderName = FolderName;

            FileInfo fileEXE = new FileInfo(currentProcess.ProcessName + ".exe");

            DirectoryInfo directoryBin = new DirectoryInfo(new DirectoryInfo(fileEXE.DirectoryName).Parent.FullName);



            ProjectFolder = new DirectoryInfo(directoryBin.Parent.FullName).FullName;


            if (new DirectoryInfo(FolderName).Exists)
            {
                folderPath = new DirectoryInfo(FolderName).FullName;

                if (new FileInfo(folderPath + "\\"+FileName).Exists == false)
                {
                    throw eFileNotFound;
                }

                Path = folderPath + "\\" + FileName;
            }
            else
            {
                GetDirectories(ProjectFolder);

                GetFiles();

                foreach(var dir in directories)
                {
                    if (dir.Name == FolderName)
                    {
                        folderPath = dir.FullName;
                        break;
                    }
                }

                if (folderPath == null)
                    throw eFolderNotFount;

                foreach(var file in new DirectoryInfo(folderPath).GetFiles())
                {
                    if (file.Name == FileName)
                    {
                        Path = file.FullName;

                        break;
                    }
                }

                if (Path == null)
                    throw eFileNotFound;
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

                int countOfFiles = 0;

                foreach(var file in files)
                {
                    if (file.Name == FileName)
                    {
                        Path = file.FullName;
                     
                        countOfFiles++;

                        if (countOfFiles > 1)
                        {
                            throw eDublicateFiles;
                        }

                       
                    }
                }
            }
            else
            {
                Path = new FileInfo(FileName).FullName;
               
            }
 
            if (Path == null)
            {
                throw eFileNotFound;
            }
        }
    }
}
