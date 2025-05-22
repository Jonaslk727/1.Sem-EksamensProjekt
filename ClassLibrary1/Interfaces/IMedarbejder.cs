using ClassLibrary1.Models;

namespace ClassLibrary1.Interfaces

{
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
