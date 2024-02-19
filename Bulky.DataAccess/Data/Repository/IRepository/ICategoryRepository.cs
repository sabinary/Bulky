using BulkyWeb.Models;

namespace BulkyWeb.Data.Repository.IRepository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void Update(Category obj);
		void Save();
	}
}
