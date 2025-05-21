using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models;

namespace ClassLibrary1.Interfaces
{
    public interface IKunde
    {
        void TilføjKunde(Kunde kunde);

        void VisKunde();

        bool FindKunde(int kundeId);

        void OpdaterKunde(int kundeId, Kunde kunde);

        void SletKunde(int kundeId);

        List<Kunde> HentAlleKunder();
    }
}
