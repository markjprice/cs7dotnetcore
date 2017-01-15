using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Ch15_MobileApp.Models
{
	public class ItemRepository : IItemRepository
	{
		private static ConcurrentDictionary<string, Item> _items =
			new ConcurrentDictionary<string, Item>();

		public ItemRepository()
		{
			Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Sharp", Description = "C# is very sharp!" });
		}

		public Item Get(string id)
		{
			return _items[id];
		}

		public IEnumerable<Item> GetAll()
		{
			return _items.Values;
		}

		public void Add(Item item)
		{
			item.Id = Guid.NewGuid().ToString();
			_items[item.Id] = item;
		}

		public Item Find(string id)
		{
			Item item;
			_items.TryGetValue(id, out item);

			return item;
		}

		public Item Remove(string id)
		{
			Item item;
			_items.TryRemove(id, out item);

			return item;
		}

		public void Update(Item item)
		{
			_items[item.Id] = item;
		}
	}
}
