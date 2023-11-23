using MonoGameLib.Utilities.File_Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Utilities
{
    public class TextFileHandler<T> : FileHandler<T>
    {
        public TextFileHandler(string path) : base(path) 
		{ 
		
		}

		public override List<T> Read()
		{
			throw new NotImplementedException();
		}

		public override void Write(List<T> values)
		{
			throw new NotImplementedException();
		}
	}
}
