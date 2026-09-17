using Katas.Memoire;

namespace Katas.Tests
{
    public class TypesReferenceEtValeurTests
    {
        // Sur une classe, la première référence (a) doit prendre les modifications de la deuxième (b)
        [Fact]
        public void Class_Deposer_100SurB_DeposeAussiSurA()
        {
            var a = new CompteClasse();
            var b = a;

            b.Deposer(100);

            Assert.Equal(100, a.Solde);
        }

        // Sur une Structure, la première variable (a) ne doit pas prendre les modifications de la deuxième (b)
        [Fact]
        public void Struct_Deposer_100SurB_NeDeposePasSurA()
        {
            var a = new CompteStruct();
            var b = a;

            b.Deposer(100);

            Assert.Equal(0, a.Solde);
            Assert.Equal(100, b.Solde);
        }

        // Sur un Record, la première référence (a) ne doit pas prendre les modifications de la deuxième (b) car instanciée avec "with"
        [Fact]
        public void Record_With100SurB_NeValorisePasA()
        {
            var a = new CompteRecord(0);

            var b = a with { Solde = 100 };

            Assert.Equal(0, a.Solde);
            Assert.Equal(100, b.Solde);
        }

        // On vérifie l'exactitude d'un type decimal, et l'inexactitude du type Double
        [Fact]
        public void Addition_0v1Plus0v2_ExacteEnDecimalMaisPasEnDouble()
        {
            Assert.NotEqual(0.3, 0.1 + 0.2);

            Assert.Equal(0.3m, 0.1m + 0.2m);
        }
    }
}
