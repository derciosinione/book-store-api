using System;
using System.Threading.Tasks;
using Bookstore.Api.IRepository;
using Bookstore.Api.Models;

namespace Bookstore.Api.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly DataContext _context;
    private IGenericRepository<Authors> _authors;
    private IGenericRepository<Category> _categories;
    private IGenericRepository<Books> _books;
    private IGenericRepository<BookSales> _bookSales;

    public UnitOfWork(DataContext context)
    {
      _context = context;
    }
    public IGenericRepository<Authors> Authors => _authors ??= new GenericRepository<Authors>(_context);

    public IGenericRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context);

    public IGenericRepository<Books> Books => _books ??= new GenericRepository<Books>(_context);

    public IGenericRepository<BookSales> BookSales => _bookSales ??= new GenericRepository<BookSales>(_context);

    public void Dispose()
    {
      _context.Dispose();
      GC.SuppressFinalize(this);
    }

    public async Task ToSave()
    {
      await _context.SaveChangesAsync();
    }
  }
}