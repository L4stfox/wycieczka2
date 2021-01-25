using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wycieczka.Models
{
	public class WycieczkaInfo
	{
		public int ID{ get; set; }
		public string Data { get; set; }
		public string Miejsce_Start { get; set; }
		public string Miejsce_Docelowe { get; set; }
		public double Ilosc_Km { get; set; }
		public int Liczba_Dni { get; set; }
		public string Url_Zdj { get; set; }
		public string Url_Filmu { get; set; }

		public virtual ICollection<zdjecia> Zdjecias { get; set; }



	}
}
