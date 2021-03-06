﻿using System;
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

        [HttpGet]
        [Route("{id}/preferences")]
        public async Task<ActionResult<Preferences>> GetUserPreferencesAsync(int id)
        {
            User grabbeduser = await _db.Users.FindAsync(id);
            if (grabbeduser == null)
            {
                return NoContent();
            }

            Preferences prefs = await _db.Preferences.FindAsync(id);
            return prefs;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUserAsync(User user)
        {
            User newuser = new User()
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                City = user.City,
                Latitude = user.Latitude,
                Longitude = user.Longitude,
                PreferencesModel = new Preferences()
                {
                    Animals = user.PreferencesModel.Animals,
                    Art = user.PreferencesModel.Art,
                    Beauty = user.PreferencesModel.Beauty,
                    Entertainment = user.PreferencesModel.Entertainment,
                    Fitness = user.PreferencesModel.Fitness,
                    HomeDecour = user.PreferencesModel.HomeDecour,
                    Learning = user.PreferencesModel.Learning,
                    Nightlife = user.PreferencesModel.Nightlife,
                    Religion = user.PreferencesModel.Religion,
                    Shopping = user.PreferencesModel.Shopping,

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
            if (grabbeduser == null)
            {
                return NoContent();
            }
            grabbeduser.Username = user.Username;
            grabbeduser.Password = user.Password;
            grabbeduser.Email = user.Email;
            grabbeduser.City = user.City;
            grabbeduser.Longitude = user.Longitude;
            grabbeduser.Latitude = user.Latitude;

            Preferences newprefs = user.PreferencesModel;

            newprefs.Art = user.PreferencesModel.Art;
            newprefs.Animals = user.PreferencesModel.Animals;
            newprefs.Beauty = user.PreferencesModel.Beauty;
            newprefs.Entertainment = user.PreferencesModel.Entertainment;
            newprefs.Fitness = user.PreferencesModel.Fitness;
            newprefs.HomeDecour = user.PreferencesModel.HomeDecour;
            newprefs.Learning = user.PreferencesModel.Learning;
            newprefs.Nightlife = user.PreferencesModel.Nightlife;
            newprefs.Religion = user.PreferencesModel.Religion;
            newprefs.Shopping = user.PreferencesModel.Shopping;

            grabbeduser.PreferencesModel = newprefs;


            _db.Update(grabbeduser);
            _db.Update(newprefs);
            await _db.SaveChangesAsync();

            return grabbeduser;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteUserAsync(int id)
        {
            bool flag = false;
            User grabbeduser = await _db.Users.FindAsync(id);
            if (grabbeduser != null)
            {
                await Task.Delay(500);
                _db.Remove(grabbeduser);
                await _db.SaveChangesAsync();
                flag = true;
            }
            return flag;
        }
    }
}
