namespace Kampa.MyClientelle.Web.Shared.Repositories;

public interface IRepository<TKey, TCreate, TRetrieve, TUpdate>
{
  Task<TRetrieve> Create(TCreate model);

  Task<TRetrieve> GetOne(TKey id);

  Task<List<TRetrieve>> GetAll();

  Task<TRetrieve> Update(TUpdate model);

  Task Delete(TKey id);
}
