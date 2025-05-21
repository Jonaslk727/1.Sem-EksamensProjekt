//using System;
//using System.Collections.Generic;
//using System.Linq;
//using ClassLibrary1.Models;

//public class KundeRepo
//{
//    private readonly List<Kunde> _kunder = new List<Kunde>();
//    private int _nextId = 1;

//    // Tilføj en ny kunde
//    public void TilføjKunde(Kunde kunde)
//    {
//        kunde.Id = _nextId++;
//        _kunder.Add(kunde);
//    }

//    // Hent en kunde ved ID (OpenKunde)
//    public Kunde OpenKunde(int id)
//    {
//        return _kunder.FirstOrDefault(k => k.Id == id);
//    }

//    // Slet en kunde (SletKunde)
//    public bool SletKunde(int id)
//    {
//        var kunde = OpenKunde(id);
//        if (kunde == null) return false;
//        return _kunder.Remove(kunde);
//    }

//    // Opdater en kunde (RedigerKunde)
//    public bool RedigerKunde(int id, string nyNavn, string nyEmail, int nyMobil)
//    {
//        var kunde = OpenKunde(id);
//        if (kunde == null) return false;

//        kunde.Navn = nyNavn;
//        kunde.Email = nyEmail;
//        kunde.Mobil = nyMobil;
//        return true;
//    }

//    // Hent alle kunder (SeAlleKunder)
//    public List<Kunde> SeAlleKunder()
//    {
//        return new List<Kunde>(_kunder); // Returner en kopi for at undgå ekstern manipulation
//    }
//}