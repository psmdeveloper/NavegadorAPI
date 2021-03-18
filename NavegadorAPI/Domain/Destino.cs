using System;

namespace NavegadorAPI.Domain
{
	public class Destino
	{

		#region Atributos
		private readonly DestinoException exception;
		#endregion

		#region Propriedades
		public double CoordenadaInicial { get; set; }
		public double CoordenadaFinal { get; set; }
		public double ConsumoMedioCombustivel { get; set; }

		public double Velocidade { get; set; }
		public double Distancia { get; set; }
		public double Tempo { get; set; }
		public double ConsumoCombustivel { get; set; }

		#endregion

		#region Construto
		public Destino()
		{
			exception = new DestinoException();
		}

		#endregion

		#region Métodos
		/// <summary>
		/// Efetua o cálculo de distãncia a percorrer entre as duas coordenadas informadas.
		/// </summary>
		public void DistanciaPercorrida()
		{
			try
			{
				if (!IsValidForDistanciaPercorrida())
				{
					throw exception;
				}

				checked
				{
					Distancia = CoordenadaFinal - CoordenadaInicial;
				}

			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Efetua o cálculo de combustivel consumido na distãncia a perorrer.
		/// Unidade de medida : Litros
		/// </summary>
		public void QuantidadeLitrosConsumidos()
		{
			try
			{
				if(!IsValidForQuantidadeLitrosConsumidos())
				{
					throw exception;
				}

				checked
				{
					DistanciaPercorrida();
					ConsumoCombustivel = Distancia * ConsumoMedioCombustivel;
				}

			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Efetua o cálculo de velocidade média, usado durante o percurso.
		/// Unidade de medida : KM/h
		/// </summary>
		public void VelocidadeMedia()
		{
			try
			{
				if(!IsValidForVelocidadeMedia())
				{
					throw exception;
				}

				checked
				{
					DistanciaPercorrida();
					Velocidade = (Distancia / Tempo) * 60;
				}

			}
			catch (Exception)
			{
				throw;
			}
		}
		
		/// <summary>
		/// Efetua o cálculo de tempo, gasto durante o percurso.
		/// Unidade de medida : minutos
		/// </summary>
		public void TempoGasto()
		{
			try
			{
				if(!IsValidForTempoGasto())
				{
					throw exception;
				}

				checked
				{
					DistanciaPercorrida();
					Tempo = (int)((Distancia / Velocidade) * 60);
				}

			}
			catch (Exception)
			{
				throw;
			}
		}

		private bool IsValidForDistanciaPercorrida()
		{
			bool valid = true;

			valid = valid && (CoordenadaInicial != 0);
			if (!valid)
			{
				exception.Motivos.Add(nameof(CoordenadaInicial), "Inválido.Valor deve ser dif. de zero");
			}

			valid = valid && (CoordenadaFinal != 0);
			if (!valid)
			{
				exception.Motivos.Add(nameof(CoordenadaFinal), "Inválido.Valor deve ser dif. de zero");
			}

			// Verifica se as coordenadas se anulam, ou seja, ná demonstram que houve deslocamento.
			valid = valid && ((CoordenadaInicial + CoordenadaFinal) != 0);
			if (!valid)
			{
				exception.Motivos.Add("Coordenadas", "Inválido.Coordenadas não devem caracterizar anulação de deslocamento, ou seja, zerar.");
			}

			return valid;
		}
		private bool IsValidForQuantidadeLitrosConsumidos()
		{
			bool valid = true;

			valid = valid & IsValidForDistanciaPercorrida();

			valid = valid && (ConsumoMedioCombustivel > 0);

			if (!valid)
			{
				exception.Motivos.Add(nameof(ConsumoMedioCombustivel), "Inválido.");
			}

			return valid;
		}
		private bool IsValidForVelocidadeMedia()
		{
			bool valid = true;

			valid = valid && IsValidForDistanciaPercorrida();

			valid = valid && (Tempo > 0);
			if (!valid)
			{
				exception.Motivos.Add(nameof(Tempo), "Inválido.Forneça valor em unidade de tempo - minuto.");
			}
			return valid;
		}
		private bool IsValidForTempoGasto()
		{
			bool valid = true;

			valid = valid && IsValidForDistanciaPercorrida();

			valid = valid && (Velocidade > 0);
			if (!valid)
			{
				exception.Motivos.Add(nameof(Velocidade), "Inválido.");
			}

			return valid;
		}
		#endregion
	}
}
