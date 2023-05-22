using BookLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StoreManager
{
    public class BSManager
    {
        List<AbstractItem> _itemsList = new List<AbstractItem>(); //main inventory list

        private SaveLoadLogic<AbstractItem> saveMainList = new SaveLoadLogic<AbstractItem>("ItemsList.json");
        private SaveLoadLogic<Discount> saveDiscountList = new SaveLoadLogic<Discount>("DiscountsList.json");

        public ObservableCollection<AbstractItem> filteredList;//List for view
        public List<AbstractItem> ItemsList { get { return _itemsList; } set { value = _itemsList; } }

        public ObservableCollection<Discount> DiscountList = new ObservableCollection<Discount>();

        public PurchaseManager purchaseManager;
        public DiscountManager discountManager;
        public FilterManager filterManager;
        public AbstractItem ItemToEdit { get; set; }
        public BSManager()
        {
            purchaseManager = new PurchaseManager(this);
            discountManager = new DiscountManager(this);
            filterManager = new FilterManager(this);

            List<AbstractItem> temp = saveMainList.LoadData();
            if (temp != null)
            {
                _itemsList = temp;
                filteredList = new ObservableCollection<AbstractItem>(temp);
            }
            

            #region Products List for first init of app:

            //_itemsList.Add(new Book("Moby Dick", "Herman Melville", 15, Genre.Adventure, 25, 1234657890123, "Richard Bentley", new DateTime(1851, 10, 1), 10, "ms-appx:///Images/BookCovers/MobyDick.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."));
            //_itemsList.Add(new Book("Total F*cking Godhead", "Corbin Reiff", 1, Genre.Biography, 26.04, 9781642932157, "Post Hill Press", new DateTime(2020, 7, 15), 5, "ms-appx:///Images/BookCovers/TotalFuckingGodhead.jpg", "For those of us still trying to sort out the tragedy of Chris Cornell's death comes this loving look back at the man's life and music."));
            //_itemsList.Add(new Book("Everyone Poops", "Taro Gomi", 3, Genre.Kids, 15.80, 9781797202648, "Chronicle Books", new DateTime(2020, 1, 1), 12, "ms-appx:///Images/BookCovers/EveryonePoops.jpg", "The beloved, bestselling potty-training classic, now in hardcover for a new generation!"));
            //_itemsList.Add(new Book("Cooking for Happiness", "Kornelia Santoro", 4, Genre.Cookbook, 19.99, 9789350297650, "HarperCollins India", new DateTime(2017, 5, 2), 8, "ms-appx:///Images/BookCovers/CookingforHappiness.jpg", "award-winning food writer Kornelia Santoro offers a hundred easy-to-prepare recipes that will nurture your brain and help you fight those dreaded lows."));
            //_itemsList.Add(new Book("Tattoo Bible One", "Superior Tattoo", 2, Genre.Art, 32.95, 9781929133840, "Artkulture", new DateTime(2009, 12, 1), 4, "ms-appx:///Images/BookCovers/TattooBibleOne.jpg", "Whether you are preparing for your first tattoo or your twenty-seventh, you need artwork and designs that are just right. Tattoo Bible, authored by Superior Tattoo, provides well over 500 pieces of unique flash art - flash never before compiled into one single book."));
            //_itemsList.Add(new Book("Tattoo Bible: Book Two", "Superior Tattoo", 1, Genre.Art, 32.95, 9781929133840, "Artkulture", new DateTime(2010, 8, 15), 2, "ms-appx:///Images/BookCovers/TattooBibleBookTwo.jpg", "Tattoo Bible Book Two, covers different tattoo styles and an endless supply of ideas. Make your own design by combining different pieces of art from within the book, or use one of the images as a stand-alone tattoo."));
            //_itemsList.Add(new Book("The Depths", "Nicole Lesperance", 2, Genre.Horror, 18.99, 9780593465363, "Razorbill", new DateTime(2022, 9, 13), 7, "ms-appx:///Images/BookCovers/TheDepths.jpg", "A tropical island full of secrets. Two Victorian ghosts, trapped for eternity. And a seventeen-year-old girl determined not to be next."));
            //_itemsList.Add(new Book("It Starts with Us", "Colleen Hoover", 4, Genre.Romance, 17.99, 9781668001226, "Atria Books", new DateTime(2022, 10, 8), 5, "ms-appx:///Images/BookCovers/ItStartsWithUs.jpg", "Lily and her ex-husband, Ryle, have just settled into a civil coparenting rhythm when she suddenly bumps into her first love, Atlas, again. After nearly two years separated, she is elated that for once, time is on their side, and she immediately says yes when Atlas asks her on a date."));
            //_itemsList.Add(new Journal("National Geographic, August 2002", "National Geographic", 1, Genre.Guide, 9.99, 9781345937688, "National Geographic Society", new DateTime(2002, 8, 1), 12, "ms-appx:///Images/BookCovers/NG82002.jpg", "One of the world's leading nonfiction publishers, National Geographic Books has published more than 1,700 titles, featuring such categories as history, travel, nature, photography, space, science, health, biography, and memoir. A portion of its proceeds is used to fund exploration, conservation, and education through ongoing contributions to the work of the National Geographic Society."));
            //_itemsList.Add(new Journal("National Geographic, July 2006", "National Geographic", 1, Genre.Guide, 9.99, 9781345937689, "National Geographic Society", new DateTime(2006, 7, 1), 3, "ms-appx:///Images/BookCovers/NG72006.jpg", "One of the world's leading nonfiction publishers, National Geographic Books has published more than 1,700 titles, featuring such categories as history, travel, nature, photography, space, science, health, biography, and memoir. A portion of its proceeds is used to fund exploration, conservation, and education through ongoing contributions to the work of the National Geographic Society."));
            //_itemsList.Add(new Journal("National Geographic, December 2004", "National Geographic", 1, Genre.Guide, 9.99, 9781345937690, "National Geographic Society", new DateTime(2004, 12, 1), 7, "ms-appx:///Images/BookCovers/NG122004.jpg", "One of the world's leading nonfiction publishers, National Geographic Books has published more than 1,700 titles, featuring such categories as history, travel, nature, photography, space, science, health, biography, and memoir. A portion of its proceeds is used to fund exploration, conservation, and education through ongoing contributions to the work of the National Geographic Society."));
            //_itemsList.Add(new Journal("National Geographic, May 2012", "National Geographic", 1, Genre.Guide, 9.99, 9781345937691, "National Geographic Society", new DateTime(2012, 5, 1), 6, "ms-appx:///Images/BookCovers/NG52012.jpg", "One of the world's leading nonfiction publishers, National Geographic Books has published more than 1,700 titles, featuring such categories as history, travel, nature, photography, space, science, health, biography, and memoir. A portion of its proceeds is used to fund exploration, conservation, and education through ongoing contributions to the work of the National Geographic Society."));
            //_itemsList.Add(new Journal("Travel & Leisure, January 2004", "Various Writers", 1, Genre.Travel, 7.99, 9517537896842, "Meredith Corporation", new DateTime(2004, 1, 1), 8, "ms-appx:///Images/BookCovers/TL12004.jpg", "Travel + Leisure reveals the best travel destinations in the world! Readers discover where to find the best hotels, the best shopping, the best food, and the most fun. With Travel + Leisure, readers discover hot deals on vacation travel and get tons of insider travel tips to help them save money, reduce travel headaches and enjoy every trip more than ever!"));
            //_itemsList.Add(new Journal("Travel & Leisure, December 1999", "Various Writers", 1, Genre.Travel, 7.99, 9517537896843, "Meredith Corporation", new DateTime(1999, 12, 1), 8, "ms-appx:///Images/BookCovers/TL121999.jpg", "Travel + Leisure reveals the best travel destinations in the world! Readers discover where to find the best hotels, the best shopping, the best food, and the most fun. With Travel + Leisure, readers discover hot deals on vacation travel and get tons of insider travel tips to help them save money, reduce travel headaches and enjoy every trip more than ever!"));

            #endregion

            #region Discounts for first init of app:
            //discountManager.AddDiscount(new Discount(DiscountBy.Title, "Moby Dick", 30));
            //discountManager.AddDiscount(new Discount(DiscountBy.Genre, "Kids", 50)); 
            #endregion
        }
        public List<string> GetInventoryByTitle()
        {
            List<string> temp = new List<string>();
            foreach (AbstractItem item in _itemsList)
            {
                if (!temp.Contains(item.Title))
                    temp.Add(item.Title);
            }
            return temp;
        }
        public List<string> GetInventoryByAuthor()
        {
            List<string> temp = new List<string>();
            foreach (AbstractItem item in _itemsList)
            {
                if (!temp.Contains(item.Author))
                    temp.Add(item.Author);
            }
            return temp;
        }
        public List<string> GetInventoryByPublisher()
        {
            List<string> temp = new List<string>();
            foreach (AbstractItem item in _itemsList)
            {
                if (!temp.Contains(item.Publisher))
                    temp.Add(item.Publisher);
            }
            return temp;
        }
        public void AddItem(AbstractItem item)
        {
            if (item == null || item.Title == null)
                return;

            if (_itemsList.Contains(item))
                item.Copies += item.Copies;
            else
            {
                discountManager.CheckNewItemDiscouont(item);
                _itemsList.Add(item);
                filteredList.Add(item);
            }
        }
        public void DeleteItem(AbstractItem item)
        {
            if (item != null)
            {
                _itemsList.Remove(item);
                filteredList.Remove(item);
            }
        }
        public void SaveFile()
        {
            saveMainList.SaveData(_itemsList);
        }
        public void LoadFile()
        {
            _itemsList = saveMainList.LoadData();
        }
        public void SaveDiscountsList()
        {
            saveDiscountList.SaveData(DiscountList);
        }
        public void LoadDiscountList()
        {
            if (saveDiscountList.LoadData() != null)
            {
                List<Discount> temp = saveDiscountList.LoadData();
                foreach (var item in temp)
                {
                    DiscountList.Add(item);
                }
            }
        }
    }
}
