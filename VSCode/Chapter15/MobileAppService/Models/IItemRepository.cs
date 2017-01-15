using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch15_MobileApp.Models
{
	public interface IItemRepository
	{
		void Add(Item item);
		void Update(Item item);
		Item Remove(string key);
		Item Get(string id);
		IEnumerable<Item> GetAll();
	}
}
