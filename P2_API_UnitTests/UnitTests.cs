using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using P2_API.Data;
using P2_API.Models;
using P2_API.Controllers;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace P2_API_UnitTests
{
    public class UnitTests
    {
        public UsersController _usersController;
        [Fact]
        public void TestGetAll()
        {
            var options = new DbContextOptionsBuilder<P2Context>().UseInMemoryDatabase(databaseName: "TestMethod1").Options;
            using (var context = new P2Context(options))
            {
                Preferences prefs = new Preferences { Animals = true, PreferencesId = 1, Art = true, Beauty = false, Entertainment = true, Fitness = false, HomeDecour = true, Learning = false, Nightlife = true, Religion = true, Shopping = false };
                User user1 = new User { City = "c", Email = "e", Password = "p", PreferencesId = 1, PreferencesModel = prefs };
                User user2 = new User { City = "ci", Email = "em", Password = "pa", PreferencesId = 2, PreferencesModel = prefs };
                User user3 = new User { City = "cit", Email = "ema", Password = "pas", PreferencesId = 3, PreferencesModel = prefs };
                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Users.Add(user3);
                context.SaveChanges();
                IEnumerable<User> testList = (IEnumerable<User>)_usersController.GetAllUsersAsync();

                Assert.NotEmpty(testList);
            }


        }
    }
}