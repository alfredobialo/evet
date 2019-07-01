using System;
using wkn.Evet.Abstractions.Core;

namespace wkn.Evet.Abstractions
{
    public abstract class DefPersistableObj<T>  : IPersistableObj<T> where T : DefPersistableObj<T>
    {
        private  IRepository<T> repo;
        public object Id { get; set; }
        public dynamic Tag { get; set; }
        public IRepository<T> DataSource => repo;

        public DefPersistableObj()
        {
            //  DataSource = repo;
            Id = Guid.NewGuid().ToString();
        }

        public string Key => Id?.ToString();
        protected virtual void SetRepo(IRepository<T> repo)
        {
            this.repo   = repo;
        }

        protected virtual ICommandResult SaveState(T obj)
        {
            if (DataSource != null)
            {
               return DataSource.CommandRepository.CreateObject(obj);
            }
            throw new ArgumentException("Reposistory Not Set!");
        }
    }
}