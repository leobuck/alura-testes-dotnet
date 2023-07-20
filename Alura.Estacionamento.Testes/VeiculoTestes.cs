using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
	public class VeiculoTestes
    {
        // Arrange: Preparacao do cenario
        // Act: Metodo que sera testado
        // Assert: Verificacao do resultado obtido

        [Fact(DisplayName = "TestaVeiculoAcelerarComParametro10")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            // Arrange
            var veiculo = new Veiculo();
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
			var carro = new Veiculo();
			carro.Proprietario = "Carlos Silva";
            carro.Tipo = TipoVeiculo.Automovel;
			carro.Placa = "ZAP-7419";
			carro.Cor = "Verde";
			carro.Modelo = "Variante";

            // Act
            string dados = carro.ToString();

            // Assert
            Assert.Contains("Ficha do Veículo:", dados);
		}
	}
}
