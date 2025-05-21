using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Interfaces
{
    internal interface ICRUD
    {
        public void Create();
        public void Read();
        public void Update();
        public void Delete();
    }
}
