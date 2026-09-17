namespace Katas.Memoire
{
    public class CompteClasse
    {
        public decimal Solde { get; private set; }

        public void Deposer(decimal montant)
        {
            Solde += montant;
        }
    }
}
