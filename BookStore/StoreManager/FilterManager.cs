using BookLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManager
{
    public enum FilterBy
    {
        All,
        Books,
        Journals,
        Title,
        Author,
        Publisher,
        Genre,
        On_Sale
    }
    public class FilterManager //: INotifyPropertyChanged
    {
        private readonly BSManager manager;
        public FilterManager(BSManager manager)
        {
            this.manager = manager;
        }
        public void SearchList(int FilterBy, string filter)
        {
            List<AbstractItem> TempFiltered = new List<AbstractItem>();
            foreach (AbstractItem item in manager.ItemsList)
            {
                if (item.Title.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase) ||
                    item.Author.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase) ||
                    item.Publisher.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase))
                {
                    TempFiltered.Add(item);
                }
            }
            for (int i = manager.ItemsList.Count - 1; i >= 0; i--)
            {
                AbstractItem item = manager.ItemsList[i];
                if (!TempFiltered.Contains(item))
                {
                    manager.filteredList.Remove(item);
                }
            }
            foreach (AbstractItem item in TempFiltered)
            {
                if (!manager.filteredList.Contains(item))
                {
                    manager.filteredList.Add(item);
                }
            }
        }
        public void FilterList(string filter)
        {
            List<AbstractItem> TempFiltered = new List<AbstractItem>();
            switch (filter)
            {
                case "Undifined":
                    TempFiltered = manager.ItemsList;
                    break;
                case "Books":
                    TempFiltered = manager.ItemsList.Where(x => x.GetType() == typeof(Book)).ToList();
                    break;
                case "Journals":
                    TempFiltered = manager.ItemsList.Where(x => x.GetType() == typeof(Journal)).ToList();
                    break;
                case "Fantasy":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Fantasy).ToList();
                    break;
                case "Adventure":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Adventure).ToList();
                    break;
                case "Romance":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Romance).ToList();
                    break;
                case "Mystery":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Mystery).ToList();
                    break;
                case "Horror":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Humor).ToList();
                    break;
                case "Thriller":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Thriller).ToList();
                    break;
                case "Science":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Science).ToList();
                    break;
                case "Kids":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Kids).ToList();
                    break;
                case "Biography":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Biography).ToList();
                    break;
                case "Cookbook":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Cookbook).ToList();
                    break;
                case "Art":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Art).ToList();
                    break;
                case "History":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.History).ToList();
                    break;
                case "Travel":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Travel).ToList();
                    break;
                case "Guide":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Guide).ToList();
                    break;
                case "Humor":
                    TempFiltered = manager.ItemsList.Where(x => x.GenrE == Genre.Humor).ToList();
                    break;
                case "OnSale":
                    TempFiltered = manager.ItemsList.Where(x => x.OnSale == true).ToList();
                    break;

                default:
                    break;
            }
            for (int i = manager.ItemsList.Count - 1; i >= 0; i--)
            {
                AbstractItem item = manager.ItemsList[i];
                if (!TempFiltered.Contains(item))
                {
                    manager.filteredList.Remove(item);
                }
            }
            foreach (AbstractItem item in TempFiltered)
            {
                if (!manager.filteredList.Contains(item))
                {
                    manager.filteredList.Add(item);
                }
            }
        }
        public void FilterListByName(string filterBy, string filter)
        {
            List<AbstractItem> TempFiltered = new List<AbstractItem>();
            switch (filterBy)
            {
                case "Title":
                    foreach (AbstractItem item in manager.ItemsList)
                    {
                        if (item.Title == filter)
                            TempFiltered.Add(item);
                    }
                    break;
                case "Author":
                    foreach (AbstractItem item in manager.ItemsList)
                    {
                        if (item.Author == filter)
                            TempFiltered.Add(item);
                    }
                    break;
                case "Publisher":
                    foreach (AbstractItem item in manager.ItemsList)
                    {
                        if (item.Publisher == filter)
                            TempFiltered.Add(item);
                    }
                    break;
                case "Genre":
                    foreach (AbstractItem item in manager.ItemsList)
                    {
                        if (item.GenrE.ToString() == filter)
                            TempFiltered.Add(item);
                    }
                    break;
            }
            for (int i = manager.ItemsList.Count - 1; i >= 0; i--)
            {
                AbstractItem item = manager.ItemsList[i];
                if (!TempFiltered.Contains(item))
                {
                    manager.filteredList.Remove(item);
                }
            }
            foreach (AbstractItem item in TempFiltered)
            {
                if (!manager.filteredList.Contains(item))
                {
                    manager.filteredList.Add(item);
                }
            }
        }
    }
}
