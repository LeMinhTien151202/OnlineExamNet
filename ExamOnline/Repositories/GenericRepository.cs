using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ExamOnlineContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(ExamOnlineContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> CreateAsync(T entity)
    {
        var entry = await _dbSet.AddAsync(entity);
        return entry.Entity;
    }

    public async Task<T?> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null) return false;
        _dbSet.Remove(entity);
        return true;
    }
}