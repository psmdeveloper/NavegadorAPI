using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NavegadorAPI.Domain;

namespace NavegadorAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class NavegadorController : ControllerBase
	{
		[HttpGet("DistanciaPercorrida")]
		public async Task<ActionResult<Destino>> DistanciaPercorrida(Destino destino)
		{
			try
			{
				destino.DistanciaPercorrida();
				return destino;
			}
			catch (DestinoException e)
			{
				return BadRequest(e.Motivos);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("QuantidadeLitrosConsumidos")]
		public async Task<ActionResult<Destino>> QuantidadeLitrosConsumidos(Destino destino)
		{
			try
			{
				destino.QuantidadeLitrosConsumidos();
				return destino;
			}
			catch (DestinoException e)
			{
				return BadRequest(e.Motivos);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("VelocidadeMedia")]
		public async Task<ActionResult<Destino>> VelocidadeMedia(Destino destino)
		{
			try
			{
				destino.VelocidadeMedia();
				return destino;
			}
			catch (DestinoException e)
			{
				return BadRequest(e.Motivos);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("TempoGasto")]
		public async Task<ActionResult<Destino>> TempoGasto(Destino destino)
		{
			try
			{
				destino.TempoGasto();
				return destino;
			}
			catch (DestinoException e)
			{
				return BadRequest(e.Motivos);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

	}
}
