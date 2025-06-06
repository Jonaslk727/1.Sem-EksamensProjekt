﻿using ClassLibrary1.Models;

public class KundeRepo
{
    private List<Kunde> _kunder = new List<Kunde>();

    /// <summary>
    /// Tilføjer en ny kunde til samlingen, hvis kunden ikke allerede eksisterer.
    /// </summary>
    /// <remarks>Hvis en kunde med det samme <c>Id</c> allerede findes i samlingen, vil metoden ikke
    /// tilføje kunden og vil vise en besked, der indikerer, at kunden allerede eksisterer. Ellers bliver kunden
    /// tilføjet til samlingen, og en bekræftelsesbesked vises.</remarks>
    /// <param name="kunde">Kunden, der skal tilføjes. Må ikke være null og skal have et unikt <c>Id</c>.</param>
    public void TilføjKunde(Kunde kunde, bool status)
    {
        foreach (var eksisterendeKunde in _kunder)
        {
            if (eksisterendeKunde.KundeId == kunde.KundeId)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n==========================================");
                Console.WriteLine("Kunde findes allerede.");
                Console.WriteLine("==========================================\n");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }
        }
        _kunder.Add(kunde);
        if (status)
        { 
            Console.WriteLine("Kunde tilføjet.");
            Console.ReadKey();
        }
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
            if (_kunder[i].KundeId == id)
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

    // Fixing the type mismatch issue by converting the string 'mobil' to an integer using int.TryParse.
    public void OpdaterKunde(int kundeid, string? navn, string? email, string? mobil)
    {
        try
        {
            foreach (var kunde in _kunder)
            {
                if (kunde.KundeId == kundeid)
                {
                    if (!string.IsNullOrEmpty(navn)) kunde.Navn = navn;
                    if (!string.IsNullOrEmpty(email)) kunde.Email = email;

                    // Convert 'mobil' to an integer if it is not null or empty
                    if (!string.IsNullOrEmpty(mobil) && int.TryParse(mobil, out int mobilInt))
                    {
                        kunde.Mobil = mobilInt;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nKunde opdateret succesfuldt!");
                    Console.ResetColor();
                    return;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nIngen kunde fundet med ID " + kundeid + ".");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nEn fejl opstod under opdatering af kunden:");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }

    // Vis alle kunder
    public void VisKunder()
    {
        if (_kunder.Count == 0)
        {
            Console.WriteLine("Ingen kunder fundet.");
            Console.ReadKey();
            return;
        }
        else
        {
            Console.WriteLine("Kunder i systemet:");
            foreach (var kunde in _kunder)
            {
                Console.WriteLine(kunde.VisInfo());
            }
        }
        Console.WriteLine("\nTryk på en tast for at vende tilbage...");
        Console.ReadKey();

        Console.WriteLine("\n=== Liste over kunder ===");
        foreach (var kunde in _kunder)
        {
            Console.WriteLine($"ID: {kunde.KundeId}, Navn: {kunde.Navn}, Email: {kunde.Email}, Mobil: {kunde.Mobil}");
        }
    }

    // Find en kunde ved ID
    public bool FindKunde(int id)
    {
        foreach (var kunde in _kunder)
        {
            if (kunde.KundeId == id)
            {
                return true;
            }
        }
        return false;
    }
}