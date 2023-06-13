using System.Reflection;
using System.Text;
using Bizlite.Core.Helper;
using Bizlite.Core.Interfaces;
using System.Linq.Dynamic.Core;
using Bizlite.Core.Specifications;
using Bizlite.Infra.Entities;
using BizliteList = Bizlite.Core.Entities;
using Bizlite.Infra.Helpers;
using Bizlite.Core.Entities;

namespace Bizlite.Infra.Repos
{
    public class EmployeeRepo : RepositoryBase<BizliteList.TblEmployee>, IEmployeeRepo
    {
        public EmployeeRepo(BizliteContext bizliteContext) : base(bizliteContext)
        {
        }
        public List<BizliteList.TblEmployee> GetAllEmployee()
        {

            return FindAll().ToList();


        }

        public PageList<BizliteList.TblEmployee> GetEmployeeList(EmployeeSpecification model)
        {

            var employees = FindAll();
            if (model.Status == true)
            {
                employees = FindByCondition(x => x.IsActive == model.Status);
            }
            if (!string.IsNullOrWhiteSpace(model.EmployeeName))
            {
                employees = employees.Where(x => x.EmpName!.ToLower().Contains(model.EmployeeName.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(model.RefferalName))
            {
                employees = employees.Where(x => x.RefferalName!.ToLower().Contains(model.RefferalName.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(model.EmailId))
            {
                employees = employees.Where(x => x.EmailId!.ToLower().Contains(model.EmailId.ToLower()));
            }
            employees = SortHelper<Core.Entities.TblEmployee>.ApplySort(employees, model.OrderBy);
            return PageList<BizliteList.TblEmployee>.ToPageList(employees, model.PageNumber, model.PageSize);


        }

       
        public BizliteList.TblEmployee? GetEmployeeById(long id)
        {

            return FindByCondition(x => x.EmpId == id).SingleOrDefault();


        }

        private void ApplySort(ref IQueryable<BizliteList.TblEmployee> source, string? OrderBy)
        {
            if (!source.Any())
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(OrderBy))
            {
                return;
            }

            var orderQueryBuilder = new StringBuilder();

            var orderParam = OrderBy.Trim().Split(',');
            var propertyInfo = typeof(BizliteList.TblEmployee).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var param in orderParam)
            {
                if (string.IsNullOrWhiteSpace(param))
                {
                    continue;
                }
                var paramPropertyNam = param.Split(" ")[0];
                var objectProperty = propertyInfo.FirstOrDefault(x => x.Name.Equals(paramPropertyNam, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null)
                {
                    continue;
                }
                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty!.Name} {sortingOrder}, ");
                var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
                if (string.IsNullOrWhiteSpace(orderQuery))
                {
                    return;
                }
                source = source.OrderBy(orderQuery);
            }

        }
        public BizliteList.TblEmployee? GetEmployeeByEmail(string emailid) {

            return FindByCondition(x => x.EmailId == emailid).SingleOrDefault();
        }

        public BizliteList.TblEmployee RegisterEmployee(BizliteList.TblEmployee tblEmployeeMaster)
        {
            //tblEmployeeMaster.IsActive = true;
            tblEmployeeMaster.CreatedOn = DateTime.Now;
            tblEmployeeMaster.ModifiedOn = DateTime.Now;
            Create(tblEmployeeMaster);
            return tblEmployeeMaster;
        }

        public BizliteList.TblEmployee UpdateEmployee(BizliteList.TblEmployee tblEmployeeMaster)
        {

            tblEmployeeMaster.ModifiedOn = DateTime.Now;
            Update(tblEmployeeMaster);
            return tblEmployeeMaster;
        }
        public void DeleteEmployee(BizliteList.TblEmployee tblEmployeeMaster)
        {
            Delete(tblEmployeeMaster);

        }

       
    }
}
