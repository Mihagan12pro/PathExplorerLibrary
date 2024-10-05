using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PathExplorerLibrary;
namespace PathExplorerLibrary
{
    public abstract class AbstractExplorer
    {
        protected readonly List<PathMaster> pathMasters;
        protected readonly Exception eDublicateObjects = new Exception("Two objects that work with one file's path were found!");


        protected abstract void UniquePaths();
        public AbstractExplorer(PathMaster filePath)
        {
            pathMasters = new List<PathMaster>();
        }
    }

    public class Example : AbstractExplorer
    {
        public readonly PathMaster filePath1,filePath2;
        protected override void UniquePaths()
        {
            //var filePaths = from filePath in pathMasters  select filePath.FilePath;

            //var a = filePaths.Count();
            //var b = a;


            //if (filePaths.Count() != pathMasters.Count)
            //{
            //    throw eDublicateObjects;
            //}
            //ObservableCollection<string> collection = new ObservableCollection<string>();
            
            //foreach(var master in pathMasters)
            //{
            //    collection.Add(master.FilePath);
            //}
            HashSet<string> collection = new HashSet<string>();

            foreach(var master in pathMasters)
            {
                collection.Add(master.FilePath);
            }

            if (collection.Count() != pathMasters.Count)
            {
                throw eDublicateObjects;
            }
        }


        public Example(PathMaster filePath1,PathMaster filePath2) : base(filePath1)
        {
            this.filePath1 = filePath1;
            this.filePath2 = filePath2;


            pathMasters.Add(filePath1);
            pathMasters.Add(filePath2);

            UniquePaths();
        }
    }
}
