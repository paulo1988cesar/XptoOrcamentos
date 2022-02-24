using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntitade
    {
        private readonly MyContext _context;
        private DbSet<T> _dataSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public async Task<bool> ExcluiAsync(int id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(c => c.Id.Equals(id));

                if (result != null)
                {
                    _dataSet.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsereAsync(T item)
        {
            try
            {
                item.CriadoEm = DateTime.UtcNow;

                _dataSet.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<T> BuscaAsync(int id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(c => c.Id.Equals(id));

                if (result != null)
                    return result;

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> BuscaAsync()
        {
            try
            {
                var result = await _dataSet.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> AtualizaAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(c => c.Id.Equals(item.Id));

                if (result != null)
                {
                    item.AtualizadoEm = DateTime.UtcNow;
                    item.CriadoEm = result.CriadoEm;

                    _context.Entry(result).CurrentValues.SetValues(item);
                    await _context.SaveChangesAsync();
                    return item;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _dataSet.AnyAsync(c => c.Id.Equals(id));
        }
        
    }
}
