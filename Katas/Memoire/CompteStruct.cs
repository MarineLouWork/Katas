namespace Katas.Memoire
{
    public struct CompteStruct
    {
        public decimal Solde { get; private set; }

        public void Deposer(decimal montant)
        {
            Solde += montant;
        }
    }
}
