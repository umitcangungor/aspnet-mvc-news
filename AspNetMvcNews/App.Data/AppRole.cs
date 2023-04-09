using Microsoft.AspNetCore.Identity;

namespace App.Data
{
	public class AppRole : IdentityRole
	{
		public AppRole()
		{
		}

		public AppRole(string roleName) : base(roleName)
		{
		}
		public DateTime CreatedAt { get; set; } = DateTime.Now;
	}
}
