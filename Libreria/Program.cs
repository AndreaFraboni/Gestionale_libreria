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
                    //Console.WriteLine("aggiungerei un libro!");
                    //Console.WriteLine("--- premi un tasto ---");
                    AggiungiLibro();
                    //Console.ReadKey();
                    break;
                case "2":
                    //Console.WriteLine("elencherei il libri disponibili!");                    
                    ElencaLibri();
                    Console.WriteLine("--- premi un tasto ---");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("cercherei un libro!");
                    Console.WriteLine("--- premi un tasto ---");
                    Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine("rimuoverei un libro!");
                    Console.WriteLine("--- premi un tasto ---");
                    Console.ReadKey();
                    break;
                case "5":
                    Console.WriteLine("presto libro!");
                    Console.WriteLine("--- premi un tasto ---");
                    Console.ReadKey();
                    break;
                case "6":
                    Console.WriteLine("restituisci libro!");
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

            Console.Write("Libro cartaceo o Digitale ?? (C o D)");

            string tipo = Console.ReadLine().ToUpper();


            if (tipo == "C")
            {
                Console.WriteLine("======== Aggiungi Libro cartaceo ========");
                LibroCartaceo cartaceo = new LibroCartaceo();

                Console.Write("Numero di pagine: ");
                int pagine;
                while (!int.TryParse(Console.ReadLine(), out pagine) || pagine <= 0)
                {
                    Console.WriteLine("Numero pagine non valido, riprova:");
                }

                cartaceo.NumeroPagine = pagine;
                cartaceo.Prestato = false;

                libro = cartaceo;
            }
            else
            {
                Console.WriteLine("======== Aggiungi Libro digitale ========");
                LibroDigitale digitale = new LibroDigitale();

                Console.Write("Dimensione MB: ");
                digitale.DimensioneMB = decimal.Parse(Console.ReadLine());

                libro = digitale;
            }

            Console.Write("Inserisci il titolo: ");
            string titolo = Console.ReadLine();

            Console.Write("Inserisci l'autore: ");
            string autore = Console.ReadLine();

            Console.Write("Anno di pubblicazione: ");
            int anno;
            while (!int.TryParse(Console.ReadLine(), out anno) || anno <= 0)
            {
                Console.WriteLine("Anno non valido, riprova:");
            }

            Console.Write("Inserisci il genere : ");


            string genere = Console.ReadLine();


            libro.Titolo = titolo;
            libro.Autore = autore;
            libro.AnnoPubblicazione = anno;

            libro.Genere = Genere.Fantasy;

            Biblioteca.Aggiungi(libro);

            Console.WriteLine("Libro aggiunto correttamente!");

        }

        static void ElencaLibri()
        {
            Biblioteca.Elenca();
        }

        static void CercaLibro()
        {
            Console.WriteLine("Ricerca libro");
        }

        static void RimuoviLibro()
        {
            Console.WriteLine("Rimuovi libro");
        }

        static void PrestaLibro()
        {
            Console.WriteLine("Presta libro");
        }

        static void RestituisciLibro()
        {
            Console.WriteLine("Restituisci libro");
        }

    }
}