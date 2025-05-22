using ClassLibrary1.Models;

namespace ClassLibrary1.Interfaces

{
    // -------------------------------------------------------------
    // IMedarbejder interface:  
    // Håndterer medarbejderadministration, inkl. oprettelse,  
    // redigering, søgning og sletning. Sikrer en struktureret  
    // tilgang til datahåndtering i systemet.  
    // -------------------------------------------------------------
    public interface IMedarbejder
    {
        void TilføjMedarbejder(Medarbejder medarbejder);

        void VisMedarbejder();

        bool FindMedarbejder(int medarbejderId);

        void OpdaterMedarbejder(int medarbejederId, Medarbejder medarbejder);

        void SletMedarbejder(int medarbejderId);

        List<Medarbejder> HentAlleMedarbejdere();
    }
}
