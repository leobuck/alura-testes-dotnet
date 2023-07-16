using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        // Arrange: Preparacao do cenario
        // Act: Metodo que sera testado
        // Assert: Verificacao do resultado obtido

        [Fact(DisplayName = "Teste nº1")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            // Arrange
            var veiculo = new Veiculo();
            // Act
            veiculo.Acelerar(10);
            // Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste nº2")]
		[Trait("Funcionalidade", "Frear")]
		public void TestaVeiculoFrear()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste nº3")]
        public void TestarTipoVeiculo()
        {
            var veiculo = new Veiculo();
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(DisplayName = "Teste nº4", Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {
        }
    }
}
