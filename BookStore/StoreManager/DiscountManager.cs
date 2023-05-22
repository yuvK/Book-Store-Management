using BookLib;

namespace StoreManager
{
    //discount will be live untill it's deleted, all live discounts will be loaded by app initilize
    public class DiscountManager
    {
        private readonly BSManager manager;

        public DiscountManager(BSManager manager)
        {
            this.manager = manager;
            manager.LoadDiscountList();
        }
        public void AddDiscount(Discount discount)
        {
            if (manager.DiscountList.Contains(discount))
                throw new System.Exception("this discount is allready in system, please add a diffrent one");
            else
            manager.DiscountList.Add(discount);

            if (discount.DiscountBy == DiscountBy.Title)
            {
                foreach (AbstractItem item in manager.ItemsList)
                {
                    if (item.Title == discount.Name)
                    {
                        UpdateItemDiscount(item, discount);
                    }
                }
            }
            if (discount.DiscountBy == DiscountBy.Author)
            {
                foreach (AbstractItem item in manager.ItemsList)
                {
                    if (item.Author == discount.Name)
                    {
                        UpdateItemDiscount(item, discount);
                        //discount.ItemsOnSale.Add(item);
                    }
                }
            }
            if (discount.DiscountBy == DiscountBy.Genre)
            {
                foreach (AbstractItem item in manager.ItemsList)
                {
                    if (item.GenrE.ToString() == discount.Name)
                    {
                        UpdateItemDiscount(item, discount);
                        //discount.ItemsOnSale.Add(item);
                    }
                }
            }
            if (discount.DiscountBy == DiscountBy.Publisher)
            {
                foreach (AbstractItem item in manager.ItemsList)
                {
                    if (item.Publisher == discount.Name)
                    {
                        UpdateItemDiscount(item, discount);
                    }
                }
            }
        }
        public void DeleteDiscount(Discount selectedDiscount)
        {
            if (selectedDiscount != null)
            {
                foreach (AbstractItem item in manager.ItemsList)
                {
                    if (item.OnSale == true)
                    {
                        if (item.Title == selectedDiscount.Name || item.Author == selectedDiscount.Name ||
                            item.GenrE.ToString() == selectedDiscount.Name)
                        {
                            item.OnSale = false;
                            item.ItemDiscount = 0;
                            item.PriceAfterDiscount = 0;
                        }
                    }
                }
                manager.DiscountList.Remove(selectedDiscount);
            }
        }
        public void CheckNewItemDiscouont(AbstractItem item)
        {
            foreach (Discount discount in manager.DiscountList)
            {
                if (item.Title == discount.Name || item.Author == discount.Name || item.GenrE.ToString() == discount.Name)
                {
                    UpdateItemDiscount(item, discount);
                }
            }
        }//check discounts each time a new item is added to inventory
        private void UpdateItemDiscount(AbstractItem item,Discount discount)
        {
            if (discount.DiscountPercentage > item.ItemDiscount)
            {
                double totalDiscount = (item.Price / 100) * discount.DiscountPercentage;
                item.PriceAfterDiscount = item.Price - totalDiscount;
                item.OnSale = true;
                if (!discount.ItemsOnSale.Contains(item))
                    discount.ItemsOnSale.Add(item);
            }
        }
    }
}
