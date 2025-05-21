using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models;
/// <summary>
/// Interface til administration af kundedata.
/// Giver funktionalitet til at oprette, vise, opdatere og slette medarbejdere.
/// </summary>
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
