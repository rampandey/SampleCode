using SampleCode.Application.Services;
using SampleCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SampleCode.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public async Task<ActionResult> Index()
        {
            return View("UserProfile");
        }

        // GET: User
        public async Task<ActionResult> Admin()
        {
            UserModel userModel = new UserModel();
            userModel.UserList = GetAllUser();
            return View("Index", "_Layout", userModel);
        }

        // Delete: User
        public async Task<ActionResult> DeleteUser(int id)
        {
            UserModel userModel = new UserModel();
            UserService _userService = new UserService();
            int result = _userService.DeleteUser(id);
            if (result == 1)
            {
                userModel.UserList = GetAllUser();
                return View("Index", userModel);
            }
            else
            {
                userModel.UserList = GetAllUser();
                return View("Index", userModel);
            }
        }

        public async Task<ActionResult> AddUser(UserModel userModel)
        {
            UserService _userService = new UserService();
            int result = _userService.Register(userModel.Name, userModel.Name, userModel.Email, "test", userModel.Phone);

            if (result == 1)
            {
                userModel.UserList = GetAllUser();
                return View("Index", userModel);
            }
            else

                // If we got this far, something failed, redisplay form
                return View(userModel);
        }

        public async Task<ActionResult> EditUser(int id)
        {
            UserModel userModel = new UserModel();
            UserService _userService = new UserService();
            var result = _userService.EditUser(id);

            if (result != null)
            {
                userModel.Name = result.FirstName;
                userModel.Email = result.UserName;
                userModel.City = result.City;
                userModel.Phone = result.Phone;
                userModel.UserList = GetAllUser();
                return View("Index", userModel);
            }
            else

                // If we got this far, something failed, redisplay form
                return View(userModel);
        }

        public async Task<ActionResult> SearchUserByName(UserModel userModel)
        {
            ModelState.Clear();
            if(userModel.Name == null )
            {
                userModel.UserList = GetAllUser();
                return View("Index", userModel);
            }
            UserService _userService = new UserService();
            var result = _userService.SearchUserByName(userModel.Name);

            //if (result.Count > 0)
            //{
                List<UserList> userListModel = new List<UserList>();

                for (int i = 0; i < result.Count; i++)
                {
                    userListModel.Add(new UserList
                    {
                        Id = result[i].Id,
                        FirstName = result[i].FirstName,
                        UserName = result[i].UserName,
                        Phone = result[i].Phone,
                        City = result[i].City,
                    });
                }
                userModel.UserList = userListModel;
                return View("Index", userModel);
            //}
            //else

            //    // If we got this far, something failed, redisplay form
            //    return View(userModel);
        }

        private List<UserList> GetAllUser()
        {
            UserService _userService = new UserService();
            var userList = _userService.GetAll();
            List<UserList> userListModel = new List<UserList>();

            for (int i = 0; i < userList.Count; i++)
            {
                userListModel.Add(new UserList
                {
                    Id = userList[i].Id,
                    FirstName = userList[i].FirstName,
                    UserName = userList[i].UserName,
                    Phone = userList[i].Phone,
                    City = userList[i].City,
                });
            }

            return userListModel;
       }
   }
}