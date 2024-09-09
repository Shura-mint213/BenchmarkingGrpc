using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    /// <summary>
    /// Интерфейс для получения данных из источников
    /// </summary>
    /// <typeparam name="TModel">Модель данных источника</typeparam>
    public interface IRepositoryCore<TModel>
    {
        /// <summary>
        /// Получение коллекции моделей данных из источника
        /// </summary>
        /// <returns>Коллекция моделей данных</returns>
        public Task<IEnumerable<TModel>> GetAsync();

        /// <summary>
        /// Получение коллекции моделей данных из источника с учетом 
        /// количества пропускаемых записей <paramref name="skip"/> и 
        /// количества записей для выборки <paramref name="take"/>
        /// </summary>
        /// <returns>Коллекция моделей данных</returns>
        public Task<IEnumerable<TModel>> GetAsync(int skip, int take);
    }

}
