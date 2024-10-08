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


        protected virtual void UniquePaths()
        {
            var collection = (from master in pathMasters select master.FilePath).Distinct();


            if (collection.Count() != pathMasters.Count())
                throw eDublicateObjects;
        }
        public AbstractExplorer(PathMaster filePath)
        {
            pathMasters = new List<PathMaster>();
        }
    }

    public class Example : AbstractExplorer
    {
        public readonly PathMaster filePath1,filePath2;
        //protected override void UniquePaths()
        //{
        //    base.UniquePaths();
        //}


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
