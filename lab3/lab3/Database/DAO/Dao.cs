using System.Collections.Generic;
using lab3.Models;

namespace lab3.Database.DAO
{
    abstract class DAO<T>
    {
        protected Context context;
        protected DAO(Context context)
        {
            this.context = context;
        }

        public abstract void Create(T entity);
        public abstract T Get(long id);
        public abstract List<T> Get(int page);
        public abstract void Update(T entity);
        public abstract void Delete(long id);
    }
}
