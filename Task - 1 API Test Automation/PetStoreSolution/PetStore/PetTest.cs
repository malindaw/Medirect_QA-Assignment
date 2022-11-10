using PetStoreAPICaller.Common;
using PetStoreAPICaller.Controller;
using PetStoreAPICaller.Entity;
using RestSharp;
using System.Net.Mime;

namespace PetStore.Test
{
    /// <summary> 
    /// Class-PetTest
    /// This public class to do the pet related test cases and check whether apis responed properly .
    /// </summary> 
    /// <remarks> 
    /// Mainly crate,update.delete.findbyid and findbystatus pets functinalities 
    /// wiil be tested with all possible response codes and status
    /// </remarks>
    [TestFixture]
    public class PetTest
    {

        //defined controller cllas for api calling
        private PetController? controller;


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
            controller = new PetController();
        }

        /// <summary> 
        /// Test200FindByPetId- Find the pet with given id properly
        /// response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200FindByPetId()
        {
            long id = 10;
            IPetStoreResult result;

            if (controller == null) controller = new PetController();

            var pet = controller.FindPetById(id,"pet");
            result = (PetStoreResult)pet;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));

        }

        /// <summary> 
        /// Test400FindByPetId- Find the pet with wrong id 
        /// response code must be 400.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test400FindByPetId()
        {
            long id = -1;
            IPetStoreResult result;

            if (controller == null) controller = new PetController();

            var pet = controller.FindPetById(id,"pet");
            result = (PetStoreResult)pet;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(400));

        }


        /// <summary> 
        /// Test404FindByPetId- Find the pet with wrong id 
        /// response code must be 400.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404FindByPetId()
        {
            long id = 8001;
            IPetStoreResult result;

            if (controller == null) controller = new PetController();

            var pet = controller.FindPetById(id, "pet/pet");
            result = (PetStoreResult)pet;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));

        }




        /// <summary> 
        /// Test200UpdatePet- update  pet properties with proper parameters and proper call.
        /// Response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200UpdatePet()
        {

            byte[] fileBytes = File.ReadAllBytes("C:\\temp\\testcasesample.txt");
            var fileparam = FileParameter.Create("temp-file", fileBytes, "testcasesample.txt", null, null);
            var photourl = new Dictionary<string, FileParameter>() { { "photofile", fileparam } };


            //string expected = "test";
            IPetStoreResult result;
            Pet testPet = new Pet();
            testPet.Name = "testsl102";
           // testPet.PhotoUrls = photourl;
            testPet.Id = 888;
            //testPet.PhotoUrls = "test-testurl";
            //testPet.Category = new Category(1,"test");
            testPet.Status = "available";
           

            if (controller == null) controller = new PetController();

            var pet = controller.UpdatePet(testPet, "pet");

            result = (PetStoreResult)pet;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));


        }

        /// <summary> 
        /// Test405UpdatePet- update  pet properties with less parameters and proper call.
        /// Response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test405UpdatePet()
        {
            byte[] fileBytes = File.ReadAllBytes("C:\\temp\\testcasesample.txt");
            var fileparam = FileParameter.Create("temp-file", fileBytes, "testcasesample.txt", null, null);
            var photourl = new Dictionary<string, FileParameter>() { { "photofile", fileparam } };



            //string expected = "test";
            IPetStoreResult result;
            Pet testPet = new Pet();
            testPet.Name = "testsl102";
           // testPet.PhotoUrls = photourl;
            testPet.Id = 888;
            testPet.Status = "available";

            if (controller == null) controller = new PetController();
            var pet = controller.UpdatePet(testPet, "pet/888");

            result = (PetStoreResult)pet;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(405));


        }

        /// <summary> 
        /// Test404UpdatePet- update  pet properties with proper parameters and improper api call.
        /// Response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404UpdatePet()
        {

            byte[] fileBytes = File.ReadAllBytes("C:\\temp\\testcasesample.txt");
            var fileparam = FileParameter.Create("temp-file", fileBytes, "testcasesample.txt", null, null);
            var photourl = new Dictionary<string, FileParameter>() { { "photofile", fileparam } };

            //string expected = "test";
            IPetStoreResult result;
            Pet testPet = new Pet();
            testPet.Name = "testsl102";
          //  testPet.PhotoUrls = photourl;
            testPet.Id = 888;
            testPet.Status = "available";

            if (controller == null) controller = new PetController();
            var pet = controller.UpdatePet(testPet, "update");

            result = (PetStoreResult)pet;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));


        }



        /// <summary> 
        /// Test200CreatePet- create new pet with proper parameters and proper call.
        /// Response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200CreatePet()
        {
            //string expected = "test";
            IPetStoreResult result;

            byte[]? fileBytes=null;
            string purl = "";
            using (FileStream fs = new FileStream("C:\\temp\\testcasesample.txt", 
                   FileMode.Open, FileAccess.Read))
            {
                fileBytes = new byte[fs.Length];
                fs.Read(fileBytes, 0, (int)fs.Length);
                if(fileBytes!=null) purl =Convert.ToString(fileBytes);
            }
          
            Pet testPet = new Pet(867, "testsl867", new Category(1, "test"),
                  new List<string>() { { purl } },new List<Tag>() { { new Tag(1,"testtag")} }, "available"
                );
            
            if (controller == null) controller = new PetController();

            var pet = controller.CreatePet(testPet, "pet");

            result = (PetStoreResult)pet;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));


        }

        /// <summary> 
        /// Test200CreatePet- create new pet with improper parameters and proper call.
        /// Response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test415CreatePet()
        {
           
            //string expected = "test";
            IPetStoreResult result;

            byte[]? fileBytes = null;
            string purl = "";
            using (FileStream fs = new FileStream("C:\\temp\\testcasesample.txt",
                   FileMode.Open, FileAccess.Read))
            {
                fileBytes = new byte[fs.Length];
                fs.Read(fileBytes, 0, (int)fs.Length);
                if (fileBytes != null) purl = Convert.ToString(fileBytes);
            }

            Pet testPet = new Pet(877, "testsl877", new Category(1, "test7"),
                  new List<string>() { { purl } }, new List<Tag>() { { new Tag(1, "testtag") } }, "available"
                );

            if (controller == null) controller = new PetController();

            var pet = controller.CreatePet(testPet, "pet/866");

            result = (PetStoreResult)pet;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(415));


        }

        /// <summary> 
        /// Test404CreatePet- create new pet with proper parameters and improper call.
        /// Response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404CreatePet()
        {
            //string expected = "test";
            IPetStoreResult result;

            byte[]? fileBytes = null;
            string purl = "";
            using (FileStream fs = new FileStream("C:\\temp\\testcasesample.txt",
                   FileMode.Open, FileAccess.Read))
            {
                fileBytes = new byte[fs.Length];
                fs.Read(fileBytes, 0, (int)fs.Length);
                if (fileBytes != null) purl = Convert.ToString(fileBytes);
            }

            Pet testPet = new Pet(879, "testsl879", new Category(1, "test9"),
                  new List<string>() { { purl } }, new List<Tag>() { { new Tag(1, "testtag") } }, "available"
                );

            if (controller == null) controller = new PetController();

            var pet = controller.CreatePet(testPet, "pet1");

            result = (PetStoreResult)pet;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));


        }


        /// <summary> 
        /// Test200FindPetByStatus- search pets by using status with proper api call.
        /// Response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200FindPetByStatus()
        {

            IPetStoreResult result;

            if (controller == null) controller = new PetController();


            var pets = controller.FindPetByStatus("sold", "pet/findByStatus");
            result = (PetStoreResult)pets;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));


        }

        /// <summary> 
        /// Test404FindPetByStatus- search pets by using status with improper api call.
        /// Response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404FindPetByStatus()
        {

            IPetStoreResult result;

            if (controller == null) controller = new PetController();


            var pets = controller.FindPetByStatus("sold", "pet/findByStatus1");
            result = (PetStoreResult)pets;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));


        }



        /// <summary> 
        /// Test200DeletePet- delete given pet with proper api call.
        /// Response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200DeletePet()
        {
            
            IPetStoreResult result;

            if (controller == null) controller = new PetController();

           
            var usr = controller.DeletePet(10, "pet");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));
         

        }

        /// <summary> 
        /// Test400DeletePet- delete given pet with proper api call or invlaid id.
        /// Response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test400DeletePet()
        {

            IPetStoreResult result;

            if (controller == null) controller = new PetController();


            var usr = controller.DeletePet(-1, "pet");
            result = (PetStoreResult)usr;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(400));


        }


        /// <summary> 
        /// Test404DeletePet- delete given pet with improper api call or invlaid id.
        /// Response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404DeletePet()
        {

            IPetStoreResult result;

            if (controller == null) controller = new PetController();


            var usr = controller.DeletePet(-1, "pet/delete");
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