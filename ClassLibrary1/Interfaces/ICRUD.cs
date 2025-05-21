using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Interface til administration af data fra klasser.
/// Giver funktionalitet til at oprette, vise, opdatere og slette medarbejdere.
/// </summary>

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
