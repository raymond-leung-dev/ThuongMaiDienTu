using System.Linq.Expressions;
using DoGiaDung.Domain.Interfaces;
using DoGiaDung.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DoGiaDung.Infrastructure.Repositories;

public class EfRepository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<T> DbSet;

    public EfRepository(AppDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id) => await DbSet.FindAsync(id);

    public async Task<IReadOnlyList<T>> GetAllAsync()
        => await DbSet.ToListAsync();

    public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => await DbSet.Where(predicate).ToListAsync();

    public async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public Task UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        return Context.SaveChangesAsync();
    }

    public Task DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        return Context.SaveChangesAsync();
    }

    public IQueryable<T> Query() => DbSet.AsQueryable();
}
