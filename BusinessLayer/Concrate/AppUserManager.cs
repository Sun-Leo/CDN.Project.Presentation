using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUser _appUser;

        public AppUserManager(IAppUser appUser)
        {
            _appUser = appUser;
        }

        public void TDelete(AppUser t)
        {
            _appUser.Delete(t);
        }

        public AppUser TGetById(int id)
        {
            return _appUser.GetById(id);
        }

        public List<AppUser> TGetList()
        {
            return _appUser.GetList();
        }

        public void TInsert(AppUser t)
        {
            _appUser.Insert(t);
        }

        public void TUpdate(AppUser t)
        {
            _appUser.Update(t);
        }
    }
}
