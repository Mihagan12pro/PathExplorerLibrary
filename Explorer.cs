using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PathExplorerLibrary;
namespace PathExplorerLibrary
{
    public abstract class AbstractExplorer
    {
        protected readonly Exception eDublicateObjects = new Exception("Two objects that work with one file's path were found!");
        public AbstractExplorer(PathMaster filePath)
        {
            
        }
    }

    public class Example : AbstractExplorer
    {
        public readonly PathMaster filePath1,filePath2;
        public Example(PathMaster filePath1,PathMaster filePath2) : base(filePath1)
        {
            this.filePath1 = filePath1;
            this.filePath2 = filePath2;

            if (filePath1.FilePath == filePath2.FilePath)
            {
                throw eDublicateObjects;
            }
        }
    }
}
