using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class OrderPoco
    {
        public string productCode { get; set; }
        public string productName { get; set; }
        public string batchSizeCode { get; set; }
        public int batchSize { get; set; }
        public int batchQuantity { get; set; }
        public float price { get; set; }
        const int DEFAULT_BATCH_SIZE = 1;
        const string DEFAULT_GENERATED_CODE = "BS_GENERATED_";
        const int DEFAULT_QUANTITY = 1;
        public OrderPoco(ProductPoco product, BatchSizePoco[] batchSizeArr, ProductBatchSizePoco[] productBatchSizeArr, BatchQuantityPoco[] batchQuantityArr, bool selection)
        {
            productCode = product.code;
            productName = product.name;
            batchSizeCode = findBatchSizeCode(product.code, productBatchSizeArr, batchSizeArr, selection);
            batchSize = findBatchSize(batchSizeCode, batchSizeArr);
            batchQuantity = findBatchQuantity(productCode, batchQuantityArr);
            price = product.price;
        }

        private string findBatchSizeCode(string productCode, ProductBatchSizePoco[] productBatchSizeArr, BatchSizePoco[] batchSizeArr, bool selection)
        {
            BatchSizePoco[] selectedBatchSizeCodeArr = findSelectedBatchSizeCodeArr(productCode, productBatchSizeArr, batchSizeArr);

            if (selectedBatchSizeCodeArr.Length == 0)
                return (DEFAULT_GENERATED_CODE + productCode);
            else if (selectedBatchSizeCodeArr.Length == 1)
                return (selectedBatchSizeCodeArr[0].code);
            if (selection == true)
                return (maximumBatchSizeCode(selectedBatchSizeCodeArr));
            return (minimumBatchSizeCode(selectedBatchSizeCodeArr));
        }

        private BatchSizePoco[] findSelectedBatchSizeCodeArr(string productCode, ProductBatchSizePoco[] productBatchSizeArr, BatchSizePoco[] batchSizeArr)
        {
            List<BatchSizePoco> arr = new List<BatchSizePoco>();

            foreach (ProductBatchSizePoco item in productBatchSizeArr)
            {
                if (productCode.Equals(item.productCode))
                {
                    foreach (BatchSizePoco size in batchSizeArr)
                    {
                        if (item.batchSizeCode.Equals(size.code))
                        {
                            arr.Add(size);
                            break;
                        }
                    }
                }
            }
            return (arr.ToArray());
        }

        private string maximumBatchSizeCode(BatchSizePoco[] selectedArr)
        {
            int max = selectedArr[0].size;
            BatchSizePoco ptr = selectedArr[0];

            foreach (BatchSizePoco batch in selectedArr)
            {
                if (max < batch.size)
                {
                    max = batch.size;
                    ptr = batch;
                }
            }
            return (ptr.code);
        }

        private string minimumBatchSizeCode(BatchSizePoco[] selectedArr)
        {
            int min = selectedArr[0].size;
            BatchSizePoco ptr = selectedArr[0];

            foreach (BatchSizePoco batch in selectedArr)
            {
                if (min > batch.size)
                {
                    min = batch.size;
                    ptr = batch;
                }
            }
            return (ptr.code);
        }

        private int findBatchSize(string code, BatchSizePoco[] batchSizeArr)
        {
            foreach (BatchSizePoco batch in batchSizeArr)
                if (code.Equals(batch.code))
                    return (batch.size);
            return (DEFAULT_BATCH_SIZE);
        }

        private int findBatchQuantity(string productCode, BatchQuantityPoco[] batchQuantityArr)
        {
            foreach (BatchQuantityPoco item in batchQuantityArr)
                if (productCode.Equals(item.productCode))
                    return (item.quantity);
            return (DEFAULT_QUANTITY);
        }
        public override string ToString()
        {
            string str = string.Format("|{0,-20}|{1,-20}|{2,-20}|{3,20}|{4,20}|{5,-20}|", productCode, productName, batchSizeCode, batchSize, batchQuantity, price);
            return str;
        }
    }
}
