using System.Collections.Generic;
using System.Linq;
using Homework.Models;

namespace Homework
{
    public class OrderCreatorService
    {
        private const int DefaultBatchSize = 1;
        private const string DefaultGeneratedCode = "BS_GENERATED_";
        private const int DefaultQuantity = 1;

        public List<Order> CreateOrder(List<Product> ProductList, List<BatchSize> BatchSizeList, List<ProductBatchSize> ProductBatchSizeList, List<BatchQuantity> BatchQuantityList, bool Selection)
        {
            var orderList = new List<Order>();
            
            foreach(var product in ProductList)
            {
                var order = new Order();
                order.ProductCode = product.Code;
                order.ProductName = product.Name;
                order.BatchSizeCode = FindBatchSizeCode(product.Code, BatchSizeList, ProductBatchSizeList, Selection);
                order.BatchSize = FindBatchSize(order.BatchSizeCode, BatchSizeList);
                order.BatchQuantity = FindBatchQuantity(product.Code, BatchQuantityList);
                order.Price = product.Price;
                orderList.Add(order);
            }
            return orderList;
        }

        private string FindBatchSizeCode(string ProductCode, List<BatchSize> BatchSizeList, List<ProductBatchSize> ProductBatchSizeList, bool Selection)
        {
            var selectedBatchSizeCodeList = FindSelectedBatchSizeCodeList(ProductCode, BatchSizeList, ProductBatchSizeList);

            if (selectedBatchSizeCodeList.Count == 0)
            {
                return DefaultGeneratedCode + ProductCode;
            }
            else if (selectedBatchSizeCodeList.Count == 1)
            {
                return selectedBatchSizeCodeList.First().Code;
            }
            if (Selection == true)
            {
                return FindMaximumBatchSizeCode(selectedBatchSizeCodeList);
            }
            return FindMinimumBatchSizeCode(selectedBatchSizeCodeList);
        }

        private List<BatchSize> FindSelectedBatchSizeCodeList(string ProductCode, List<BatchSize> BatchSizeList, List<ProductBatchSize> ProductBatchSizeList)
        {
            var selectedBatchSizeCodeList = new List<BatchSize>();

            foreach (var productBatchSize in ProductBatchSizeList)
            {
                if (ProductCode.Equals(productBatchSize.ProductCode))
                {
                    foreach (var batchSize in BatchSizeList)
                    {
                        if (productBatchSize.BatchSizeCode.Equals(batchSize.Code))
                        {
                            selectedBatchSizeCodeList.Add(batchSize);
                            break;
                        }
                    }
                }
            }
            return selectedBatchSizeCodeList;
        }

        private string FindMaximumBatchSizeCode(List<BatchSize> SelectedBatchSizeList)
        {
            var batch = SelectedBatchSizeList.First();
            var max = batch.Size;

            foreach (var selectedBatch in SelectedBatchSizeList)
            {
                if (max < selectedBatch.Size)
                {
                    batch = selectedBatch;
                    max = batch.Size;
                }
            }
            return batch.Code;
        }

        private string FindMinimumBatchSizeCode(List<BatchSize> SelectedBatchSizeList)
        {
            var batch = SelectedBatchSizeList.First();
            var min = batch.Size;

            foreach (var selectedBatch in SelectedBatchSizeList)
            {
                if (min > selectedBatch.Size)
                {
                    batch = selectedBatch;
                    min = batch.Size;
                }
            }
            return batch.Code;
        }

        private int FindBatchSize(string Code, List<BatchSize> BatchSizeList)
        {
            foreach (var batch in BatchSizeList)
            {
                if (Code.Equals(batch.Code))
                {
                    return batch.Size;
                }
            }
            return DefaultBatchSize;
        }

        private int FindBatchQuantity(string ProductCode, List<BatchQuantity> BatchQuantityList)
        {
            foreach (var item in BatchQuantityList)
            {
                if (ProductCode.Equals(item.ProductCode))
                {
                    return (item.Quantity);
                }
            }
            return DefaultQuantity;
        }
    }
}
