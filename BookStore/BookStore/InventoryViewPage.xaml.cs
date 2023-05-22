using BookLib;
using StoreManager;
using System;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookStore
{
    public sealed partial class InventoryViewPage : Page
    {

        BSManager manager;
        int selectedFilter;
        AbstractItem selectedItem;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            manager = e.Parameter as BSManager;

            ExtraDetailsView.Visibility = Visibility.Collapsed;
            MainPage.BoxItem.IsSelected = true;

            FilterTypeCbx.ItemsSource = Enum.GetValues(typeof(FilterBy)).Cast<FilterBy>().ToList();
            FilterOptionCbx.Visibility = Visibility.Collapsed;
        }
        public InventoryViewPage()
        {
            this.InitializeComponent();
        }
        public static string PriceAfterDiscountView(AbstractItem item)
        {
            if (item.OnSale == true)
            {
                return $"${item.PriceAfterDiscount}";
            }
            else
                return null;
        }
        private void MasterGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selectedItem = (AbstractItem)e.ClickedItem;
            SelectedItemTitleTbl.Text = selectedItem.Title;
            SelectedItemAuthorTbl.Text = selectedItem.Author;
            SelectedItemImg.Source = selectedItem.ItemImage;
            SelectedItemPublisherTbl.Text = selectedItem.Publisher;
            SelectedItemEditionTbl.Text = selectedItem.Edition.ToString();
            SelectedItemPriceTbl.Text = $"{selectedItem.Price}$";
            SelectedItemPublishDateTbl.Text = $"{selectedItem.PublishDate:d}";
            SelectedItemISBNTbl.Text = selectedItem.ISBN.ToString();
            SelectedItemDescriptionTbl.Text = selectedItem.Description;
            SelectedItemCopiesTbl.Text = selectedItem.Copies.ToString();

            ExtraDetailsView.Visibility = Visibility.Visible;
            manager.ItemToEdit = selectedItem;
        }
        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditItemView), new Tuple<BSManager, AbstractItem>(manager, selectedItem), new SuppressNavigationTransitionInfo());
        }
        private async void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            AbstractItem a = MasterGridView.SelectedItem as AbstractItem;

            string title = $"Delete {a.Title}?";
            string content = $"Are you sure you want to delete {a.Title} from Inventory?";

            UICommand yesCommand = new UICommand("Yes");
            UICommand noCommand = new UICommand("No");

            MessageDialog dialog = new MessageDialog(content, title);
            dialog.Options = MessageDialogOptions.None;
            dialog.Commands.Add(yesCommand);

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;

            if (noCommand != null)
            {
                dialog.Commands.Add(noCommand);
                dialog.CancelCommandIndex = (uint)dialog.Commands.Count - 1;
            }

            IUICommand command = await dialog.ShowAsync();

            if (command == yesCommand)
            {
                manager.DeleteItem(a);
                ExtraDetailsView.Visibility = Visibility.Collapsed;
            }
            else if (command == noCommand)
            {
                return;
            }
            else
            {
                return;
            }
        }
        private void SearchTbx_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            manager.filterManager.SearchList(selectedFilter, SearchTbx.Text);
        }
        private void FilterTypeCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (FilterTypeCbx.SelectedItem.ToString())
            {
                case "All":
                    manager.filterManager.FilterList("Undifined");
                    FilterOptionCbx.Visibility = Visibility.Collapsed;
                    FilterOptionCbx.SelectedItem = null;
                    break;
                case "Title":
                    FilterOptionCbx.ItemsSource = manager.GetInventoryByTitle();
                    FilterOptionCbx.Visibility = Visibility.Visible;
                    break;
                case "Author":
                    FilterOptionCbx.ItemsSource = manager.GetInventoryByAuthor();
                    FilterOptionCbx.Visibility = Visibility.Visible;
                    break;
                case "Genre":
                    FilterOptionCbx.ItemsSource = Enum.GetValues(typeof(Genre)).Cast<Genre>();
                    FilterOptionCbx.Visibility = Visibility.Visible;
                    break;
                case "Publisher":
                    FilterOptionCbx.ItemsSource = manager.GetInventoryByPublisher();
                    FilterOptionCbx.Visibility = Visibility.Visible;
                    break;
                case "Books":
                    manager.filterManager.FilterList("Books");
                    FilterOptionCbx.Visibility = Visibility.Collapsed;
                    FilterOptionCbx.SelectedItem = null;
                    break;
                case "Journals":
                    manager.filterManager.FilterList("Journals");
                    FilterOptionCbx.Visibility = Visibility.Collapsed;
                    FilterOptionCbx.SelectedItem = null;
                    break;
                case "On_Sale":
                    manager.filterManager.FilterList("OnSale");
                    FilterOptionCbx.Visibility = Visibility.Collapsed;
                    FilterOptionCbx.SelectedItem = null;
                    break;
                default:
                    break;
            }
        }
        private void FilterOptionCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterOptionCbx.SelectedItem != null)
            {
                string filterType = FilterTypeCbx.SelectedItem.ToString();
                string filter = FilterOptionCbx.SelectedItem.ToString();
                manager.filterManager.FilterListByName(filterType, filter);
            }
        }
        private async void SellItem_Click(object sender, RoutedEventArgs e)
        {
            AbstractItem a = MasterGridView.SelectedItem as AbstractItem;

            string title = $"Sell {a.Title}?";
            string content = $"Are you sure you want to sell {a.Title}?";

            UICommand yesCommand = new UICommand("Yes");
            UICommand noCommand = new UICommand("No");

            MessageDialog dialog = new MessageDialog(content, title);
            dialog.Options = MessageDialogOptions.None;
            dialog.Commands.Add(yesCommand);

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;

            if (noCommand != null)
            {
                dialog.Commands.Add(noCommand);
                dialog.CancelCommandIndex = (uint)dialog.Commands.Count - 1;
            }

            var command = await dialog.ShowAsync();

            if (command == yesCommand)
            {
                if (a.Copies <= 0)
                {
                    msgTbl.Text = $"Item {a.Title} is out of stock";
                }
                else
                {
                    manager.purchaseManager.SellItem(a);
                }
            }
            else if (command == noCommand)
            {
                return;
            }
            else
            {
                return;
            }
        }
    }
}