using Xunit;
using System.Collections.Generic;
using Homework.Models;
using Homework;

namespace TestSolution
{
    public class UnitTest
    {
        [Fact]
        public void MaxBatchSize()
        {
            // Arrange
            var productList = new List<Product>();
            productList.Add(new Product { Code = "P1", Name = "Milk", Price = 1.99f });
            productList.Add(new Product { Code = "P2", Name = "Sour Milk", Price = 2.05f });
            productList.Add(new Product { Code = "P3", Name = "Cream", Price = 3.59f });
            productList.Add(new Product { Code = "P4", Name = "Yoghurt", Price = 4.99f });
            productList.Add(new Product { Code = "P5", Name = "Buttermilk", Price = 3.1f });

            var batchSizeList = new List<BatchSize>();
            batchSizeList.Add(new BatchSize { Code = "BS1", Size = 20 });
            batchSizeList.Add(new BatchSize { Code = "BS2", Size = 30 });
            batchSizeList.Add(new BatchSize { Code = "BS3", Size = 40 });
            batchSizeList.Add(new BatchSize { Code = "BS4", Size = 50 });
            batchSizeList.Add(new BatchSize { Code = "BS5", Size = 100 });
            batchSizeList.Add(new BatchSize { Code = "BS6", Size = 20 });
            batchSizeList.Add(new BatchSize { Code = "BS7", Size = 50 });

            var productBatchSizeList = new List<ProductBatchSize>();
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P1", BatchSizeCode = "BS6" });
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P2", BatchSizeCode = "BS1" });
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P2", BatchSizeCode = "BS2" });
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P2", BatchSizeCode = "BS3" });
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P3", BatchSizeCode = "BS4" });
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P3", BatchSizeCode = "BS5" });
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P5", BatchSizeCode = "BS7" });

            var batchQuantityList = new List<BatchQuantity>();
            batchQuantityList.Add(new BatchQuantity { ProductCode = "P1", Quantity = 20 });
            batchQuantityList.Add(new BatchQuantity { ProductCode = "P2", Quantity = 500 });
            batchQuantityList.Add(new BatchQuantity { ProductCode = "P3", Quantity = 40 });
            batchQuantityList.Add(new BatchQuantity { ProductCode = "P4", Quantity = 234 });

            var orderCreatorService = new OrderCreatorService();
            var expectedList = orderCreatorService.CreateOrder(productList, batchSizeList, productBatchSizeList, batchQuantityList, true);

            // Act
            var actualList = new List<Order>();
            actualList.Add(new Order { ProductCode = "P1", ProductName = "Milk", BatchSizeCode = "BS6", BatchSize = 20, BatchQuantity = 20, Price = 1.99f });
            actualList.Add(new Order { ProductCode = "P2", ProductName = "Sour Milk", BatchSizeCode = "BS3", BatchSize = 40, BatchQuantity = 500, Price = 2.05f });
            actualList.Add(new Order { ProductCode = "P3", ProductName = "Cream", BatchSizeCode = "BS5", BatchSize = 100, BatchQuantity = 40, Price = 3.59f });
            actualList.Add(new Order { ProductCode = "P4", ProductName = "Yoghurt", BatchSizeCode = "BS_GENERATED_P4", BatchSize = 1, BatchQuantity = 234, Price = 4.99f });
            actualList.Add(new Order { ProductCode = "P5", ProductName = "Buttermilk", BatchSizeCode = "BS7", BatchSize = 50, BatchQuantity = 1, Price = 3.1f });

            // Assert
            Assert.False(expectedList.Count != actualList.Count, "Collections do not have the same size");
            for (var i = 0; i < expectedList.Count; i++)
            {
                Assert.Equal(expectedList[i].ProductCode, actualList[i].ProductCode);
                Assert.Equal(expectedList[i].ProductName, actualList[i].ProductName);
                Assert.Equal(expectedList[i].BatchSizeCode, actualList[i].BatchSizeCode);
                Assert.Equal(expectedList[i].BatchSize, actualList[i].BatchSize);
                Assert.Equal(expectedList[i].BatchQuantity, actualList[i].BatchQuantity);
                Assert.Equal(expectedList[i].Price, actualList[i].Price);
            }
        }
        [Fact]
        public void MinBatchSize()
        {
            // Arrange
            var productList = new List<Product>();
            productList.Add(new Product { Code = "P1", Name = "Milk", Price = 1.99f });
            productList.Add(new Product { Code = "P2", Name = "Sour Milk", Price = 2.05f });
            productList.Add(new Product { Code = "P3", Name = "Cream", Price = 3.59f });
            productList.Add(new Product { Code = "P4", Name = "Yoghurt", Price = 4.99f });
            productList.Add(new Product { Code = "P5", Name = "Buttermilk", Price = 3.1f });

            var batchSizeList = new List<BatchSize>();
            batchSizeList.Add(new BatchSize { Code = "BS1", Size = 20 });
            batchSizeList.Add(new BatchSize { Code = "BS2", Size = 30 });
            batchSizeList.Add(new BatchSize { Code = "BS3", Size = 40 });
            batchSizeList.Add(new BatchSize { Code = "BS4", Size = 50 });
            batchSizeList.Add(new BatchSize { Code = "BS5", Size = 100 });
            batchSizeList.Add(new BatchSize { Code = "BS6", Size = 20 });
            batchSizeList.Add(new BatchSize { Code = "BS7", Size = 50 });

            var productBatchSizeList = new List<ProductBatchSize>();
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P1", BatchSizeCode = "BS6" });
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P2", BatchSizeCode = "BS1" });
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P2", BatchSizeCode = "BS2" });
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P2", BatchSizeCode = "BS3" });
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P3", BatchSizeCode = "BS4" });
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P3", BatchSizeCode = "BS5" });
            productBatchSizeList.Add(new ProductBatchSize { ProductCode = "P5", BatchSizeCode = "BS7" });

            var batchQuantityList = new List<BatchQuantity>();
            batchQuantityList.Add(new BatchQuantity { ProductCode = "P1", Quantity = 20 });
            batchQuantityList.Add(new BatchQuantity { ProductCode = "P2", Quantity = 500 });
            batchQuantityList.Add(new BatchQuantity { ProductCode = "P3", Quantity = 40 });
            batchQuantityList.Add(new BatchQuantity { ProductCode = "P4", Quantity = 234 });

            var orderCreatorService = new OrderCreatorService();
            var expectedList = orderCreatorService.CreateOrder(productList, batchSizeList, productBatchSizeList, batchQuantityList, false);

            // Act
            var actualList = new List<Order>();
            actualList.Add(new Order { ProductCode = "P1", ProductName = "Milk", BatchSizeCode = "BS6", BatchSize = 20, BatchQuantity = 20, Price = 1.99f });
            actualList.Add(new Order { ProductCode = "P2", ProductName = "Sour Milk", BatchSizeCode = "BS1", BatchSize = 20, BatchQuantity = 500, Price = 2.05f });
            actualList.Add(new Order { ProductCode = "P3", ProductName = "Cream", BatchSizeCode = "BS4", BatchSize = 50, BatchQuantity = 40, Price = 3.59f });
            actualList.Add(new Order { ProductCode = "P4", ProductName = "Yoghurt", BatchSizeCode = "BS_GENERATED_P4", BatchSize = 1, BatchQuantity = 234, Price = 4.99f });
            actualList.Add(new Order { ProductCode = "P5", ProductName = "Buttermilk", BatchSizeCode = "BS7", BatchSize = 50, BatchQuantity = 1, Price = 3.1f });

            // Assert
            Assert.False(expectedList.Count != actualList.Count, "Collections do not have the same size");
            for (var i = 0; i < expectedList.Count; i++)
            {
                Assert.Equal(expectedList[i].ProductCode, actualList[i].ProductCode);
                Assert.Equal(expectedList[i].ProductName, actualList[i].ProductName);
                Assert.Equal(expectedList[i].BatchSizeCode, actualList[i].BatchSizeCode);
                Assert.Equal(expectedList[i].BatchSize, actualList[i].BatchSize);
                Assert.Equal(expectedList[i].BatchQuantity, actualList[i].BatchQuantity);
                Assert.Equal(expectedList[i].Price, actualList[i].Price);
            }
        }
    }
}
