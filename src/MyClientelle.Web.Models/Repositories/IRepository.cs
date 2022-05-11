namespace Kampa.MyClientelle.Web.Models.Repositories;

public interface IRepository<in TKey, in TCreate, TRetrieve, in TUpdate>
{
  Task<TRetrieve> Create(TCreate model);

  Task<TRetrieve> GetOne(TKey id);

  Task<List<TRetrieve>> GetAll();

  Task<TRetrieve> Update(TKey id, TUpdate model);

  Task Delete(TKey id);
}
