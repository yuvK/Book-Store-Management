using StoreManager;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace BookStore
{
    public sealed partial class MainPage : Page
    {
        public BSManager manager = new BSManager();
        public static Frame MainPageFrame;
        public static ListBoxItem BoxItem;
        public static TextBlock PageTitleTextBlock;
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(1280, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            IconsListBox.SelectedItem = HomeBoxItem;

            MainPageFrame = MainFrame;
            BoxItem = ViewAllListBoxItem;
            PageTitleTextBlock = PageTitleTbl;

            MainFrame.Navigate(typeof(WelcomePageView));
            PageTitleTbl.Text = "Welcome";
        }
        private void HamburgerBtn_Click(object sender, RoutedEventArgs e)
        {
            MainSplitView.IsPaneOpen = !MainSplitView.IsPaneOpen;
        }
        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(WelcomePageView));
                PageTitleTbl.Text = "Welcome";
                IconsListBox.SelectedItem = HomeBoxItem;
            }
            else if (LoadListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(InventoryViewPage), manager);
                manager.LoadFile();
            }
            else if (SaveListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(InventoryViewPage), manager);
                manager.SaveFile();
            }
            else if (ViewAllListBoxItem.IsSelected)
            {
                MainFrame.Navigate(typeof(InventoryViewPage), manager);
                PageTitleTbl.Text = "Inventory";
            }
            else if (AddItemListBoxItem.IsSelected)
            {
                PageTitleTbl.Text = "Add Item";
                MainFrame.Navigate(typeof(AddBookView), manager);
            }
            else if (AddDiscountListBoxItem.IsSelected)
            {
                PageTitleTbl.Text = "Add Discount/Sale";
                MainFrame.Navigate(typeof(AddDiscountView), manager);
            }
            else if (ViewReportsListBoxItem.IsSelected)
            {
                PageTitleTbl.Text = "Reports";
                MainFrame.Navigate(typeof(ReportsView), manager);
            }
        }
    }
}
