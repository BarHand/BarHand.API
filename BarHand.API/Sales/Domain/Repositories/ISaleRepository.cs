using BarHand.API.Sales.Domain.Models;

using BarHand.API.Sales.Domain.Repositories;

public interface ISaleRepository
{
   Task<IEnumerable<Sales>> ListAsync();
   Task AddAsync(Sales sale);
   Task<Sales> FindByAsync(int id);
   void Update(Sales sale);
   void Remove(Sales sale);
}
