using PetStoreAPICaller.Common;
using PetStoreAPICaller.Controller;
using PetStoreAPICaller.Entity;
using System.Numerics;

namespace PetStore.Test
{

    /// <summary> 
    /// Class-StoreTest
    /// This public class to do the order related test cases and check whether apis responed properly .
    /// </summary> 
    /// <remarks> 
    /// Mainly crate,update.delete.findbyid and findbystatus order functinalities 
    /// wiil be tested with all possible response codes and status
    /// </remarks>
    [TestFixture]
    public class StoreTest
    {
        //defined controller cllas for api calling
        private StoreController? controller;


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
            controller = new StoreController();
        }


        /// <summary> 
        /// Test200CreateOrder- create new order with proper details and  proper api call
        /// response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>

        [Test]
        public void Test200CreateOrder()
        {
            //string expected = "test";
            IPetStoreResult result;
                      
            Order testOrder = new Order();
            testOrder.Quantity =10;
            testOrder.ShipDate = "12-12-2022";
            testOrder.PetId =2;
            testOrder.Status ="placed";
            testOrder.Complete =true;
            
            if (controller == null) controller = new StoreController();

            var order = controller.PlaceOrder(testOrder,"store/order");

            result = (PetStoreResult)order;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));

        }

        /// <summary> 
        /// Test400CreateOrder- create new order with improper details and  proper api call
        /// response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>

        //[Test]
        //public void Test400CreateOrder()
        //{
        //    //string expected = "test";
        //    IPetStoreResult result;

        //    Order testOrder = new Order();
        //    testOrder.Quantity = -1;
        //    testOrder.ShipDate = "1212-12-2022";
        //    testOrder.PetId = -1;
        //    testOrder.Status = "";
        //    testOrder.Complete = true;

        //    if (controller == null) controller = new StoreController();

        //    var order = controller.PlaceOrder(testOrder, "store/order");

        //    result = (PetStoreResult)order;
        //    Console.WriteLine(result.ErrorCode);
        //    Assert.That(result.ErrorCode, Is.EqualTo(400));

        //}


        /// <summary> 
        /// Test404CreateOrder- create new order with proper details and  improper api call
        /// response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>

        [Test]
        public void Test404CreateOrder()
        {
            //string expected = "test";
            IPetStoreResult result;

            Order testOrder = new Order();
            testOrder.Quantity = 10;
            testOrder.ShipDate = "12-12-2022";
            testOrder.PetId = 2;
            testOrder.Status = "placed";
            testOrder.Complete = true;

            if (controller == null) controller = new StoreController();

            var order = controller.PlaceOrder(testOrder, "store/order1");

            result = (PetStoreResult)order;
            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));

        }


        /// <summary> 
        /// Test200FindOrderById- find order with proper given id and  proper api call
        /// response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200FindOrderById()
        {

            IPetStoreResult result;

            if (controller == null) controller = new StoreController();


            var order = controller.FindOrderById(2, "store/order");
            result = (PetStoreResult)order;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));


        }

        /// <summary> 
        /// Test400FindOrderById- find order with  improper id and  proper api call
        /// response code must be 400.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test400FindOrderById()
        {

            IPetStoreResult result;

            if (controller == null) controller = new StoreController();


            var order = controller.FindOrderById(-1, "store/order");
            result = (PetStoreResult)order;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(400));


        }

        /// <summary> 
        /// Test404FindOrderById- find order with  proper id and  mproper api call
        /// response code must be 404.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404FindOrderById()
        {

            IPetStoreResult result;

            if (controller == null) controller = new StoreController();


            var order = controller.FindOrderById(-1, "store/neworder");
            result = (PetStoreResult)order;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));


        }


        /// <summary> 
        /// Test200DeleteOrder- delete order with proper given id and  proper api call
        /// response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200DeleteOrder()
        {

            IPetStoreResult result;

            if (controller == null) controller = new StoreController();


            var order = controller.DeleteOrder(11, "store/order");
            result = (PetStoreResult)order;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));

        }

        /// <summary> 
        /// Test400DeleteOrder- delete order with improper given id and  proper api call
        /// response code must be 404.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404DeleteOrder()
        {

            IPetStoreResult result;

            if (controller == null) controller = new StoreController();


            var order = controller.DeleteOrder(11, "store/order");
            result = (PetStoreResult)order;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(404));

        }



        /// <summary> 
        /// TestInventory- get inventory details with proper api call
        /// response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test200Inventory()
        {

            IPetStoreResult result;

            if (controller == null) controller = new StoreController();


            var order = controller.GetInventory("store/inventory");
            result = (PetStoreResult)order;

            Console.WriteLine(result.ErrorCode);
            Assert.That(result.ErrorCode, Is.EqualTo(200));

        }

        /// <summary> 
        /// TestInventory- get inventory details with proper api call
        /// response code must be 200.
        /// </summary> 
        /// <returns> 
        /// Void 
        /// </returns>
        [Test]
        public void Test404Inventory()
        {

            IPetStoreResult result;

            if (controller == null) controller = new StoreController();


            var order = controller.GetInventory("store/inventory1");
            result = (PetStoreResult)order;

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