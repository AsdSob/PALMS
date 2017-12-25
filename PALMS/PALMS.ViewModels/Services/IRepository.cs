using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALMS.ViewModels.Services
{
    public interface IRepository
    {
        Task<List<T>> GetItemsAsync<T>() where T : IEntity;
        Task<T> SaveAsync<T>(T entity) where T : IEntity;
        Task<T> DeleteAsync<T>(T entity) where T : IEntity;
    }
}
