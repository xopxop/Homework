using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Homework.Models;

namespace Homework
{
    public class OrderCreatorService
    {
        public const int DefaultBatchSize = 1;
        public const string DefaultGeneratedCode = "BS_GENERATED_";
        public const int DefaultQuantity = 1;

        public List<Order> CreateOrder(List<Product> ProductList, List<BatchSize> BatchSizeList, List<ProductBatchSize> ProductBatchSizeList, List<BatchQuantity> BatchQuantityList, bool Selection)
        {
            var OrderList = new List<Order>();
            
            foreach(var Product in ProductList)
            {
                var Order = new Order();
                Order.ProductCode = Product.Code;
                Order.ProductName = Product.Name;
                Order.BatchSizeCode = FindBatchSizeCode(Product.Code, BatchSizeList, ProductBatchSizeList, Selection);
                Order.BatchSize = FindBatchSize(Order.BatchSizeCode, BatchSizeList);
                Order.BatchQuantity = FindBatchQuantity(Product.Code, BatchQuantityList);
                Order.Price = Product.Price;
                OrderList.Add(Order);
            }
            return OrderList;
        }

        private string FindBatchSizeCode(string ProductCode, List<BatchSize> BatchSizeList, List<ProductBatchSize> ProductBatchSizeList, bool Selection)
        {
            var SelectedBatchSizeCodeList = FindSelectedBatchSizeCodeList(ProductCode, BatchSizeList, ProductBatchSizeList);

            if (SelectedBatchSizeCodeList.Count == 0)
                return DefaultGeneratedCode + ProductCode;
            else if (SelectedBatchSizeCodeList.Count == 1)
                return SelectedBatchSizeCodeList.First().Code;
            if (Selection == true)
                return FindMaximumBatchSizeCode(SelectedBatchSizeCodeList);
            return FindMinimumBatchSizeCode(SelectedBatchSizeCodeList);
        }

        private List<BatchSize> FindSelectedBatchSizeCodeList(string ProductCode, List<BatchSize> BatchSizeList, List<ProductBatchSize> ProductBatchSizeList)
        {
            var SelectedBatchSizeCodeList = new List<BatchSize>();

            foreach (var ProductBatchSize in ProductBatchSizeList)
            {
                if (ProductCode.Equals(ProductBatchSize.ProductCode))
                {
                    foreach (var BatchSize in BatchSizeList)
                    {
                        if (ProductBatchSize.BatchSizeCode.Equals(BatchSize.Code))
                        {
                            SelectedBatchSizeCodeList.Add(BatchSize);
                            break;
                        }
                    }
                }
            }
            return SelectedBatchSizeCodeList;
        }

        private string FindMaximumBatchSizeCode(List<BatchSize> SelectedBatchSizeList)
        {
            var Batch = SelectedBatchSizeList.First();
            var Max = Batch.Size;

            foreach (var SelectedBatch in SelectedBatchSizeList)
            {
                if (Max < SelectedBatch.Size)
                {
                    Batch = SelectedBatch;
                    Max = Batch.Size;
                }
            }
            return Batch.Code;
        }

        private string FindMinimumBatchSizeCode(List<BatchSize> SelectedBatchSizeList)
        {
            var Batch = SelectedBatchSizeList.First();
            var Min = Batch.Size;

            foreach (var SelectedBatch in SelectedBatchSizeList)
            {
                if (Min > SelectedBatch.Size)
                {
                    Batch = SelectedBatch;
                    Min = Batch.Size;
                }
            }
            return Batch.Code;
        }

        private int FindBatchSize(string Code, List<BatchSize> BatchSizeList)
        {
            foreach (var Batch in BatchSizeList)
                if (Code.Equals(Batch.Code))
                    return Batch.Size;
            return DefaultBatchSize;
        }

        private int FindBatchQuantity(string ProductCode, List<BatchQuantity> BatchQuantityList)
        {
            foreach (var Item in BatchQuantityList)
                if (ProductCode.Equals(Item.ProductCode))
                    return (Item.Quantity);
            return DefaultQuantity;
        }
        public string ToString(List<Order> OrderList)
        {
            var Sb = new StringBuilder();

            Sb.AppendLine("Orders");
            foreach (var Order in OrderList)
                Sb.AppendLine(String.Format("|{0,-20}|{1,-20}|{2,-20}|{3,20}|{4,20}|{5,-20}|", Order.ProductCode, Order.ProductName, Order.BatchSizeCode, Order.BatchSize, Order.BatchQuantity, Order.Price));
            return Sb.ToString();
        }
    }
}
