using BookLib;
using StoreManager;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace BookStore
{
    public sealed partial class AddDiscountView : Page
    {
        BSManager manager;
        public AddDiscountView()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            manager = e.Parameter as BSManager;
            DiscountTypeCbx.ItemsSource = Enum.GetValues(typeof(DiscountBy)).Cast<DiscountBy>();

            if (manager.DiscountList.Count == 0)
                DiscountsListView.Visibility = Visibility.Collapsed;
            else
                DiscountsListView.Visibility = Visibility.Visible;
        }
        private void AddDiscountBtn_Click(object sender, RoutedEventArgs e)
        {
            int discountPrecentage = int.Parse(DiscountPrecentageTbx.Text);
            if (DiscountTypeCbx.SelectedItem == null || DiscountOptionCbx.SelectedItem == null || DiscountPrecentageTbx.Text == "")
            {
                screenTbl.Text = "Please select all options";
            }
            else if (discountPrecentage < 1 || discountPrecentage > 100)
            {
                screenTbl.Text = "Precentage is out of range";
                DiscountPrecentageTbx.Text = "";
            }
            else
            {
                Discount d = new Discount(
                    (DiscountBy)Enum.Parse(typeof(DiscountBy), 
                    DiscountTypeCbx.SelectedItem.ToString()),
                    DiscountOptionCbx.SelectedItem.ToString(),
                    int.Parse(DiscountPrecentageTbx.Text));

                manager.discountManager.AddDiscount(d);
                screenTbl.Text = "Discount Added";
                DiscountsListView.Visibility = Visibility.Visible;
            }
        }
        private void DiscountTypeCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string select = DiscountTypeCbx.SelectedItem.ToString();
            switch (select)
            {
                case "Title":
                    DiscountOptionCbx.ItemsSource = manager.GetInventoryByTitle();
                    break;
                case "Author":
                    DiscountOptionCbx.ItemsSource = manager.GetInventoryByAuthor();
                    break;
                case "Genre":
                    DiscountOptionCbx.ItemsSource = Enum.GetValues(typeof(Genre)).Cast<Genre>();
                    break;
                case "Publisher":
                    DiscountOptionCbx.ItemsSource = manager.GetInventoryByPublisher();
                    break;
                default:
                    break;
            }
        }
        private void DiscountDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Discount selectedDiscount = (Discount)DiscountsListView.SelectedItem;
            manager.discountManager.DeleteDiscount(selectedDiscount);
        }
        private void DiscountSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            manager.SaveDiscountsList();
        }
    }
}

