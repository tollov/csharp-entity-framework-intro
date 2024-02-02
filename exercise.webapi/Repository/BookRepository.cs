﻿using exercise.webapi.Data;
using exercise.webapi.Models.BaseModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.webapi.Repository
{
    public class BookRepository: IRepository<Book>
    {
        DataContext _db;
        
        public BookRepository(DataContext db)
        {
            _db = db;
        }

        public Task<Book> Delete(object id)
        {
            Book entity = _db.Books.FindAsync(id).Result;
            _db.Remove(entity);
            _db.SaveChangesAsync();
            return Task.FromResult(entity);
        }

        public async Task<Book> Get(object id)
        {
            return await _db.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.ID == (int)id);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _db.Books.Include(b => b.Author).ToListAsync();
        }

        public Task<Book> Insert(Book book)
        {
            _db.AddAsync(book);
            _db.SaveChangesAsync();
            return Task.FromResult(book);
        }

        public async Task<Book> Update(Book book)
        {
            _db.Books.Attach(book);
            _db.Entry(book).State = EntityState.Modified;
            _db.SaveChangesAsync();
            return book;
        }

        public async Task<bool> IsAnExistingID(object id)
        {
            var book = await _db.Books.FindAsync(id);
            return book != null;
        }

    }
}
