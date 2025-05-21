using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Interface til administration af medarbejderdata.
/// Giver funktionalitet til at oprette, vise, opdatere og slette medarbejdere.
/// </summary>

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
