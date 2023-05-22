using SampleCode.Domain.Repository;
using SampleCode.Common;
using SampleCode.Data.Repository;
using SampleCode.Domain.Users;
using SampleCode.Domain.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleCode.Data;

namespace SampleCode.Application.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService()
        {

        }
        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        /// <summary>
        /// Gets all the Users in the table
        /// </summary>
        /// <returns>A list of users</returns>
        public List<tblUser>  GetAll()
        {
             UserRepository _userRepository = new UserRepository();
             return _userRepository.GetAll();
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <returns></returns>
        public List<tblUser> Login(string email, string password)
        {
            UserRepository _userRepository = new UserRepository();
            return _userRepository.Login(email, password);
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <returns></returns>
        public int Register(string fName, string lName, string email, string password,string phone)
        {
            UserRepository _userRepository = new UserRepository();
            int result = _userRepository.Register(fName, lName, email, password, phone);
            return result;
        }

        /// <summary>
        /// delete User
        /// </summary>
        /// <returns></returns>
        public int DeleteUser(int id)
        {
            UserRepository _userRepository = new UserRepository();
            return _userRepository.DeleteUser(id);
        }

        /// <summary>
        /// edit User
        /// </summary>
        /// <returns></returns>
        public tblUser EditUser(int id)
        {
            UserRepository _userRepository = new UserRepository();
            return _userRepository.EditUser(id);
        }

        /// <summary>
        /// Search User
        /// </summary>
        /// <returns></returns>
        public List<tblUser> SearchUserByName(string name)
        {
            UserRepository _userRepository = new UserRepository();
            return _userRepository.SearchUserByName(name);
        }


    }
}
