using BibliotecaDictionary;

public class Program
{
    static Dictionary<string, CLibro> biblioteca = new Dictionary<string, CLibro>();

    static void Main(string[] args)
    {
        InizializzaBiblioteca();

        try
        {
            RicercaLibro();
            AggiungiLibro();
            ModificaLibro();
            RimuoviLibro();
            StampaCatalogo();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void InizializzaBiblioteca()
    {
        biblioteca.Add("9783161484100", new CLibro("Inferno", "Dante Alighieri", 1300));
        biblioteca.Add("9832492395423", new CLibro("Paradiso", "Dante Alighieri", 1300));
        biblioteca.Add("9825232423423", new CLibro("Purgatorio", "Dante Alighieri", 1300));
        biblioteca.Add("9932523413242", new CLibro("Harry Potter", "J.K. Rowling", 1997));
        biblioteca.Add("9325234212312", new CLibro("Il Signore degli Anelli", "Tolkien", 1954));
    }

    static void RicercaLibro()
    {
        Console.WriteLine("Ricerca libro per ISBN");
        Console.WriteLine("Inserisci un ISBN:");
        string isbn = Console.ReadLine();

        if (biblioteca.TryGetValue(isbn, out CLibro libro))    
        {
            Console.WriteLine(libro.Dettagli());
        }
        else
        {
            Console.WriteLine("Libro non trovato.");
        }
    }

    static void AggiungiLibro()
    {
        Console.WriteLine("Aggiungi nuovo libro");
        Console.WriteLine("Inserisci ISBN:");
        string isbn = Console.ReadLine();

        if (isbn.Length != 13 || !isbn.All(char.IsDigit))      
        {
            Console.WriteLine("ISBN non valido! Deve essere un numero di 13 cifre.");
            return;
        }

        if (biblioteca.ContainsKey(isbn))
        {
            Console.WriteLine("ISBN già presente!");
            return;
        }

        CLibro libro = new CLibro();

        Console.WriteLine("Inserisci il titolo:");
        libro.Titolo = Console.ReadLine();

        Console.WriteLine("Inserisci l'autore:");
        libro.Autore = Console.ReadLine();


        int anno;
        string annStringa;

        do
        {
            Console.WriteLine("Inserisci l'anno:");
            annStringa = Console.ReadLine();

            if (!int.TryParse(annStringa, out anno))
            {
                Console.WriteLine("Anno non valido. Riprova");
            }

        } while (!int.TryParse(annStringa, out anno));
        

        libro.Anno = anno;

        biblioteca.Add(isbn, libro);
        Console.WriteLine("Libro aggiunto correttamente.");
    }

    static void ModificaLibro()
    {
        Console.WriteLine("Modifica titolo libro da ISBN");
        Console.WriteLine("Inserisci ISBN:");
        string isbn = Console.ReadLine();

        if (biblioteca.ContainsKey(isbn))
        {
            Console.WriteLine("Nuovo titolo:");
            biblioteca[isbn].Titolo = Console.ReadLine();
            Console.WriteLine("Titolo aggiornato.");
        } else
        {
            Console.WriteLine("Libro non trovato.");
        }
    }

    static void RimuoviLibro()
    {
        Console.WriteLine("Rimuovi libro da ISBN");
        Console.WriteLine("Inserisci ISBN:");
        string isbn = Console.ReadLine();

        if (biblioteca.ContainsKey(isbn))
        {
            biblioteca.Remove(isbn);
            Console.WriteLine("Libro rimosso correttamente.");
        }
        else
        {
            Console.WriteLine("Libro non trovato.");
        }
    }

    static void StampaCatalogo()
    {
        Console.WriteLine("Catalogo libri:");

        foreach (var item in biblioteca)
        {
            Console.WriteLine($"ISBN: {item.Key}");
            Console.WriteLine(item.Value.Dettagli());
        }
    }
}