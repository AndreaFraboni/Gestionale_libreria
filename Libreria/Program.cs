using Libreria;

internal class Program
{
    private static void Main(string[] args)
    {
        bool stato_loop = true;

        while (stato_loop)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1 - Aggiungi libro");
            Console.WriteLine("2 - Elenca libri");
            Console.WriteLine("3 - Cerca libro");
            Console.WriteLine("4 - Rimuovi libro");
            Console.WriteLine("5 - Presta libro");
            Console.WriteLine("6 - Restituisci libro");
            Console.WriteLine("0 - Esci");
            Console.Write("Scelta: ");
            string? scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    AggiungiLibro();
                    Console.WriteLine("--- premi un tasto ---");
                    Console.ReadKey();
                    break;
                case "2":
                    ElencaLibri();
                    Console.WriteLine("--- premi un tasto ---");
                    Console.ReadKey();
                    break;
                case "3":
                    CercaLibro();
                    Console.WriteLine("--- premi un tasto ---");
                    Console.ReadKey();
                    break;
                case "4":
                    RimuoviLibro();
                    Console.WriteLine("--- premi un tasto ---");
                    Console.ReadKey();
                    break;
                case "5":
                    PrestaLibro();
                    Console.WriteLine("--- premi un tasto ---");
                    Console.ReadKey();
                    break;
                case "6":
                    RestituisciLibro();
                    Console.WriteLine("--- premi un tasto ---");
                    Console.ReadKey();
                    break;
                case "0":
                    Console.WriteLine("Esco!!!!");
                    stato_loop = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    Console.WriteLine("--- premi un tasto ---");
                    Console.ReadKey();
                    break;
            }

            Console.Clear();

        }

        static void AggiungiLibro()
        {
            Libro libro;

            Console.WriteLine("======== Inserimento nuovo libro ========");
            Console.Write("il Libro da inserire è cartaceo o Digitale ?? (C o D)");
            string tipo = Console.ReadLine();
            if (tipo == null)
            {
                tipo = "";
            }
            tipo = tipo.ToUpper();
            while (tipo != "C" && tipo != "D")
            {
                Console.Write("Scelta non valida! Inserisci C o D: ");
                tipo = Console.ReadLine();
                if (tipo == null)
                {
                    tipo = "";
                }
                tipo = tipo.ToUpper();
            }
            if (tipo == "C")
            {
                Console.WriteLine("======== Aggiungi Libro cartaceo ========");
                LibroCartaceo cartaceo = new LibroCartaceo();

                Console.Write("Numero di pagine: ");
                int pagine;
                while (!int.TryParse(Console.ReadLine(), out pagine) || pagine <= 0)
                {
                    Console.WriteLine("Numero pagine non valido, riprova !!!");
                }

                cartaceo.NumeroPagine = pagine;
                cartaceo.Prestato = false;

                libro = cartaceo;
            }
            else
            {
                Console.WriteLine("======== Aggiungi Libro digitale ========");

                LibroDigitale digitale = new LibroDigitale();

                decimal dimensione;

                Console.Write("Dimensione MB: ");

                while (!decimal.TryParse(Console.ReadLine(), out dimensione) || dimensione <= 0)
                {
                    Console.Write("Dimensione non valida, riprova: ");
                }

                digitale.DimensioneMB = dimensione;

                libro = digitale;
            }

            Console.Write("Inserisci il titolo: ");
            string titolo = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(titolo))
            {
                Console.Write("Titolo non valido, riprova: ");
                titolo = Console.ReadLine();
            }

            Console.Write("Inserisci l'autore: ");
            string autore = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(autore))
            {
                Console.Write("Autore non valido, riprova: ");
                autore = Console.ReadLine();
            }

            Console.Write("Anno di pubblicazione: ");
            int anno;
            while (!int.TryParse(Console.ReadLine(), out anno) || anno <= 0)
            {
                Console.WriteLine("Anno non valido, riprova:");
            }

            Console.WriteLine("Devi inserire il genere del libro e i Generi disponibili sono i seguenti : ");
            foreach (string generi in Enum.GetNames<Genere>())
            {
                Console.WriteLine(generi);
            }
            Genere genere = default;
            bool valido = false;
            while (!valido)
            {
                Console.Write("Inserisci il genere: ");
                string scelta = Console.ReadLine();
                try
                {
                    genere = Enum.Parse<Genere>(scelta, true);

                    if (Enum.IsDefined(genere))
                    {
                        valido = true;
                    }
                    else
                    {
                        Console.WriteLine("Genere non valido!");
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Genere non valido! Riprova.");
                }
            }


            libro.Titolo = titolo;
            libro.Autore = autore;
            libro.AnnoPubblicazione = anno;
            libro.Genere = genere;

            Biblioteca.Aggiungi(libro);

            //Console.WriteLine("Libro aggiunto correttamente!");

        }

        static void ElencaLibri()
        {
            Biblioteca.Elenca();
        }

        static void CercaLibro()
        {
            Console.Write("Inserisci il titolo del libro da cercare : ");
            string titolo = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(titolo))
            {
                Console.Write("Titolo non valido, riprova: ");
                titolo = Console.ReadLine();
            }


            Libro libro = Biblioteca.Cerca(titolo);
            if (libro != null)
            {
                Console.WriteLine("Libro trovato!");
                Console.WriteLine(libro.Dettagli());
            }
            else
            {
                Console.WriteLine("Libro non trovato!");
            }
        }

        static void RimuoviLibro()
        {
            Console.Write("Inserisci il Titolo del libro da rimuovere : ");
            string titolo = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(titolo))
            {
                Console.Write("Titolo non valido, riprova: ");
                titolo = Console.ReadLine();
            }

            Libro libro = Biblioteca.Cerca(titolo);

            if (libro != null)
            {
                Biblioteca.Rimuovi(libro);
            }
            else
            {
                Console.WriteLine("Libro non trovato!");
            }
        }

        static void PrestaLibro()
        {
            Console.Write("Inserisci il Titolo del libro da prestare : ");
            string titolo = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(titolo))
            {
                Console.Write("Titolo non valido, riprova: ");
                titolo = Console.ReadLine();
            }

            Libro libro = Biblioteca.Cerca(titolo);

            if (libro is IPrestabile prestabile)
            {
                prestabile.Presta();
            }
            else
            {
                Console.WriteLine("Libro non trovato o non prestabile!");
            }
        }

        static void RestituisciLibro()
        {
            Console.Write("Titolo del libro da restituire: ");
            string titolo = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(titolo))
            {
                Console.Write("Titolo non valido, riprova: ");
                titolo = Console.ReadLine();
            }

            Libro libro = Biblioteca.Cerca(titolo);

            if (libro is IPrestabile prestabile)
            {
                prestabile.Restituisci();
            }
            else
            {
                Console.WriteLine("Libro non trovato o non prestabile!");
            }
        }
    }
}