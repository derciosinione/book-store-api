using System.Threading.Tasks;
using System;
using Bookstore.Api.Models;

namespace Bookstore.Api.IRepository
{
  public interface IUnitOfWork : IDisposable
  {
    IGenericRepository<Authors> Authors { get; }
    IGenericRepository<Category> Categories { get; }
    IGenericRepository<BookSales> BookSales { get; }
    IGenericRepository<Books> Books { get; }
    Task ToSave();
  }
}