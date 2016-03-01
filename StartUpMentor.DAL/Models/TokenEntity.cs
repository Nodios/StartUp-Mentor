using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartUpMentor.DAL.Models
{
	public class TokenEntity
	{
		[Column(Order = 0), Key]
		public Guid UserId { get; set; }

		[Column(Order = 1), Key]
		[StringLength(88, MinimumLength = 88)]
		public string tokenHash { get; set; }

		public DateTime expiryDate { get; set; }
	}
}
