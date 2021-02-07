using Xunit;
using Homework.Models;
using Homework;
using System.Collections.Generic;

namespace TestSolution
{
    public class UnitTest
    {
        [Fact]
        public void MaxBatchSize()
        {
            var ProductList = new List<Product>();
            var P1 = new Product { Code = "P1", Name = "Milk", Price = 1.99f };
            var P2 = new Product { Code = "P2", Name = "Sour Milk", Price = 2.05f };
            var P3 = new Product { Code = "P3", Name = "Cream", Price = 3.59f };
            var P4 = new Product { Code = "P4", Name = "Yoghurt", Price = 4.99f };
            var P5 = new Product { Code = "P5", Name = "Buttermilk", Price = 3.1f };
            ProductList.Add(P1);
            ProductList.Add(P2);
            ProductList.Add(P3);
            ProductList.Add(P4);
            ProductList.Add(P5);

            var BatchSizeList = new List<BatchSize>();
            var BS1 = new BatchSize { Code = "BS1", Size = 20 };
            var BS2 = new BatchSize { Code = "BS2", Size = 30 };
            var BS3 = new BatchSize { Code = "BS3", Size = 40 };
            var BS4 = new BatchSize { Code = "BS4", Size = 50 };
            var BS5 = new BatchSize { Code = "BS5", Size = 100 };
            var BS6 = new BatchSize { Code = "BS6", Size = 20 };
            var BS7 = new BatchSize { Code = "BS7", Size = 50 };
            BatchSizeList.Add(BS1);
            BatchSizeList.Add(BS2);
            BatchSizeList.Add(BS3);
            BatchSizeList.Add(BS4);
            BatchSizeList.Add(BS5);
            BatchSizeList.Add(BS6);
            BatchSizeList.Add(BS7);

            var ProductBatchSizeList = new List<ProductBatchSize>();
            var PB1 = new ProductBatchSize { ProductCode = "P1", BatchSizeCode = "BS6" };
            var PB2 = new ProductBatchSize { ProductCode = "P2", BatchSizeCode = "BS1" };
            var PB3 = new ProductBatchSize { ProductCode = "P2", BatchSizeCode = "BS2" };
            var PB4 = new ProductBatchSize { ProductCode = "P2", BatchSizeCode = "BS3" };
            var PB5 = new ProductBatchSize { ProductCode = "P3", BatchSizeCode = "BS4" };
            var PB6 = new ProductBatchSize { ProductCode = "P3", BatchSizeCode = "BS5" };
            var PB7 = new ProductBatchSize { ProductCode = "P5", BatchSizeCode = "BS7" };
            ProductBatchSizeList.Add(PB1);
            ProductBatchSizeList.Add(PB2);
            ProductBatchSizeList.Add(PB3);
            ProductBatchSizeList.Add(PB4);
            ProductBatchSizeList.Add(PB5);
            ProductBatchSizeList.Add(PB6);
            ProductBatchSizeList.Add(PB7);

            var BatchQuantityList = new List<BatchQuantity>();
            var BQ1 = new BatchQuantity { ProductCode = "P1", Quantity = 20 };
            var BQ2 = new BatchQuantity { ProductCode = "P2", Quantity = 500 };
            var BQ3 = new BatchQuantity { ProductCode = "P3", Quantity = 40 };
            var BQ4 = new BatchQuantity { ProductCode = "P4", Quantity = 234 };
            BatchQuantityList.Add(BQ1);
            BatchQuantityList.Add(BQ2);
            BatchQuantityList.Add(BQ3);
            BatchQuantityList.Add(BQ4);

            var OrderCreatorService = new OrderCreatorService();
            var OrderList = OrderCreatorService.CreateOrder(ProductList, BatchSizeList, ProductBatchSizeList, BatchQuantityList, true);

            var Result = new List<Order>();
            var O1 = new Order { ProductCode = "P1", ProductName = "Milk", BatchSizeCode = "BS6", BatchSize = 20, BatchQuantity = 20, Price = 1.99f };
            var O2 = new Order { ProductCode = "P2", ProductName = "Sour Milk", BatchSizeCode = "BS3", BatchSize = 40, BatchQuantity = 500, Price = 2.05f };
            var O3 = new Order { ProductCode = "P3", ProductName = "Cream", BatchSizeCode = "BS5", BatchSize = 100, BatchQuantity = 40, Price = 3.59f };
            var O4 = new Order { ProductCode = "P4", ProductName = "Yoghurt", BatchSizeCode = "BS_GENERATED_P4", BatchSize = 1, BatchQuantity = 234, Price = 4.99f };
            var O5 = new Order { ProductCode = "P5", ProductName = "Buttermilk", BatchSizeCode = "BS7", BatchSize = 50, BatchQuantity = 1, Price = 3.1f };

            Result.Add(O1);
            Result.Add(O2);
            Result.Add(O3);
            Result.Add(O4);
            Result.Add(O5);

            Assert.Equal(OrderCreatorService.ToString(OrderList), OrderCreatorService.ToString(Result));
        }
        [Fact]
        public void MinBatchSize()
        {
            var ProductList = new List<Product>();
            var P1 = new Product { Code = "P1", Name = "Milk", Price = 1.99f };
            var P2 = new Product { Code = "P2", Name = "Sour Milk", Price = 2.05f };
            var P3 = new Product { Code = "P3", Name = "Cream", Price = 3.59f };
            var P4 = new Product { Code = "P4", Name = "Yoghurt", Price = 4.99f };
            var P5 = new Product { Code = "P5", Name = "Buttermilk", Price = 3.1f };
            ProductList.Add(P1);
            ProductList.Add(P2);
            ProductList.Add(P3);
            ProductList.Add(P4);
            ProductList.Add(P5);

            var BatchSizeList = new List<BatchSize>();
            var BS1 = new BatchSize { Code = "BS1", Size = 20 };
            var BS2 = new BatchSize { Code = "BS2", Size = 30 };
            var BS3 = new BatchSize { Code = "BS3", Size = 40 };
            var BS4 = new BatchSize { Code = "BS4", Size = 50 };
            var BS5 = new BatchSize { Code = "BS5", Size = 100 };
            var BS6 = new BatchSize { Code = "BS6", Size = 20 };
            var BS7 = new BatchSize { Code = "BS7", Size = 50 };
            BatchSizeList.Add(BS1);
            BatchSizeList.Add(BS2);
            BatchSizeList.Add(BS3);
            BatchSizeList.Add(BS4);
            BatchSizeList.Add(BS5);
            BatchSizeList.Add(BS6);
            BatchSizeList.Add(BS7);

            var ProductBatchSizeList = new List<ProductBatchSize>();
            var PB1 = new ProductBatchSize { ProductCode = "P1", BatchSizeCode = "BS6" };
            var PB2 = new ProductBatchSize { ProductCode = "P2", BatchSizeCode = "BS1" };
            var PB3 = new ProductBatchSize { ProductCode = "P2", BatchSizeCode = "BS2" };
            var PB4 = new ProductBatchSize { ProductCode = "P2", BatchSizeCode = "BS3" };
            var PB5 = new ProductBatchSize { ProductCode = "P3", BatchSizeCode = "BS4" };
            var PB6 = new ProductBatchSize { ProductCode = "P3", BatchSizeCode = "BS5" };
            var PB7 = new ProductBatchSize { ProductCode = "P5", BatchSizeCode = "BS7" };
            ProductBatchSizeList.Add(PB1);
            ProductBatchSizeList.Add(PB2);
            ProductBatchSizeList.Add(PB3);
            ProductBatchSizeList.Add(PB4);
            ProductBatchSizeList.Add(PB5);
            ProductBatchSizeList.Add(PB6);
            ProductBatchSizeList.Add(PB7);

            var BatchQuantityList = new List<BatchQuantity>();
            var BQ1 = new BatchQuantity { ProductCode = "P1", Quantity = 20 };
            var BQ2 = new BatchQuantity { ProductCode = "P2", Quantity = 500 };
            var BQ3 = new BatchQuantity { ProductCode = "P3", Quantity = 40 };
            var BQ4 = new BatchQuantity { ProductCode = "P4", Quantity = 234 };
            BatchQuantityList.Add(BQ1);
            BatchQuantityList.Add(BQ2);
            BatchQuantityList.Add(BQ3);
            BatchQuantityList.Add(BQ4);

            var OrderCreatorService = new OrderCreatorService();
            var OrderList = OrderCreatorService.CreateOrder(ProductList, BatchSizeList, ProductBatchSizeList, BatchQuantityList, false);

            var Result = new List<Order>();
            var O1 = new Order { ProductCode = "P1", ProductName = "Milk", BatchSizeCode = "BS6", BatchSize = 20, BatchQuantity = 20, Price = 1.99f };
            var O2 = new Order { ProductCode = "P2", ProductName = "Sour Milk", BatchSizeCode = "BS1", BatchSize = 20, BatchQuantity = 500, Price = 2.05f };
            var O3 = new Order { ProductCode = "P3", ProductName = "Cream", BatchSizeCode = "BS4", BatchSize = 50, BatchQuantity = 40, Price = 3.59f };
            var O4 = new Order { ProductCode = "P4", ProductName = "Yoghurt", BatchSizeCode = "BS_GENERATED_P4", BatchSize = 1, BatchQuantity = 234, Price = 4.99f };
            var O5 = new Order { ProductCode = "P5", ProductName = "Buttermilk", BatchSizeCode = "BS7", BatchSize = 50, BatchQuantity = 1, Price = 3.1f };

            Result.Add(O1);
            Result.Add(O2);
            Result.Add(O3);
            Result.Add(O4);
            Result.Add(O5);

            Assert.Equal(OrderCreatorService.ToString(OrderList), OrderCreatorService.ToString(Result));
        }
    }
}
