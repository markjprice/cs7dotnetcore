using System;
using Microsoft.AspNetCore.Mvc;

using Ch15_MobileApp.Models;


namespace Ch15_MobileApp.Controllers
{
	[Route("api/[controller]")]
	public class ItemController : Controller
	{

		private readonly IItemRepository _ItemRepository;

		public ItemController(IItemRepository ItemRepository)
		{
			_ItemRepository = ItemRepository;
		}

		// GET: api/values
		[HttpGet]
		public IActionResult List()
		{
			return Ok(_ItemRepository.GetAll());
		}

		[HttpGet("{Id}")]
		public Item GetItem(string id)
		{
			Item item = _ItemRepository.Get(id);
			return item;
		}

		[HttpPost]
		public IActionResult Create([FromBody]Item item)
		{
			try
			{
				if (item == null || !ModelState.IsValid)
				{
					return BadRequest("Invalid State");
				}

				_ItemRepository.Add(item);

			}
			catch (Exception)
			{
				return BadRequest("Error while creating");
			}
			return Ok(item);
		}

		[HttpPut]
		public IActionResult Edit([FromBody] Item item)
		{
			try
			{
				if (item == null || !ModelState.IsValid)
				{
					return BadRequest("Invalid State");
				}
				_ItemRepository.Update(item);
			}
			catch (Exception)
			{
				return BadRequest("Error while creating");
			}
			return NoContent();
		}

		[HttpDelete("{Id}")]
		public void Delete(string id)
		{
			_ItemRepository.Remove(id);

		}
	}
}
