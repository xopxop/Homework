using Homework.Models;
using System.Collections.Generic;
using System.Text;
using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Max Batch Size Selection");
            MaxBatchSize();
            Console.WriteLine("Min Batch Size Selection");
            MinBatchSize();
        }
        public static void MaxBatchSize()
        {
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

            var result = new List<Order>();
            result.Add(new Order { ProductCode = "P1", ProductName = "Milk", BatchSizeCode = "BS6", BatchSize = 20, BatchQuantity = 20, Price = 1.99f });
            result.Add(new Order { ProductCode = "P2", ProductName = "Sour Milk", BatchSizeCode = "BS3", BatchSize = 40, BatchQuantity = 500, Price = 2.05f });
            result.Add(new Order { ProductCode = "P3", ProductName = "Cream", BatchSizeCode = "BS5", BatchSize = 100, BatchQuantity = 40, Price = 3.59f });
            result.Add(new Order { ProductCode = "P4", ProductName = "Yoghurt", BatchSizeCode = "BS_GENERATED_P4", BatchSize = 1, BatchQuantity = 234, Price = 4.99f });
            result.Add(new Order { ProductCode = "P5", ProductName = "Buttermilk", BatchSizeCode = "BS7", BatchSize = 50, BatchQuantity = 1, Price = 3.1f });

            var orderCreatorService = new OrderCreatorService();
            var orderList = orderCreatorService.CreateOrder(productList, batchSizeList, productBatchSizeList, batchQuantityList, true);

            Console.WriteLine("Expected Result");
            Console.WriteLine(ToString(orderList));
            Console.WriteLine("Actual Result");
            Console.WriteLine(ToString(result));
        }
        public static void MinBatchSize()
        {
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

            var result = new List<Order>();
            result.Add(new Order { ProductCode = "P1", ProductName = "Milk", BatchSizeCode = "BS6", BatchSize = 20, BatchQuantity = 20, Price = 1.99f });
            result.Add(new Order { ProductCode = "P2", ProductName = "Sour Milk", BatchSizeCode = "BS1", BatchSize = 20, BatchQuantity = 500, Price = 2.05f });
            result.Add(new Order { ProductCode = "P3", ProductName = "Cream", BatchSizeCode = "BS4", BatchSize = 50, BatchQuantity = 40, Price = 3.59f });
            result.Add(new Order { ProductCode = "P4", ProductName = "Yoghurt", BatchSizeCode = "BS_GENERATED_P4", BatchSize = 1, BatchQuantity = 234, Price = 4.99f });
            result.Add(new Order { ProductCode = "P5", ProductName = "Buttermilk", BatchSizeCode = "BS7", BatchSize = 50, BatchQuantity = 1, Price = 3.1f });

            var orderCreatorService = new OrderCreatorService();
            var orderList = orderCreatorService.CreateOrder(productList, batchSizeList, productBatchSizeList, batchQuantityList, false);

            Console.WriteLine("Expected Result");
            Console.WriteLine(ToString(orderList));
            Console.WriteLine("Actual Result");
            Console.WriteLine(ToString(result));
        }
        public static string ToString(List<Order> OrderList)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Orders");
            foreach (var Order in OrderList)
                sb.AppendLine(string.Format("|{0,-20}|{1,-20}|{2,-20}|{3,20}|{4,20}|{5,-20}|", Order.ProductCode, Order.ProductName, Order.BatchSizeCode, Order.BatchSize, Order.BatchQuantity, Order.Price));
            return sb.ToString();
        }
    }
}
