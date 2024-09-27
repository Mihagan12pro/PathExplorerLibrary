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
        public AbstractExplorer(FilePath filePath)
        {
            
        }
    }

    public class Example : AbstractExplorer
    {
        public readonly FilePath filePath1,filePath2;
        public Example(FilePath filePath1,FilePath filePath2) : base(filePath1)
        {
            this.filePath1 = filePath1;
            this.filePath2 = filePath2;

            if (filePath1.Path == filePath2.Path)
            {
                throw eDublicateObjects;
            }
        }
    }
}
