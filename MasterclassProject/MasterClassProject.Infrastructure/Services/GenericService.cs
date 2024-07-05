using MasterClassProject.Domain.Interfaces;
using MasterClassProject.Infrastructure.Context;
using MasterClassProject.Infrastructure.Exceptions;
using MasterCLassProject.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace MasterClassProject.Infrastructure.Services
{
    public class GenericService<T> : IGenericService<T> where T : class, IEntity
    {
        private readonly MasterClass_DbContext _dbContext;

        public GenericService(MasterClass_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T item)
        {
            try
            {
                bool check = await CheckIfItemExist(item);
                if (check)
                {
                    throw new ServiceException(item.Id);
                }

                _dbContext.Set<T>().Add(item);
                await _dbContext.SaveChangesAsync();
                return item;
            }
            catch (ServiceException)
            {
                throw;
            }
            catch (StopBeforeStartException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new ServiceException("Error occurred while adding the item."); ;
            }
        }

        public async Task Delete(long id)
        {
            bool check = await CheckIfItemExistById(id);

            if (!check)
            {
                throw new KeyNotFoundException($"Item with id: {id} not found in database");
            }

            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(long id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Item with id: {id} not found in database");
            }
            return entity;
        }

        public async Task<T> Update(T item)
        {
            _dbContext.Set<T>().Update(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        private async Task<bool> CheckIfItemExist(T item)
        {
            var Itemcheck = await _dbContext.Set<T>().FindAsync(item.Id);
            return Itemcheck != null;
        }

        private async Task<bool> CheckIfItemExistById(long id)
        {
            var Itemcheck = await _dbContext.Set<T>().FindAsync(id);
            return Itemcheck != null;
        }
    }
}