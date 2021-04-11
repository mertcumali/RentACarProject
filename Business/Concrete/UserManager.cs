using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    
        public class UserManager : IUserService
        {
            IUserDal _userDal;

            public UserManager(IUserDal userDal)
            {
                _userDal = userDal;
            }

            public List<OperationClaim> GetClaims(User user)
            {
                return _userDal.GetClaims(user);
            }

            public void Add(User user)
            {
                _userDal.Add(user);
            }

            public void Update(User user)
            {
                _userDal.Update(user);
            }

            public User GetByMail(string email)
            {
                return _userDal.Get(u => u.Email == email);
            }

            public IDataResult<User> GetById(int id)
            {
                return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
            }
            public IDataResult<User> GetLastUser()
            {
            var lastUser = _userDal.GetAll().LastOrDefault();
            return new SuccessDataResult<User>(lastUser);
            }
        }
}

