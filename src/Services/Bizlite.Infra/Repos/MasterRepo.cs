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
    public class MasterRepo : RepositoryBase<BizliteList.TblAreaMaster>, IMasterRepo
    {
        public MasterRepo(BizliteContext bizliteContext) : base(bizliteContext)
        {
        }
        public List<BizliteList.TblAreaMaster> GetAllAreas()
        {

            return FindAll().ToList();


        }

        public PageList<BizliteList.TblAreaMaster> GetAreaList(MasterSpecification model)
        {

            var areas = FindAll();
            if (model.Status==true)
            {
                areas = FindByCondition(x => x.IsActive == model.Status);
            }
            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                areas = areas.Where(x => x.AreaName!.ToLower().Contains(model.Title.ToLower()));
            }
            areas = SortHelper<Core.Entities.TblAreaMaster>.ApplySort(areas, model.OrderBy);
            return PageList<BizliteList.TblAreaMaster>.ToPageList(areas, model.PageNumber, model.PageSize);


        }

       
        public BizliteList.TblAreaMaster? GetAreaById(int id)
        {

            return FindByCondition(x => x.AreaId == id).SingleOrDefault();


        }

        private void ApplySort(ref IQueryable<BizliteList.TblAreaMaster> source, string? OrderBy)
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
            var propertyInfo = typeof(BizliteList.TblAreaMaster).GetProperties(BindingFlags.Public | BindingFlags.Instance);
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


        public BizliteList.TblAreaMaster CreateArea(BizliteList.TblAreaMaster tblAreaMaster)
        {
            tblAreaMaster.IsActive = true;
            tblAreaMaster.DateAdded = DateTime.Now;
            tblAreaMaster.DateModified = DateTime.Now;
            Create(tblAreaMaster);
            return tblAreaMaster;
        }

        public BizliteList.TblAreaMaster UpdateArea(BizliteList.TblAreaMaster tblAreaMaster)
        {

            tblAreaMaster.DateModified = DateTime.Now;
            Update(tblAreaMaster);
            return tblAreaMaster;
        }
        public void DeleteToDo(BizliteList.TblAreaMaster tblAreaMaster)
        {
            Delete(tblAreaMaster);

        }

       

        
    }
}
