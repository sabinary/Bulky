using Bulky.Models;
using Bulky.DataAccess;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository.IRepository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		public void Add(Category obj);

		public Category Get(Expression<Func<Category, bool>> filter);

		public IEnumerable<Category> GetAll();

		public void Remove(Category obj);

		void Update(Category obj);
		void Save();
	}
}
