namespace Libreria
{
    public class LibroCartaceo : Libro, IPrestabile
    {
        public bool Prestato
        {
            get => Prestato;
            set
            {
                Prestato = value;
            }
        }

        public override void Dettagli()
        {
            
        }

        public void Presta()
        {
            
        }

        public void Restituisci()
        {
            
        }
    }
}
