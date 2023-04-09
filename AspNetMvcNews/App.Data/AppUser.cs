using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
	public class AppUser : IdentityUser
	{
		public DateTime CreatedAt { get; set; } = DateTime.Now;
	}
}
