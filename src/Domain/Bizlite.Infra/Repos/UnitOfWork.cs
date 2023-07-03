using Bizlite.Infra.Entities;
using Bizlite.Core.Interfaces;
using Bizlite.Infra.Entities;

namespace Bizlite.Infra.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BizliteContext _bizliteContext;
        //private IUserRepository? _userRepo;
        private IMasterRepo? _masterRepo;
        private IEmployeeRepo? _employeeRepo;

        public UnitOfWork(BizliteContext bizliteContext)
        {
            _bizliteContext = bizliteContext;
        }
        //public IUserRepository User
        //{
        //    get
        //    {
        //        if (_userRepo == null)
        //        {
        //            _userRepo = new UserRepository(_toDoDbContext);
        //        }
        //        return _userRepo;
        //    }
        //}
        public IMasterRepo Master
        {
            get
            {
                if (_masterRepo == null)
                {
                    _masterRepo = new MasterRepo(_bizliteContext);
                }
                return _masterRepo;
            }
        }
        public IEmployeeRepo Employee
        {
            get
            {
                if (_employeeRepo == null)
                {
                    _employeeRepo = new EmployeeRepo(_bizliteContext);
                }
                return _employeeRepo;
            }
        }



        public void Save()
        {
            _bizliteContext.SaveChanges();
        }
    }
}
