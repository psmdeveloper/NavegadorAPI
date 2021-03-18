using System;
using System.Collections.Generic;

namespace NavegadorAPI.Domain
{
	public class DestinoException : Exception
	{
		#region Propriedades
		public Dictionary<string, string> Motivos { get; set; }
		#endregion

		#region Construtor
		public DestinoException()
		{
			Motivos = new Dictionary<string, string>();
		}
		#endregion
	}
}
