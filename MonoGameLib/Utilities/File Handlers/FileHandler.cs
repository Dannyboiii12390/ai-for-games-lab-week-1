using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Utilities.File_Handlers
{
    public abstract class FileHandler<T>
    {
        protected string path;

        public FileHandler(string pPath)
        {
            path = pPath;
        }
        public abstract List<T> Read();

        public abstract void Write(List<T> values);


    }
}
