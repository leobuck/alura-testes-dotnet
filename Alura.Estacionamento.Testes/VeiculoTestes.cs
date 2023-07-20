using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
	public class VeiculoTestes : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        // Setup
        public VeiculoTestes(ITestOutputHelper saidaConsoleTeste)
        {
            SaidaConsoleTeste = saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        // Arrange: Preparacao do cenario
        // Act: Metodo que sera testado
        // Assert: Verificacao do resultado obtido

        [Fact(DisplayName = "TestaVeiculoAcelerarComParametro10")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            // Arrange
            //var veiculo = new Veiculo();

            // Act
            veiculo.Acelerar(10);

            // Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "TestaVeiculoFrearComParametro10")]
		[Trait("Funcionalidade", "Frear")]
		public void TestaVeiculoFrearComParametro10()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "TestaTipoDoVeiculo")]
        public void TestaTipoDoVeiculo()
        {
            var veiculo = new Veiculo();
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(DisplayName = "ValidaNomeProprietarioDoVeiculo", Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietarioDoVeiculo()
        {
        }

		[Fact]
		public void FichaDeInformacaoDoVeiculo()
        {
			// Arrange
			//var veiculo = new Veiculo();
			veiculo.Proprietario = "Carlos Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
			veiculo.Placa = "ZAP-7419";
			veiculo.Cor = "Verde";
			veiculo.Modelo = "Variante";

            // Act
            string dados = veiculo.ToString();

            // Assert
            Assert.Contains("Ficha do Veículo:", dados);
		}

		public void Dispose()
		{
			SaidaConsoleTeste.WriteLine("Dispose invocado.");
		}
	}
}
