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
