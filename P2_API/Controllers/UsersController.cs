using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P2_API.Data;
using P2_API.Models;

namespace P2_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly P2Context _db;

        public UsersController(P2Context context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            List<User> users = await _db.Users.ToListAsync();

            foreach (var user in users)
            {
                Preferences userprefs = await _db.Preferences.FindAsync(user.PreferencesId);
                user.PreferencesModel = userprefs;
            }

            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserAsync(int id)
        {
            User grabbeduser = await _db.Users.FindAsync(id);
            if (grabbeduser == null)
            {
                return NoContent();
            }

            Preferences userprefs = await _db.Preferences.FindAsync(grabbeduser.PreferencesId);
            grabbeduser.PreferencesModel = userprefs;

            return grabbeduser;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUserAsync(User user)
        {
            User newuser = new User()
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                PreferencesModel = new Preferences()
                {
                    Aquarium = true,
                    Boxing = false,
                    Movies = true
                }
            };

            try
            {
                await _db.Users.AddAsync(newuser);
                await _db.SaveChangesAsync();
                return newuser;
            }
            catch (SqlException e)
            {
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUserAsync(User user)
        {
            // User grabbeduser = await _db.Users.FindAsync(id);

            User grabbeduser = await _db.Users.FindAsync(user.UserId);

            grabbeduser.Username = user.Username;
            grabbeduser.Password = user.Password;
            grabbeduser.Email = user.Email;

            _db.Update(grabbeduser);
            await _db.SaveChangesAsync();

            return grabbeduser;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteUserAsync(int id)
        {
            bool flag = false;
            try
            {
                User grabbeduser = await _db.Users.FindAsync(id);
                await Task.Delay(500);
                _db.Remove(grabbeduser);
                await _db.SaveChangesAsync();
                flag = true;
            }
            catch (SqlException e)
            {
            }

            return flag;
        }
    }
}
