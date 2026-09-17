using Katas.Clients;

namespace Katas.Tests
{
    public class ClientTests
    {
        //- un client créé avec des données valides a bien son nom, son email et un Id non vide ;
        public void Verifier_Client_Valide()
        {
            Client client = new("Arya", "Arya@msn.fr");

            Assert.True(client.Id != Guid.Empty);
            Assert.False(string.IsNullOrWhiteSpace(client.Nom));
            Assert.False(client.Nom.StartsWith(" ") || client.Nom.EndsWith(" "));
            Assert.False(string.IsNullOrWhiteSpace(client.Email));
        }


        //- le nom est « nettoyé » : "  Acme  " → "Acme" ;

        //- un nom null, vide ou fait d'espaces lève une exception ;

        //- un email sans @ lève une exception ;

        //- ChangerEmail avec un email valide change l'email ;

        //- ChangerEmail avec un email invalide lève une exception et garde l'ancien email ;

        //- deux clients avec les mêmes données ne sont pas égaux.

    }
}
