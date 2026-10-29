namespace Libreria
{
    public interface IPrestabile
    {
        bool Prestato { get; set; }
        void Presta();
        void Restituisci();
    }
}

