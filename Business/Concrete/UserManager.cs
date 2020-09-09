﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Framework.Entities.Concrete;

namespace Business.Concrete
{
   public class UserManager:IUserService
    {

        private IUserDal _userDal;

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

        public User GetByMail(string email)
        {
            return _userDal.Get(u=>u.Email==email);
        }
    }
}