using Orak.AdvertisementApp.DataAccess.İnterfaces;
using Orak.AdvertisementApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orak.AdvertisementApp.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity; 
        Task SaveChangesAsync();
    }
}
