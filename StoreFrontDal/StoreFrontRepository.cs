using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFrontDal
{
    public partial class StoreFrontRepository : IDisposable
    {
        private StoreFrontEntities _context;

        public StoreFrontRepository()
        {
            _context = new StoreFrontEntities();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool InsertUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                //log some stuff
                return false;
            }

        }

        public bool InsertUser(string userName, string emailAddress, bool isAdmin, string createdBy)
        {
                var newUser = new User();
                newUser.UserName = userName;
                newUser.EmailAddress = emailAddress;
                newUser.IsAdmin = isAdmin;
                newUser.CreatedBy = createdBy;
                newUser.DateCreated = DateTime.Now;
                newUser.ModifiedBy = createdBy;
                newUser.DateModified = DateTime.Now;

                return InsertUser(newUser);
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool Updateuser(User user)
        {
            return UpdateUser(user.UserID, user.UserName, user.EmailAddress, user.IsAdmin.Value, user.ModifiedBy);
        }

        public bool UpdateUser(int userId, string userName, string emailAddress, bool isAdmin, string updateBy)
        {
            try
            {
                var user = _context.Users.Find(userId);
                user.UserName = userName;
                user.EmailAddress = emailAddress;
                user.IsAdmin = isAdmin;
                user.ModifiedBy = updateBy;
                user.DateModified = DateTime.Now;

                _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var user = _context.Users.Find(userId);
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex);
                return false;
            }
        }

    }
}
