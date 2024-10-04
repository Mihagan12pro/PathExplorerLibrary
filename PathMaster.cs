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
using System.ComponentModel.Design;
namespace PathExplorerLibrary
{

    public class PathMaster
    {
     
        public readonly string FileName;
        public readonly string FolderName;


        public readonly string projectFolder;

        protected List<DirectoryInfo> directories = new List<DirectoryInfo>();
        protected List<FileInfo>files = new List<FileInfo>();

        protected string folderPath;


       

       // public string B;

        public int Size 
        { 
            get
            {
                return directories.Count;
            }
        }

        public string FolderPath
        {
            get
            {
                return folderPath;
            }
        }


        protected string filePath;
        public string FilePath
        {
            get
            {
               
                return filePath;
            }
            protected set
            {
                filePath = value;
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

        public  virtual void SetFullPath(string name)
        {
            if (name == FolderName)
            {
                if (name != null)
                {
                    DirectoryInfo ourDir = (from dir in directories where dir.Name == name select dir).First();

                    if (ourDir == null)
                        throw  DllExceptions.eFolderNotFound;

                    folderPath = ourDir.FullName;
                }
            }
            if (name == FileName)
            {
                if (FolderName == null)
                {
                    var fileCollection = from file in files where file.Name == name select file;

                    if (fileCollection.Count() == 0 || fileCollection == null)
                        throw DllExceptions.eFileNotFound;

                    if (fileCollection.Count() > 1)
                        throw DllExceptions.eDublicateFiles;

                    FilePath = fileCollection.First().FullName;


                    folderPath =   System.IO.Path.GetDirectoryName(FilePath);


                    


                }
                else
                
                    FilePath = folderPath + $"\\{name}";
                
            }
            //if (name == FolderName)
            //{
            //    if (name != null)

            //    {
            //        folderPath = (from dir in directories where dir.FullName.EndsWith(name) select dir.FullName).FirstOrDefault<string>();

            //        if (folderPath == null)
            //            throw eFileNotFound;
            //    }
            //}

            //else 
            //{
            //    if (FolderName != null)
            //    {
            //        Path = folderPath + "\\"+FileName;

            //        if (!File.Exists(Path))
            //            throw eFileNotFound;
                   
            //        return;
            //    }
            //    else
            //    {
            //        var filePathCollection = from  file in files where file.FullName.EndsWith(name) select file;

            //        if (filePathCollection == null)
            //            throw eFileNotFound;
            //        if (filePathCollection.Count() > 1)
            //            throw eDublicateFiles;
            //        if (filePathCollection.FirstOrDefault()==null)
            //            throw eFileNotFound;
            //        Path = filePathCollection.FirstOrDefault().FullName;

            //        if (Path == null)
            //            throw eFileNotFound;
                    
            //    }
            //}
        }

        public PathMaster(string _FileName,string _FolderName)
        {
            Process currentProcess = Process.GetCurrentProcess();




            this.FileName = _FileName;
            if (_FolderName != "")
                this.FolderName = _FolderName;
           

            
            FileInfo fileEXE = new FileInfo(currentProcess.ProcessName + ".exe");

            DirectoryInfo directoryBin = new DirectoryInfo(new DirectoryInfo(fileEXE.DirectoryName).Parent.FullName);



            projectFolder = new DirectoryInfo(directoryBin.Parent.FullName).FullName;

            GetDirectories(projectFolder);
            GetFiles();


            SetFullPath(this.FolderName);
            SetFullPath(this.FileName);

            if (FolderName == null)
                FolderName = new DirectoryInfo(folderPath).Name;

            //    FileInfo fileEXE = new FileInfo(currentProcess.ProcessName + ".exe");

            //    DirectoryInfo directoryBin = new DirectoryInfo(new DirectoryInfo(fileEXE.DirectoryName).Parent.FullName);



            //    ProjectFolder = new DirectoryInfo(directoryBin.Parent.FullName).FullName;


            //    if (new DirectoryInfo(FolderName).Exists)
            //    {
            //        folderPath = new DirectoryInfo(FolderName).FullName;

            //        if (new FileInfo(folderPath + "\\"+FileName).Exists == false)
            //        {
            //            throw eFileNotFound;
            //        }

            //        Path = folderPath + "\\" + FileName;
            //    }
            //    else
            //    {
            //        GetDirectories(ProjectFolder);

            //        GetFiles();

            //        foreach(var dir in directories)
            //        {
            //            if (dir.Name == FolderName)
            //            {
            //                folderPath = dir.FullName;

            //            }
            //        }

            //        if (folderPath == null)
            //            throw eFolderNotFound;

            //        foreach(var file in new DirectoryInfo(folderPath).GetFiles())
            //        {
            //            if (file.Name == FileName)
            //            {
            //                Path = file.FullName;

            //                break;
            //            }
            //        }

            //        if (Path == null)
            //            throw eFileNotFound;
            //    }
        }

    }
}
