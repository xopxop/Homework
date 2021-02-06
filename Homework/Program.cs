using System;
using System.Collections.Generic;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ProductPoco> productArr = new List<ProductPoco>();
            ProductPoco p1 = new ProductPoco
            {
                code = "P1",
                name = "Milk",
                price = 1.99f
            };
            ProductPoco p2 = new ProductPoco
            {
                code = "P2",
                name = "Sour Milk",
                price = 2.05f
            };
            ProductPoco p3 = new ProductPoco
            {
                code = "P3",
                name = "Cream",
                price = 3.59f
            };
            ProductPoco p4 = new ProductPoco
            {
                code = "P4",
                name = "Yoghurt",
                price = 4.99f
            };
            ProductPoco p5 = new ProductPoco
            {
                code = "P5",
                name = "Buttermilk",
                price = 3.1f
            };
            productArr.Add(p1);
            productArr.Add(p2);
            productArr.Add(p3);
            productArr.Add(p4);
            productArr.Add(p5);

            List<BatchSizePoco> batchSizeArr = new List<BatchSizePoco>();
            BatchSizePoco b1 = new BatchSizePoco
            {
                code = "BS1",
                size = 20
            };
            BatchSizePoco b2 = new BatchSizePoco
            {
                code = "BS2",
                size = 30
            };
            BatchSizePoco b3 = new BatchSizePoco
            {
                code = "BS3",
                size = 40
            };
            BatchSizePoco b4 = new BatchSizePoco
            {
                code = "BS4",
                size = 50
            };
            BatchSizePoco b5 = new BatchSizePoco
            {
                code = "BS5",
                size = 100
            };
            BatchSizePoco b6 = new BatchSizePoco
            {
                code = "BS6",
                size = 20
            };
            BatchSizePoco b7 = new BatchSizePoco
            {
                code = "BS7",
                size = 50
            };
            batchSizeArr.Add(b1);
            batchSizeArr.Add(b2);
            batchSizeArr.Add(b3);
            batchSizeArr.Add(b4);
            batchSizeArr.Add(b5);
            batchSizeArr.Add(b6);
            batchSizeArr.Add(b7);

            List<ProductBatchSizePoco> productBatchSizeArr = new List<ProductBatchSizePoco>();
            ProductBatchSizePoco pb1 = new ProductBatchSizePoco
            {
                productCode = "P1",
                batchSizeCode = "BS6"
            };
            ProductBatchSizePoco pb2 = new ProductBatchSizePoco
            {
                productCode = "P2",
                batchSizeCode = "BS1"
            };
            ProductBatchSizePoco pb3 = new ProductBatchSizePoco
            {
                productCode = "P2",
                batchSizeCode = "BS2"
            };
            ProductBatchSizePoco pb4 = new ProductBatchSizePoco
            {
                productCode = "P2",
                batchSizeCode = "BS3"
            };
            ProductBatchSizePoco pb5 = new ProductBatchSizePoco
            {
                productCode = "P3",
                batchSizeCode = "BS4"
            };
            ProductBatchSizePoco pb6 = new ProductBatchSizePoco
            {
                productCode = "P3",
                batchSizeCode = "BS5"
            };
            ProductBatchSizePoco pb7 = new ProductBatchSizePoco
            {
                productCode = "P5",
                batchSizeCode = "BS7"
            };
            productBatchSizeArr.Add(pb1);
            productBatchSizeArr.Add(pb2);
            productBatchSizeArr.Add(pb3);
            productBatchSizeArr.Add(pb4);
            productBatchSizeArr.Add(pb5);
            productBatchSizeArr.Add(pb6);
            productBatchSizeArr.Add(pb7);

            List<BatchQuantityPoco> batchQuantityArr = new List<BatchQuantityPoco>();
            BatchQuantityPoco q1 = new BatchQuantityPoco
            {
                productCode = "P1",
                quantity = 20
            };
            BatchQuantityPoco q2 = new BatchQuantityPoco
            {
                productCode = "P2",
                quantity = 500
            };
            BatchQuantityPoco q3 = new BatchQuantityPoco
            {
                productCode = "P3",
                quantity = 40
            };
            BatchQuantityPoco q4 = new BatchQuantityPoco
            {
                productCode = "P4",
                quantity = 234
            };
            batchQuantityArr.Add(q1);
            batchQuantityArr.Add(q2);
            batchQuantityArr.Add(q3);
            batchQuantityArr.Add(q4);

            OrderPoco[] orders = solution(productArr.ToArray(), batchSizeArr.ToArray(), productBatchSizeArr.ToArray(), batchQuantityArr.ToArray(), false);
            printOrders(orders);
        }

        static public OrderPoco[] solution(ProductPoco[] productArr, BatchSizePoco[] batchSizeArr, ProductBatchSizePoco[] productBatchSizeArr, BatchQuantityPoco[] batchQuantityArr, bool selection)
        {
            List<OrderPoco> orders = new List<OrderPoco>();

            foreach (ProductPoco product in productArr)
                orders.Add(new OrderPoco(product, batchSizeArr, productBatchSizeArr, batchQuantityArr, selection));
            return (orders.ToArray());
        }

        static void printOrders(OrderPoco[] arr)
        {
            Console.WriteLine("Orders");
            foreach (OrderPoco order in arr)
                Console.WriteLine(order.ToString());
        }
    }
}
