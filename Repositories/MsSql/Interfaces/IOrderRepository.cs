using Northwind.EntityModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.MsSql.Interfaces
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Получения всех заказов
        /// </summary>
        /// <returns>Список заказов</returns>
        Task<List<Order>> GetAsync();
        /// <summary>
        /// Получение заказов для пагинации
        /// </summary>
        /// <param name="skip">Количество пропускаемых записей</param>
        /// <param name="take">Количество получаемых записей</param>
        /// <returns>Список заказов</returns>
        Task<List<Order>> GetAsync(int skip, int take);
    }
}
