#nullable disable
namespace Kampa.MyClientelle.Persistence.Helpers;

public interface IEntity<TKey>
  where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
{
  TKey Id { get; set; }
}

public abstract class Entity<TKey> : IEntity<TKey>
  where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
{
  public TKey Id { get; set; }
}
