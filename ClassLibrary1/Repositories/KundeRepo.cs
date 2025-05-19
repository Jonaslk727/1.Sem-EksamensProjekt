using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;

public class KundeRepo
{
    private readonly List<Kunde> _kunder = new List<Kunde>();
    private int _nextId = 1;

    // Tilføj en ny kunde
    public void TilføjKunde(Kunde kunde)
    {
        kunde.Id = _nextId++;
        _kunder.Add(kunde);
    }

    // Hent en kunde ved ID (HentKunde)
    public Kunde HentKunde(int id)
    {
        foreach (Kunde kunde in _kunder)
        {
            if (kunde.Id == id)
            {
                return kunde;
            }
        }
        return null; // Hvis ingen kunde blev fundet
    }

    // Slet en kunde (SletKunde)
    public bool SletKunde(int id)
    {
        var kunde = HentKunde(id);
        if (kunde == null) return false;
        return _kunder.Remove(kunde);
    }

    // Opdater en kunde (RedigerKunde)
    public bool OpdaterKunde(int id, string nyNavn, string nyEmail, string nyMobil)
    {
        var kunde = HentKunde(id);
        if (kunde == null) return false;

        kunde.Navn = nyNavn;
        kunde.Email = nyEmail;
        kunde.Mobil = nyMobil.ToString();
        return true;
    }

    // Hent alle kunder (SeAlleKunder)
    public void PrintKundeList()
    {

        if (KundeList.Count() == 0)
        {
            Console.WriteLine("Ingen dyr i systemet.");
        }
        else
        {
            Console.WriteLine("Dyr i systemet:");
            foreach (var dyr in KundeList.Values)
            {
                Console.WriteLine(dyr);
            }
        }
        Console.ReadKey();
    }

    public bool FindKunde(int kundeId)
    {
        foreach (Kunde kunde in _kunder)
        {
            if (kunde.Id == kundeId)
            {
                return true;
            }
        }
        return false;
    }
}
