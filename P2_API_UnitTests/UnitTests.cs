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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Web.Mvc;

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
                _usersController = new UsersController(context);


                Preferences prefs = new Preferences { Animals = true, PreferencesId = 1, Art = true, Beauty = false, Entertainment = true, Fitness = false, HomeDecour = true, Learning = false, Nightlife = true, Religion = true, Shopping = false };
                User user1 = new User { City = "c", Email = "e", Password = "p", PreferencesId = 1, PreferencesModel = prefs };
                User user2 = new User { City = "ci", Email = "em", Password = "pa", PreferencesId = 2, PreferencesModel = prefs };
                User user3 = new User { City = "cit", Email = "ema", Password = "pas", PreferencesId = 3, PreferencesModel = prefs };
                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Users.Add(user3);
                context.SaveChanges();
                IEnumerable<User> testList = _usersController.GetAllUsersAsync().Result;
                testList = testList.ToList();

                Assert.Equal(3, testList.Count());
                Assert.NotEmpty(testList);
            }


        }
        [Fact]
        public async void TestGetUser()
        {
            var options = new DbContextOptionsBuilder<P2Context>().UseInMemoryDatabase(databaseName: "TestMethod2").Options;
            using (var context = new P2Context(options))
            {
                _usersController = new UsersController(context);


                Preferences prefs = new Preferences { Animals = true, PreferencesId = 1, Art = true, Beauty = false, Entertainment = true, Fitness = false, HomeDecour = true, Learning = false, Nightlife = true, Religion = true, Shopping = false };
                User user1 = new User { City = "c", Email = "e", Password = "p", PreferencesId = 1, PreferencesModel = prefs };
                User user2 = new User { City = "ci", Email = "em", Password = "pa", PreferencesId = 2, PreferencesModel = prefs };
                User user3 = new User { City = "cit", Email = "ema", Password = "pas", PreferencesId = 3, PreferencesModel = prefs };
                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Users.Add(user3);
                context.SaveChanges();

                int id = 1;
                var result = await _usersController.GetUserAsync(id);
                User testUser = result.Value;

                Assert.Equal("c", testUser.City);
            }


        }
        [Fact]
        public async void TestPutUser()
        {
            var options = new DbContextOptionsBuilder<P2Context>().UseInMemoryDatabase(databaseName: "TestMethod3").Options;
            using (var context = new P2Context(options))
            {
                _usersController = new UsersController(context);


                Preferences prefs = new Preferences { Animals = true, PreferencesId = 1, Art = true, Beauty = false, Entertainment = true, Fitness = false, HomeDecour = true, Learning = false, Nightlife = true, Religion = true, Shopping = false };
                User user1 = new User { City = "c", Email = "e", Password = "p", PreferencesId = 1, PreferencesModel = prefs };
                User user2 = new User { City = "ci", Email = "em", Password = "pa", PreferencesId = 2, PreferencesModel = prefs };
                User user3 = new User { City = "cit", Email = "ema", Password = "pas", PreferencesId = 3, PreferencesModel = prefs };
                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Users.Add(user3);
                context.SaveChanges();

                user1.City = "a";
                user1.Password = "b";

                var result = await _usersController.UpdateUserAsync(user1);
                var test = context.Users.Find(1);

                Assert.Equal("a", test.City);
                Assert.Equal("b", test.Password);

            }


        }
        [Fact]
        public async void TestGetUserPrefs()
        {
            var options = new DbContextOptionsBuilder<P2Context>().UseInMemoryDatabase(databaseName: "TestMethod4").Options;
            using (var context = new P2Context(options))
            {
                _usersController = new UsersController(context);


                Preferences prefs = new Preferences { Animals = true, PreferencesId = 1, Art = true, Beauty = false, Entertainment = true, Fitness = false, HomeDecour = true, Learning = false, Nightlife = true, Religion = true, Shopping = false };
                User user1 = new User { City = "c", Email = "e", Password = "p", PreferencesId = 1, PreferencesModel = prefs };
                User user2 = new User { City = "ci", Email = "em", Password = "pa", PreferencesId = 2, PreferencesModel = prefs };
                User user3 = new User { City = "cit", Email = "ema", Password = "pas", PreferencesId = 3, PreferencesModel = prefs };
                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Users.Add(user3);
                context.SaveChanges();

                var response = await _usersController.GetUserPreferencesAsync(1);
                Preferences result = response.Value;

                Assert.True(result.Art);
                Assert.True(result.HomeDecour);
                Assert.True(result.Religion);

            }

        }
        [Fact]
        public async void TestPostUser()
        {
            var options = new DbContextOptionsBuilder<P2Context>().UseInMemoryDatabase(databaseName: "TestMethod5").Options;
            using (var context = new P2Context(options))
            {
                _usersController = new UsersController(context);


                Preferences prefs = new Preferences { Animals = true, PreferencesId = 1, Art = true, Beauty = false, Entertainment = true, Fitness = false, HomeDecour = true, Learning = false, Nightlife = true, Religion = true, Shopping = false };
                User user1 = new User { City = "c", Email = "e", Password = "p", PreferencesId = 1, PreferencesModel = prefs };
                User user2 = new User { City = "ci", Email = "em", Password = "pa", PreferencesId = 2, PreferencesModel = prefs };

                context.Users.Add(user1);
                context.Users.Add(user2);
                context.SaveChanges();

                User user3 = new User { City = "cit", Email = "ema", Password = "pas", PreferencesId = 3, PreferencesModel = prefs };
                var response = await _usersController.CreateUserAsync(user3);

                User result = context.Users.Find(3);

                Assert.Equal("cit", result.City);
                Assert.Equal("ema", result.Email);
            }

        }
        [Fact]
        public async void TestDeleteUser()
        {
            var options = new DbContextOptionsBuilder<P2Context>().UseInMemoryDatabase(databaseName: "TestMethod6").Options;
            using (var context = new P2Context(options))
            {
                _usersController = new UsersController(context);


                Preferences prefs = new Preferences { Animals = true, PreferencesId = 1, Art = true, Beauty = false, Entertainment = true, Fitness = false, HomeDecour = true, Learning = false, Nightlife = true, Religion = true, Shopping = false };
                User user1 = new User { City = "c", Email = "e", Password = "p", PreferencesId = 1, PreferencesModel = prefs };
                User user2 = new User { City = "ci", Email = "em", Password = "pa", PreferencesId = 2, PreferencesModel = prefs };
                User user3 = new User { City = "cit", Email = "ema", Password = "pas", PreferencesId = 3, PreferencesModel = prefs };

                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Users.Add(user3);
                context.SaveChanges();

                var response = await _usersController.DeleteUserAsync(3);
                var x = context.Users.Find(3);

                Assert.Null(x);

            }

        }
        [Fact]
        public async void TestGetUserNullTry()
        {
            var options = new DbContextOptionsBuilder<P2Context>().UseInMemoryDatabase(databaseName: "TestMethod7").Options;
            using (var context = new P2Context(options))
            {
                _usersController = new UsersController(context);


                Preferences prefs = new Preferences { Animals = true, PreferencesId = 1, Art = true, Beauty = false, Entertainment = true, Fitness = false, HomeDecour = true, Learning = false, Nightlife = true, Religion = true, Shopping = false };
                User user1 = new User { City = "c", Email = "e", Password = "p", PreferencesId = 1, PreferencesModel = prefs };
                User user2 = new User { City = "ci", Email = "em", Password = "pa", PreferencesId = 2, PreferencesModel = prefs };
                User user3 = new User { City = "cit", Email = "ema", Password = "pas", PreferencesId = 3, PreferencesModel = prefs };
                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Users.Add(user3);
                context.SaveChanges();

                int id = 4;
                var result = (await _usersController.GetUserAsync(id));

                var code = result.Value;

                Assert.Null(code);



            }


        }
    }
}