using BookLib;
using System.Collections.Generic;

namespace StoreManager
{
    public class PurchaseManager
    {
        private readonly BSManager manager;
        SaveLoadLogic<Sale> ReportDataSave = new SaveLoadLogic<Sale>("Report.txt");

        public SaveLoadLogic<Sale> PurchasesHistory = new SaveLoadLogic<Sale>("PurchasesHistory.json");

        public List<Sale> PastPurchases = new List<Sale>();
        //public Sale _sale;
        public PurchaseManager(BSManager manager)
        {
            this.manager = manager;
            PastPurchases = PurchasesHistory.LoadData();//load archive of all sold items
        }
        public void SellItem(AbstractItem item)
        {
            Sale sale = new Sale()
            {
                Title = item.Title,
                Author = item.Author,
                Publisher = item.Publisher,
                Price = item.Price,
                OnSale = item.OnSale,
                ItemDiscount = item.ItemDiscount,
                ItemType = item.GetType().Name
            };

            PastPurchases.Add(sale);
            item.Copies--;
            SavePuchaseHistory();
            if (item.Copies <= 0)
                manager.DeleteItem(item);
        }
        private void SavePuchaseHistory()
        {
            PurchasesHistory.SaveData(PastPurchases);
        }
        public void SaveReport(List<Sale> list)
        {
            ReportDataSave.SaveData(list);
        }
    }
}
