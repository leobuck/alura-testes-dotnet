﻿using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
	public class PatioTestes : IDisposable
    {
		private Veiculo veiculo;
		public ITestOutputHelper SaidaConsoleTeste;

        // Setup
        public PatioTestes(ITestOutputHelper saidaConsoleTeste)
        {
			SaidaConsoleTeste = saidaConsoleTeste;
			SaidaConsoleTeste.WriteLine("Construtor invocado.");
			veiculo = new Veiculo();
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            // Arrange
            var estacionamento = new Patio();
            //var veiculo = new Veiculo();
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
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(
            string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            var estacionamento = new Patio();
            //var veiculo = new Veiculo();
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
		public void LocalizaVeiculoNoPatioPelaPlaca(string proprietario,
			string placa, string cor, string modelo)
		{
			// Arrange
			var estacionamento = new Patio();
			//var veiculo = new Veiculo();
			veiculo.Proprietario = proprietario;
			veiculo.Placa = placa;
			veiculo.Cor = cor;
			veiculo.Modelo = modelo;
			estacionamento.RegistrarEntradaVeiculo(veiculo);

			// Act
			var consultado = estacionamento.PesquisarVeiculo(veiculo.Placa);

			// Assert
			Assert.Equal(placa, consultado.Placa);
		}

        [Fact]
        public void AlteraDadosDoProprioVeiculo()
        {
			// Arrange
			var estacionamento = new Patio();
			//var veiculo = new Veiculo();
			veiculo.Proprietario = "José Silva";
			veiculo.Placa = "ZXC-8524";
			veiculo.Cor = "Verde";
			veiculo.Modelo = "Opala";
			estacionamento.RegistrarEntradaVeiculo(veiculo);

			var veiculoAlterado = new Veiculo();
			veiculoAlterado.Proprietario = "José Silva";
			veiculoAlterado.Placa = "ZXC-8524";
			veiculoAlterado.Cor = "Preto";
			veiculoAlterado.Modelo = "Opala";

            // Act
            var alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            // Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
		}

		public void Dispose()
		{
			SaidaConsoleTeste.WriteLine("Dispose invocado.");
		}
	}
}
