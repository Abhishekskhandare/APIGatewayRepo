using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroService2.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AccountController : ControllerBase
	{
		[Route("getaccounts")]
		public IEnumerable<object> GetAccounts()
		{
			string[] names = { "Abhishek", "Rahul", "Priya", "Amit", "Neha" };
			string[] domains = { "gmail.com", "outlook.com", "test.com" };

			return Enumerable.Range(1, 5)
				.Select(index => new
				{
					AccountId = index,
					AccountHolderName = names[Random.Shared.Next(names.Length)],
					Email = $"{names[Random.Shared.Next(names.Length)].ToLower()}@{domains[Random.Shared.Next(domains.Length)]}",
					IsActive = Random.Shared.Next(0, 2) == 1,
					CreatedDate = DateTime.Now.AddDays(-index)
				})
				.ToArray();
		}

	}
}
