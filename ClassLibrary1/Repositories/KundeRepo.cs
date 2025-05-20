using System;
using System.Collections.Generic;
using ClassLibrary1.Models;

public class KundeRepo
{
    private List<Kunde> _kunder = new List<Kunde>();

    /// <summary>
    /// Adds a new customer to the collection if the customer does not already exist.
    /// </summary>
    /// <remarks>If a customer with the same <c>Id</c> already exists in the collection, the method will not
    /// add the customer and will display a message indicating that the customer already exists. Otherwise, the customer
    /// is added to the collection, and a confirmation message is displayed.</remarks>
    /// <param name="kunde">The customer to add. Must not be null and must have a unique <c>Id</c>.</param>
    public void TilføjKunde(Kunde kunde)
    {
        foreach (var eksisterendeKunde in _kunder)
        {
            if (eksisterendeKunde.Id == kunde.Id)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n==========================================");
                Console.WriteLine("Kunde findes allerede.");
                Console.WriteLine("==========================================\n");
                Console.ResetColor();
                return;
            }
        }
        _kunder.Add(kunde);
        Console.WriteLine("Kunde tilføjet.");
    }

    // Hent en kunde ved ID
    public Kunde HentKunde(int id)
    {
        foreach (var kunde in _kunder)
        {
            if (kunde.KundeId == id)
            {
                return kunde;
            }
        }
        return null; // Hvis ingen kunde blev fundet
    }

    // Slet en kunde
    public void SletKunde(int id)
    {
        for (int i = 0; i < _kunder.Count; i++)
        {
            if (_kunder[i].Id == id)
            {
                _kunder.RemoveAt(i);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n==========================================");
                Console.WriteLine("Kunde med ID " + id + " er blevet slettet.");
                Console.WriteLine("==========================================\n");
                Console.ResetColor();
                return;
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n==========================================");
        Console.WriteLine("Ingen kunde fundet med ID " + id + ".");
        Console.WriteLine("==========================================\n");
        Console.ResetColor();
    }

    // Opdater en kunde
    public void OpdaterKunde(int id, string? navn, string? email, Kunde opdateretKunde)
    {
        foreach (var kunde in _kunder)
        {
            if (kunde.Id == id)
            {
                kunde.Navn = opdateretKunde.Navn;
                kunde.Email = opdateretKunde.Email;
                kunde.Mobil = opdateretKunde.Mobil;
                Console.WriteLine("Kunde opdateret.");
                return;
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n==========================================");
        Console.WriteLine("Ingen kunde fundet med ID " + id + ".");
        Console.WriteLine("==========================================\n");
        Console.ResetColor();
    }

    // Vis alle kunder
    public void VisKunder()
    {
        if (_kunder.Count == 0)
        {
            Console.WriteLine("Ingen kunder fundet.");
            return;
        }
        else
        {
            Console.WriteLine("Dyr i systemet:");
            foreach (var dyr in _kunder)
            {
                Console.WriteLine(dyr);
            }
        }
        Console.ReadKey();

        Console.WriteLine("\n=== Liste over kunder ===");
        foreach (var kunde in _kunder)
        {
            Console.WriteLine($"ID: {kunde.Id}, Navn: {kunde.Navn}, Email: {kunde.Email}, Mobil: {kunde.Mobil}");
        }
    }

    // Hent alle kunder
    public List<Kunde> HentAlleKunder()
    {
        return _kunder;
    }

    // Find en kunde ved ID
    public bool FindKunde(int id)
    {
        foreach (var kunde in _kunder)
        {
            if (kunde.Id == id)
            {
                return true;
            }
        }
        return false;
    }
    public Kunde VælgKunde() //Bruges i KundeMenu - tilmeld aktivitet
    {
        Console.Write("Indtast dit kunde-ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            foreach (Kunde k in _kunder)
            {
                if (k.KundeId == id)
                {
                    Console.WriteLine($"Velkommen, {k.Navn}!");
                    return k;
                }
            }
            Console.WriteLine("Kunde ikke fundet.");
        }
        else
        {
            Console.WriteLine("Ugyldigt input.");
        }

        return null;
    }

    public void OpdaterKunde(int kundeId, string? navn, string? email, string? mobil)
    {
        throw new NotImplementedException();
    }
}
