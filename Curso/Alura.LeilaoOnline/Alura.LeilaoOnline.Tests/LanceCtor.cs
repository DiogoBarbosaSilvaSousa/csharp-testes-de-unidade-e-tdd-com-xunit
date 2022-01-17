using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoArgumentoNegativo()
        {
            //Arranje
            var valorNegativo = -100;

            //Assert
            Assert.Throws<System.ArgumentException>(
                //Act
                () => { return new Lance(null, valorNegativo); }  
            );
        }
    }
}
