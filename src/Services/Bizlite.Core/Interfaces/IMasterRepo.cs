using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bizlite.Core.Helper;
using Bizlite.Core.Specifications;
using BizliteList = Bizlite.Core.Entities;
namespace Bizlite.Core.Interfaces
{
    public interface IMasterRepo : IRepositoryBase<BizliteList.TblAreaMaster>
    {
        public List<BizliteList.TblAreaMaster> GetAllAreas();
        public BizliteList.TblAreaMaster? GetAreaById(int id);
        public BizliteList.TblAreaMaster CreateArea(BizliteList.TblAreaMaster tblAreaMaster);
        public BizliteList.TblAreaMaster UpdateArea(BizliteList.TblAreaMaster tblAreaMaster);
        public void DeleteArea(BizliteList.TblAreaMaster tblAreaMaster);
        public PageList<BizliteList.TblAreaMaster> GetAreaList(MasterSpecification model);
       
    }
}
