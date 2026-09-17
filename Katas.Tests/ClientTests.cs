using Katas.Clients;

namespace Katas.Tests
{
    public class ClientTests
    {
        const string nomValide = "Arya";
        const string emailValide = "Arya@msn.fr";
        const string emailChange = "Stark@msn.fr";

        // On vérifie que des données valides sont correctement assignées à un Client
        [Fact]
        public void Client_DonneesValides_Assignees()
        {
            Client client = new(nomValide, emailValide);

            Assert.True(client.Id != Guid.Empty);
            Assert.Equal(nomValide, client.Nom);
            Assert.Equal(emailValide, client.Email);
        }

        // On vérifie qu'un nom contenant des espaces en début et/ou en fin de chaine soit bien nettoyé
        [Theory]
        [InlineData(" " + nomValide + " ")]
        [InlineData(" " + nomValide)]
        [InlineData(nomValide + " ")]
        public void Client_NomAvecEspaces_Nettoye(string nom)
        {
            Client client = new(nom, emailValide);

            Assert.False(client.Nom.StartsWith(" "));
            Assert.False(client.Nom.EndsWith(" "));
            Assert.DoesNotContain(" ", client.Nom);
        }

        // On vérifie qu'un nom null, vide, ou fait d'espaces lève une exception
        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Client_NomInvalide_LeveException(string? nom)
        {
            var action = () => new Client(nom, emailValide);

            Assert.Throws<ArgumentException>(action);
        }

        // On vérifie qu'un email ne contenant pas de @ lève une exception
        [Theory]
        [InlineData("emailSansArobas")]
        [InlineData(null)]
        public void Client_EmailInvalide_LeveException(string? email)
        {
            var action = () => new Client(nomValide, email);

            Assert.Throws<ArgumentException>(action);
        }

        // On vérifie que la méthode ChangerEmail avec un email valide fonctionne
        [Fact]
        public void ClientChangerEmail_EmailValide_Assigne()
        {
            Client client = new(nomValide, emailValide);

            client.ChangerEmail(emailChange);

            Assert.Equal(emailChange, client.Email);
        }

        // On vérifie que la méthode ChangerEmail avec un email invalide lève une exception
        [Fact]
        public void ClientChangerEmail_EmailValide_LeveException()
        {
            Client client = new(nomValide, emailValide);

            var action = () => client.ChangerEmail(nomValide);

            Assert.Throws<ArgumentException>(action);
        }

        // On vérifie que deux clients avec les mêmes données ne sont pas égaux
        [Fact]
        public void Clients_DonneesIdentiques_PasEgaux()
        {
            Client clientA = new(nomValide, emailValide);
            Client clientB = new(nomValide, emailValide);

            Assert.NotSame(clientA, clientB);
        }
    }
}
