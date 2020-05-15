
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCore.Repository
{
    public class GenericUnitOfWork : IDisposable
    {
        private readonly ShoppingCoreEntities context;
        private bool disposed;
        private Dictionary<string, object> repositories;

        public GenericUnitOfWork(ShoppingCoreEntities context)
        {
            this.context = context;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public GenericRepository<Tbl_EntityType> Repository<Tbl_EntityType>() where Tbl_EntityType : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(Tbl_EntityType).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(Tbl_EntityType)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (GenericRepository<Tbl_EntityType>)repositories[type];
        }
    }
}

    //public class GenericUnitOfWork : IDisposable
    //{
    //    //private ShoppingCoreEntities DBEntity = new ShoppingCoreEntities();
    //    private bool disposed = false;
    //    private ShoppingCoreEntities DBEntity;

    //    public GenericUnitOfWork(ShoppingCoreEntities coreEntities)
    //    {
    //        DBEntity = coreEntities;
    //    }

    //    public IRepository<Tbl_EntityType> GetRepositoryInstance<Tbl_EntityType>() where Tbl_EntityType : class
    //    {
    //        return new GenericRepository<Tbl_EntityType>(DBEntity);
    //    }

    //    public void SaveChanges()
    //    {
    //        DBEntity.SaveChanges();
    //    }


    //    #region Disposing the Unit of work context ...

    //    public ShoppingCoreEntities CoreEntities { get; }

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!this.disposed)
    //        {
    //            if (disposing)
    //            {
    //                DBEntity.Dispose();
    //            }
    //        }
    //        this.disposed = true;
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }
    //    #endregion
    //}
//}
