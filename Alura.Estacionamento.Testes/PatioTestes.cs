using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Leo";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ASD-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
		[InlineData("José Silva", "POL-9242", "Cinza", "Fusca")]
		[InlineData("Maria Silva", "GDR-6524", "Azul", "Opala")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, 
            string placa, string cor, string modelo)
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

		[Theory]
		[InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
		public void LocalizaVeiculoNoPatio(string proprietario,
			string placa, string cor, string modelo)
		{
			// Arrange
			var estacionamento = new Patio();
			var veiculo = new Veiculo();
			veiculo.Proprietario = proprietario;
			veiculo.Placa = placa;
			veiculo.Cor = cor;
			veiculo.Modelo = modelo;
			estacionamento.RegistrarEntradaVeiculo(veiculo);

			// Act
			var consultado = estacionamento.PesquisaVeiculo(veiculo.Placa);

			// Assert
			Assert.Equal(placa, consultado.Placa);
		}
	}
}
