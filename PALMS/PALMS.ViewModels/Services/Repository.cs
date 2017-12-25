using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALMS.ViewModels.Services
{
    public class Repository : IRepository
    {
        private readonly IApiHelper _apiHelper;
        private readonly IDialogService _dialogService;

        public Repository(IApiHelper apiHelper, IDialogService dialogService)
        {
            _apiHelper = apiHelper;
            _dialogService = dialogService;
        }

        public async Task<List<T>> GetItemsAsync<T>() where T : IEntity
        {
            try
            {
                return await _apiHelper.GetItemsAsync<T>();
            }
            catch (Exception ex)
            {
                LogError(ex, "получения данных");
            }

            return new List<T>();
        }

        private void LogError(Exception exception, string methodType)
        {
            // TODO: log
            var message = $"Ошибка {methodType}: {exception.Message}";
            _dialogService.ShowErrorDialog(message);
        }

        public async Task<T> SaveAsync<T>(T entity) where T : IEntity
        {
            try
            {
                return await _apiHelper.SaveAsync(entity);
            }
            catch (Exception ex)
            {
                LogError(ex, "сохранения");
            }

            return default(T);
        }

        public async Task<T> DeleteAsync<T>(T entity) where T : IEntity
        {
            try
            {
                return await _apiHelper.DeleteAsync<T>(entity.Id);
            }
            catch (Exception ex)
            {
                LogError(ex, "удаления");
            }

            return default(T);
        }
    }
}
