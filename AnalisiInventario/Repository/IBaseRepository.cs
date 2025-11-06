using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnalisiOpiniones.Domain.Repository
{
    public interface IBaseRepository <TEntity> where TEntity : class
    {

        Task Save(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);

        Task<List<TEntity>> GetAll();

        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter);

        Task<TEntity?> GetById(int id);

        Task<bool> Exist(Expression<Func<TEntity, bool>> Filter);


    }
}
