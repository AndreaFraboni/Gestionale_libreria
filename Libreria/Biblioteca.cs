namespace Libreria
{
    public static class Biblioteca
    {
        static List<Libro> listOfBooks = new List<Libro>();

        public static Libro Cerca(string Titolo)
        {
            foreach (Libro libro in listOfBooks)
            {
                if (libro.Titolo.Equals(Titolo, StringComparison.OrdinalIgnoreCase))
                {
                    return libro;
                }
            }

            return null;
        }

        public static void Aggiungi(Libro book)
        {
            foreach (Libro libro in listOfBooks)
            {
                if (libro.Titolo.Equals(book.Titolo, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Libro già presente !!!");
                    return;
                }
            }

            listOfBooks.Add(book);
            Console.WriteLine("Libro aggiunto correttamente!");
        }

        public static void Rimuovi(Libro libro)
        {
            if (listOfBooks.Remove(libro))
            {
                Console.WriteLine("Libro rimosso!");
            }
            else
            {
                Console.WriteLine("Libro non trovato!");
            }
        }
        public static void Elenca()
        {
            if (listOfBooks.Count == 0)
            {
                Console.WriteLine("Biblioteca vuota!");
                return;
            }

            foreach (Libro libro in listOfBooks)
            {
                Console.WriteLine(libro.Dettagli());
            }
        }

    }
}
