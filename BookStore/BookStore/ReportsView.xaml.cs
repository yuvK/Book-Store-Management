using BookLib;
using StoreManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace BookStore
{
    public sealed partial class ReportsView : Page
    {
        BSManager manager;

        ObservableCollection<Sale> tempList = new ObservableCollection<Sale>();
        public ReportsView()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            manager = e.Parameter as BSManager;
            if (manager.purchaseManager.PurchasesHistory != null)
            {
                foreach (Sale item in manager.purchaseManager.PastPurchases)
                {
                    tempList.Add(item);
                }
            }
            startDate.MaxYear = DateTimeOffset.Now;
            endDate.MaxYear = DateTimeOffset.Now;
            startDate.SelectedDate = DateTimeOffset.Now;
            endDate.SelectedDate = DateTimeOffset.Now;
        }
        private void startDate_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            FilterPurchesesListByDate(startDate.Date.DateTime, endDate.Date.DateTime);
        }
        private void endDate_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            FilterPurchesesListByDate(startDate.Date.DateTime, endDate.Date.DateTime);
        }
        private void PrintListBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Sale> collection = new List<Sale>(tempList);
            manager.purchaseManager.SaveReport(collection);
        }
        private void FilterByPublisher_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            PublisherSuggestionOutput.Text = args.SelectedItem.ToString();
        }
        private void FilterByPublisher_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

            if (sender.Text == "")
            {
                foreach (Sale item in manager.purchaseManager.PastPurchases)
                {
                    if (!tempList.Contains(item))
                        tempList.Add(item);
                }
            }
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suitableItems = new List<string>();
                var splitText = sender.Text.ToLower().Split(" ");
                foreach (Sale item in manager.purchaseManager.PastPurchases)
                {
                    var found = splitText.All((string key) =>
                    {
                        return item.Publisher.ToLower().Contains(key);
                    });
                    if (found)
                    {
                        suitableItems.Add(item.Publisher);
                    }
                }
                if (suitableItems.Count == 0)
                {
                    suitableItems.Add("No Result Found");
                }
                sender.ItemsSource = suitableItems;
            }
        }
        private void FilterByPublisher_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                foreach (Sale item in manager.purchaseManager.PastPurchases)
                {
                    if (item.Publisher != PublisherSuggestionOutput.Text)
                    {
                        tempList.Remove(item);
                    }
                }
            }
        }
        private void FilterByAuthor_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            AuthorSuggestionOutput.Text = args.SelectedItem.ToString();
        }
        private void FilterByAuthor_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (sender.Text == "")
            {
                foreach (Sale item in manager.purchaseManager.PastPurchases)
                {
                    if (!tempList.Contains(item))
                        tempList.Add(item);
                }
            }
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suitableItems = new List<string>();
                var splitText = sender.Text.ToLower().Split(" ");
                foreach (Sale item in manager.purchaseManager.PastPurchases)
                {
                    var found = splitText.All((string key) =>
                    {
                        return item.Author.ToLower().Contains(key);
                    });
                    if (found)
                    {
                        suitableItems.Add(item.Author);
                    }
                }
                if (suitableItems.Count == 0)
                {
                    suitableItems.Add("No Result Found");
                }
                sender.ItemsSource = suitableItems;
            }
        }
        private void FilterByAuthor_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                foreach (Sale item in manager.purchaseManager.PastPurchases)
                {
                    if (item.Author != AuthorSuggestionOutput.Text)
                    {
                        tempList.Remove(item);
                    }
                }
            }
        }
        private void FilterByTite_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            TitleSuggestionOutput.Text = args.SelectedItem.ToString();
        }
        private void FilterByTite_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (sender.Text == "")
            {
                foreach (Sale item in manager.purchaseManager.PastPurchases)
                {
                    if (!tempList.Contains(item))
                        tempList.Add(item);
                }
            }
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suitableItems = new List<string>();
                var splitText = sender.Text.ToLower().Split(" ");
                foreach (Sale item in manager.purchaseManager.PastPurchases)
                {
                    var found = splitText.All((string key) =>
                    {
                        return item.Title.ToLower().Contains(key);
                    });
                    if (found)
                    {
                        suitableItems.Add(item.Title);
                    }
                }
                if (suitableItems.Count == 0)
                {
                    suitableItems.Add("No Result Found");
                }
                sender.ItemsSource = suitableItems;
            }
        }
        private void FilterByTite_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                foreach (Sale item in manager.purchaseManager.PastPurchases)
                {
                    if (item.Title != TitleSuggestionOutput.Text)
                    {
                        tempList.Remove(item);
                    }
                }
            }
        }
        public void FilterPurchesesListByDate(DateTime startDate, DateTime endDate)
        {
            tempList.Clear();
            foreach (Sale sale in manager.purchaseManager.PastPurchases)
            {
                int res1 = DateTime.Compare(sale.SaleTime, startDate);
                int res2 = DateTime.Compare(sale.SaleTime, endDate);

                if (res1 > 0 && res2 < 0)
                    tempList.Add(sale);
            }
        }
    }
}
