using Bulky.Models;
using Bulky.DataAccess;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository.IRepository
{
	public interface IProductRepository : IRepository<Product>
	{
		public void Add(Product obj);

		public Product Get(Expression<Func<Product, bool>> filter);

		public IEnumerable<Product> GetAll();

		public void Remove(Product obj);

		void Update(Product obj);
		void Save();
	}
}
