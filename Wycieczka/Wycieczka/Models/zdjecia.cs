using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wycieczka.Models
{
	public class zdjecia
	{
		public int Id{ get; set; }
		public string Url_zdj { get; set; }
		public WycieczkaInfo WycieczkaInfo { get; set; }
	}
}
