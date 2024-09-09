using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepositoryCRUDCore<TModel, TIdModel> : IRepositoryCore<TModel>
    {
        public Task<bool> DeleteAsync(TModel model);
        public Task<bool> DeleteAsync(TIdModel id);
        public Task<TModel> UpdateAsync(TModel model);
        public Task<TModel> CreateAsync(TModel model);
    }
}
