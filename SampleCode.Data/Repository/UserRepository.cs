using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode.Data.Repository
{
    public class UserRepository 
    {
        private SampleDBContext _dbContext = new SampleDBContext();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<tblUser> GetAll()
        {
            return _dbContext.tblUsers.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<tblUser> Login(string email, string password)
        {
            return (from user in _dbContext.tblUsers  where(user.UserName == email && user.Password == password) 
                              select user).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Register(string fName, string lName, string email, string password, string phone)
        {
            int result = 0;
                using (var dbCtx = new SampleDBContext())
                {
                    tblUser user = new tblUser();
                    user.FirstName = fName;
                    user.LastName = lName;
                    user.UserName = email;
                    user.Password = password;
                    user.Phone = phone;
                    user.UserTypeId = 1;
                    user.City = "Noida";
                    user.CreatedBy = 1;
                    user.CreatedOn = DateTime.Now;
                    user.ModifiedBy = 1;
                    user.ModifiedOn = DateTime.Now;

                    //Add user object into user DBset
                    dbCtx.tblUsers.Add(user);

                    // call SaveChanges method to save user into database
                    result = dbCtx.SaveChanges();
                }

                return result;
       }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int DeleteUser(int id)
        {
            int result = 0;
            using (var dbCtx = new SampleDBContext())
            {
                //returns a single item.
                var itemToRemove = dbCtx.tblUsers.SingleOrDefault(x => x.Id == id); 

                if (itemToRemove != null)
                {
                    dbCtx.tblUsers.Remove(itemToRemove);
                    result = dbCtx.SaveChanges();
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public tblUser EditUser(int id)
        {
            using (var dbCtx = new SampleDBContext())
            {
                //returns a single item.
                return dbCtx.tblUsers.SingleOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>ss
        public List<tblUser> SearchUserByName(string name)
        {
            using (var dbCtx = new SampleDBContext())
            {
                return (from user in dbCtx.tblUsers
                        where user.FirstName.Contains(name)
                        select user).ToList();

            }
        }
   }
}
