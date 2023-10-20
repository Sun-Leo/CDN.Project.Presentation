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
    public class FolderManager : IFolderService
    {
        private readonly IFolderDal _folderDal;

        public FolderManager(IFolderDal folderDal)
        {
            _folderDal = folderDal;
        }

        public void TDelete(Folder t)
        {
            _folderDal.Delete(t);
        }

        public Folder TGetById(int id)
        {
            return _folderDal.GetById(id);
        }

        public List<Folder> TGetList()
        {
            return _folderDal.GetList();
        }

        public void TInsert(Folder t)
        {
            _folderDal.Insert(t);
        }

        public void TUpdate(Folder t)
        {
            _folderDal.Update(t);
        }
    }
}
