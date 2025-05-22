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

    // Opdaterer en kunde
    public void OpdaterKunde(int kundeid, string? navn, string? email, string? mobil)
    {
        try
        {
            //Gennemgår listen for at finde kunedn med edt angivne ID
            foreach (var kunde in _kunder)
            {
                if (kunde.KundeId == kundeid)
                {
                    //opdaterer kundens oplysninger, hvis de ikke er null
                    if (!string.IsNullOrEmpty(navn)) kunde.Navn = navn;
                    if (!string.IsNullOrEmpty(email)) kunde.Email = email;
                    if (!string.IsNullOrEmpty(mobil)) kunde.Mobil = mobil;


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nKunde opdateret succesfuldt!");
                    Console.ResetColor();
                    return;
                }
            }

            //Hvis kunden ikke blev fundet
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nIngen kunde fundet med ID " + kundeid + ".");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            //Håndter eventuelle fejl
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
            if (kunde.KundeId == id)
            {
                return true;
            }
        }
        return false;
    }
    //Bruges i KundeMenu - tilmeld aktivitet
    public Kunde VælgKunde() 
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

}