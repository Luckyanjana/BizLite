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
    public interface IEmployeeRepo : IRepositoryBase<BizliteList.TblEmployee>
    {
        public List<BizliteList.TblEmployee> GetAllEmployee();
        public BizliteList.TblEmployee? GetEmployeeById(long id);
        public BizliteList.TblEmployee? GetEmployeeByEmail(string emailid);
        public BizliteList.TblEmployee RegisterEmployee(BizliteList.TblEmployee tblAreaMaster);
        public BizliteList.TblEmployee UpdateEmployee(BizliteList.TblEmployee tblAreaMaster);
        public void DeleteEmployee(BizliteList.TblEmployee tblAreaMaster);
        public PageList<BizliteList.TblEmployee> GetEmployeeList(EmployeeSpecification model);
       
    }
}
