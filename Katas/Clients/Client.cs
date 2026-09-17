namespace Katas.Clients
{
    public class Client
    {
        public Guid Id { get; }

        public string Nom { get; }

        public string Email { get; private set; }

        public Client(string nom, string email)
        {
            if (string.IsNullOrWhiteSpace(nom))
                throw new ArgumentException("Le nom est obligatoire.", nameof(nom));

            Id = Guid.NewGuid();
            Nom = nom.Trim();
            Email = ValiderEmail(email);
        }

        public void ChangerEmail(string email)
        {
            Email = ValiderEmail(email);
        }

        private static string ValiderEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("L'email est obligatoire.", nameof(email));

            if (!email.Contains('@'))
                throw new ArgumentException("L'email doit contenir un @.", nameof(email));

            return email.Trim();
        }
    }
}
