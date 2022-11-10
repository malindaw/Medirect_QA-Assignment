

using Microsoft.AspNetCore.Mvc;
using PetStoreAPICaller.Controller;
using PetStoreAPICaller.Common;
using System.Reflection.Metadata;
using PetStoreAPICaller.Entity;
using NuGet.Frameworks;

namespace PetStore.Test
{

    /// <summary> 
    /// Class-UserTest
    /// This public class to do the user related test cases and check whether api responed properly .
    /// </summary> 
    /// <remarks> 
    /// Mainly crate, create as list,creatre as  array,update user and delete user functinalities 
    /// wiil be tested with all possible response codes and status
    /// </remarks> 
    [TestFixture]
    public class UserTest
    {
        //defined controller cllas for api calling
        private UserController? controller;


        /// <summary> 
        /// Setup- Tests initializing process.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [SetUp]
        public void Setup()
        {
            //initialized  controller cllas for api calling
            controller = new UserController();
        }

        /// <summary> 
        /// Test200GetUserByName-This test method will retrive user details with given name
        /// response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200GetUserByName()
        {
            string username = "test";
            IPetStoreResult result;

            if (controller==null) controller = new UserController();

            var  usr = controller.GetUserByName(username,"user");
            result = (PetStoreResult)usr;                
            
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));
            // if (result.UserList != null && result.UserList.Count > 0)
            // Assert.IsInstanceOf<User>(result.UserList[0]);
            //  Assert.That(username, Is.EqualTo(result.UserList[0].UserName));


        }


        /// <summary> 
        /// Test400GetUserByName-This test method will try to retrive wrong user details for  selected name
        /// response code must be 400 - invalid user info.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test400GetUserByName()
        {
            string username = "test321";
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            var usr = controller.GetUserByName(username, "user");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(400));          


        }

        /// <summary> 
        /// Test404GetUserByName-This test method will try to retrive wrong method and check the 
        /// response code which must be 404 - Not found.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404GetUserByName()
        {
            string username = "test";
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            var usr = controller.GetUserByName(username, "user/user");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));


        }



        /// <summary> 
        /// Test200CreateUsersByArray-This test method will create users witthe given arrray
        /// This should return 200
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200CreateUsersByArray()
        {
            //string expected = "test";
            IPetStoreResult result;
            User[] users = new User[2];

            User testuser =new User();
            testuser.UserName = "testsl202";
            testuser.Id = 303;
            testuser.FirstName = "test-first202";
            testuser.LastName = "test-last202";
            testuser.Email = "test101@test.com";
            testuser.Password = "test1234";
            testuser.Phone = "94112181818";
            testuser.UserStatus = 2;
            users[0] = testuser;

            testuser = new User();
            testuser.UserName = "testsl333";
            testuser.Id = 333;
            testuser.FirstName = "test-first333";
            testuser.LastName = "test-last333";
            testuser.Email = "test3331@test.com";
            testuser.Password = "test1234";
            testuser.Phone = "94112181333";
            testuser.UserStatus = 1;
            users[1] = testuser;


            if (controller == null) controller = new UserController();

            var usr = controller.CreateUsersByArray(users, "user/createWithArray");

            result = (PetStoreResult)usr;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));

            
        }

        /// <summary> 
        /// Test400CreateUsersByArray-This test method try to create users (with incomplete data)
        /// with the given arrray. This should return 400
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test500CreateUsersByArray()
        {
            //string expected = "test";
            IPetStoreResult result;
            User[] users = new User[1];

            User? testuser = null;
            /*testuser.UserName = "testsl102";
            testuser.Id = -1;
            testuser.FirstName = "test-first102";
            testuser.LastName = "test-last102";
            testuser.Email = null;
            testuser.Password = "test1234";
            testuser.Phone = "94112181818";
            testuser.UserStatus = 2;*/
            users[0] = testuser;

            if (controller == null) controller = new UserController();

            var usr = controller.CreateUsersByArray(users, "user/createWithArray");

            result = (PetStoreResult)usr;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(500));


        }


        /// <summary> 
        /// Test404CreateUsersByArray-This test method try to test creare user method with 
        /// wrong methods.This should return 404
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404CreateUsersByArray()
        {
            //string expected = "test";
            IPetStoreResult result;
            User[] users = new User[1];

            User testuser = new User();
            testuser.UserName = "testsl102";
            testuser.Id = 888;
            testuser.FirstName = "test-first102";
            testuser.LastName = "test-last102";
            testuser.Email = "test101@test.com";
            testuser.Password = "test1234";
            testuser.Phone = "94112181818";
            testuser.UserStatus = 2;
            users[0] = testuser;

            if (controller == null) controller = new UserController();

            var usr = controller.CreateUsersByArray(users, "user1/createWithArray");

            result = (PetStoreResult)usr;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));


        }

        /// <summary> 
        /// Test405CreateUsersByArray-This test method try to test creare user method with 
        /// wrong methods.This should return 404
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test405CreateUsersByArray()
        {
            //string expected = "test";
            IPetStoreResult result;
            User[] users = new User[1];

            User testuser = new User();
            testuser.UserName = "testsl102";
            testuser.Id = 888;
            testuser.FirstName = "test-first102";
            testuser.LastName = "test-last102";
            testuser.Email = "test101@test.com";
            testuser.Password = "test1234";
            testuser.Phone = "94112181818";
            testuser.UserStatus = 2;
            users[0] = testuser;

            if (controller == null) controller = new UserController();

            var usr = controller.CreateUsersByArray(users, "user/create");

            result = (PetStoreResult)usr;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(405));


        }



        /// <summary> 
        /// Test200CreateUsersByList-This test method try to test create user method with 
        /// given list.This should return 200
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200CreateUsersByList()
        {
            //string expected = "test";
            IPetStoreResult result;
            List<User> users = new List<User>();

            User testuser = new User();
            testuser.UserName = "testList100";
            testuser.Id = 8001;
            testuser.FirstName = "test-firstList100";
            testuser.LastName = "test-lastList100";
            testuser.Email = "testList100@test.com";
            testuser.Password = "test1234";
            testuser.Phone = "941121919191";
            testuser.UserStatus = 2;
            users.Add(testuser);

            if (controller == null) controller = new UserController();

            var usr = controller.CreateUsersByList(users, "user/createWithList");

            result = (PetStoreResult)usr;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));


        }

        /// <summary> 
        /// Test400CreateUsersByList-This test method try to test create user method with 
        /// null paramter list.This should return 400
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test500CreateUsersByList()
        {
            //string expected = "test";
            IPetStoreResult result;
            List<User> users = new List<User>();

            User? testuser = null;// new User();
            /*testuser.UserName = "testList100";
            testuser.Id = 8001;
            testuser.FirstName = "test-firstList100";
            testuser.LastName = "test-lastList100";
            testuser.Email = null;
            testuser.Password = "test1234";
            testuser.Phone = "941121919191";
            testuser.UserStatus = 2;*/
            users.Add(testuser);

            if (controller == null) controller = new UserController();

            var usr = controller.CreateUsersByList(users, "user/createWithList");

            result = (PetStoreResult)usr;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(500));


        }

        /// <summary> 
        /// Test404CreateUsersByList-This test method try to test create user method with 
        /// wrong method name.This should return 404
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404CreateUsersByList()
        {
            //string expected = "test";
            IPetStoreResult result;
            List<User> users = new List<User>();

            User testuser = new User();
            testuser.UserName = "testList100";
            testuser.Id = 8001;
            testuser.FirstName = "test-firstList100";
            testuser.LastName = "test-lastList100";
            testuser.Email = "test123@test.com";
            testuser.Password = "test1234";
            testuser.Phone = "941121919191";
            testuser.UserStatus = 2;
            users.Add(testuser);

            if (controller == null) controller = new UserController();

            var usr = controller.CreateUsersByList(users, "user1/createWithList");

            result = (PetStoreResult)usr;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));


        }



        /// <summary> 
        /// Test404CreateUsersByList-This test method try to test create user method with 
        /// wrong method name.This should return 404
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test405CreateUsersByList()
        {
            //string expected = "test";
            IPetStoreResult result;
            List<User> users = new List<User>();

            User testuser = new User();
            testuser.UserName = "testList100";
            testuser.Id = 8001;
            testuser.FirstName = "test-firstList100";
            testuser.LastName = "test-lastList100";
            testuser.Email = "test123@test.com";
            testuser.Password = "test1234";
            testuser.Phone = "941121919191";
            testuser.UserStatus = 2;
            users.Add(testuser);

            if (controller == null) controller = new UserController();

            var usr = controller.CreateUsersByList(users, "user/create");

            result = (PetStoreResult)usr;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(405));


        }

        /// <summary> 
        /// Test200CreateUser-This test method try to test create user method with 
        /// .This should return 200
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200CreateUser()
        {
          
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            User testuser = new User();
            testuser.UserName = "tessl901";
            testuser.Id = 8091;
            testuser.FirstName = "test-firsttessl901";
            testuser.LastName = "test-lasttessl901";
            testuser.Email = "tessl901@test.com";
            testuser.Password = "test1234";
            testuser.Phone = "941126661";
            testuser.UserStatus = 1;


            var usr = controller.CreateUser(testuser, PetStoreCommon.User_Url);
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));
            

        }

        /// <summary> 
        /// Test404CreateUser-This test method try to test create user method with 
        /// null parameters.This should return 400
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>

        [Test]
        public void Test404CreateUser()
        {

            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            User testuser = new User();
            testuser.UserName = "tessl901";
            testuser.Id = 0;
            testuser.FirstName = "test-firsttessl901";
            testuser.LastName = "test-lasttessl901";
            testuser.Email = null;
            testuser.Password = "test1234";
            testuser.Phone = "941126661";
            testuser.UserStatus = -1;


            var usr = controller.CreateUser(testuser, "user1");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));


        }

        /// <summary> 
        /// Test405CreateUser-This test method try to test create user method with 
        ///wrong calls.This should return 404
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>

        [Test]
        public void Test405CreateUser()
        {

            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            User testuser = new User();
            testuser.UserName = "tessl901";
            testuser.Id = 8091;
            testuser.FirstName = "test-firsttessl901";
            testuser.LastName = "test-lasttessl901";
            testuser.Email = "tessl901@test.com";
            testuser.Password = "test1234";
            testuser.Phone = "941126661";
            testuser.UserStatus = 1;


            var usr = controller.CreateUser(testuser, "user/create");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(405));


        }



        /// <summary> 
        /// Test200UpdateUser-This test method try to test update user method with 
        ///proper parameter and  calls.This should return 200
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200UpdateUser()
        {
            string username = "test101";
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            User testuser = new User();
            testuser.UserName = "testList100";
            testuser.Id = 8001;
            testuser.FirstName = "test-firstList100";
            testuser.LastName = "test-lastList100";
            testuser.Email = "testList100@test.com";
            testuser.Password = "test1234";
            testuser.Phone = "941121919191";
            testuser.UserStatus = 2;
           

            var usr = controller.UpdateUser(username,"user", testuser);
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));
            
        }

        /// <summary> 
        /// Test405UpdateUser-This test method try to test update user method with 
        ///null parameter and  calls.This should return 400
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test405UpdateUser()
        {
            string username = "test101";
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            User testuser = new User();
            testuser.UserName = "testList100";
            testuser.Id = -0;
            testuser.FirstName = "test-firstList100";
            testuser.LastName = "test-lastList100";
            testuser.Email = null;
            testuser.Password = "test1234";
            testuser.Phone = "941121919191";
            testuser.UserStatus = 2;


            var usr = controller.UpdateUser(username, "user?", testuser);
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(405));

        }


        /// <summary> 
        /// Test200UpdateUser-This test method try to test update user method with 
        ///wrong calls.This should return 404
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404UpdateUser()
        {
            string username = "test101";
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            User testuser = new User();
            testuser.UserName = "testList100";
            testuser.Id = 8001;
            testuser.FirstName = "test-firstList100";
            testuser.LastName = "test-lastList100";
            testuser.Email = "testList100@test.com";
            testuser.Password = "test1234";
            testuser.Phone = "941121919191";
            testuser.UserStatus = 2;


            var usr = controller.UpdateUser(username, "user/update", testuser);
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));

        }



        /// <summary> 
        /// Test200DeleteUser-This test method try to test delete user method with 
        ///proper calls and required parameter.This should return 200
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200DeleteUser()
        {
            string username = "test";
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            var usr = controller.DeleteUser(username,"user");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));

        }


        /// <summary> 
        /// Test405DeleteUser-This test method try to test delete user method with 
        ///proper calls and required parameter.This should return 200
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test405DeleteUser()
        {
            string username = "";
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            var usr = controller.DeleteUser(username, "user");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(405));

        }



        /// <summary> 
        /// Test400DeleteUser-This test method try to test delete user method with and null  parameter/s.
        /// This should return 400
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test400DeleteUser()
        {
            string? username = "-1";
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            var usr = controller.DeleteUser(username, "user");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(400));

        }

        /// <summary> 
        /// Test404DeleteUser-This test method try to test delete user method with wrong call.
        /// This should return 404
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404DeleteUser()
        {
            string username = "test";
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            var usr = controller.DeleteUser(username, "user/delete1");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));

        }


        /// <summary> 
        /// Test200LoginUser-This test method try login with proper userid/password.
        /// This should return 200
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200LoginUser()
        {
            string username = "test101";
            string password = "test1234";
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            var usr = controller.LoginUser(username,password, "user/login");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));
        }

        ///// <summary> 
        ///// Test400LoginUser-This test method try login with improper userid/password.
        ///// This should return 400
        ///// </summary> 
        ///// <returns> 
        ///// Void 
        ///// </returns>
        //[Test]
        //public void Test400LoginUser()
        //{
        //    string username = null;
        //    string password = null;
        //    IPetStoreResult result;

        //    if (controller == null) controller = new UserController();

        //    var usr = controller.LoginUser(username, password, "user/login");
        //    result = (PetStoreResult)usr;

        //    Console.WriteLine(result.ErrorCode);
        //    Assert.That(result.ErrorCode, Is.EqualTo(400));
        //}



        /// <summary> 
        /// Test404LoginUser-This test method try login with improper method call.
        /// This should return 400
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404LoginUser()
        {
            string username = "test101";
            string password = "";
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            var usr = controller.LoginUser(username, password, "user1/login");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));
        }

        /// <summary> 
        /// Test400LoginUser-This test method try login with proper louout call.
        /// This should return 200
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200Logout()
        {
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            var usr = controller.LogoutUser("user/logout");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));
            
        }

        /// <summary> 
        /// Test400Logout-This test method try login with wrong user and api call.
        /// This should return 404
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test400Logout()
        {
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            var usr = controller.LogoutUser("user/logout1");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(400));

        }


        /// <summary> 
        /// Test404Logout-This test method try login with wrong louout call.
        /// This should return 404
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404Logout()
        {
            IPetStoreResult result;

            if (controller == null) controller = new UserController();

            var usr = controller.LogoutUser("user/logout/888");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));

        }


        /// <summary> 
        /// Cleanup- Tests cleanup  call.Dispose objects after finish the process.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [TearDown]
        public void Cleanup()
        {
            controller = null;
        }

        /// <summary> 
        /// Cleanup- class cleanup  call.Dispose objects(if any) after finish the process.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [OneTimeTearDown]
        public void ClassCleanup()
        {
            controller = null;
        }
    }
}