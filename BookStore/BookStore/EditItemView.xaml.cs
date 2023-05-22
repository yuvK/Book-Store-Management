using BookLib;
using StoreManager;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace BookStore
{
    public sealed partial class EditItemView : Page
    {
        BSManager manager;
        AbstractItem itemToEdit;
        public EditItemView()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPage.PageTitleTextBlock.Text = "Item Edit";

            Tuple<BSManager, AbstractItem> tuple = e.Parameter as Tuple<BSManager, AbstractItem>;//getting the selected item from main inventory view
            manager = tuple.Item1;
            itemToEdit = tuple.Item2;

            genreCbx.ItemsSource = Enum.GetValues(typeof(Genre)).Cast<Genre>();
        }
        private void UpdateItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                itemToEdit.Title = ExeptionHandler.ValidString(titleTbx.Text, "Title");
                itemToEdit.Author = ExeptionHandler.ValidString(authorTbx.Text, "Author");
                itemToEdit.Edition = ExeptionHandler.ValidInt(editionTbx.Text, "Edition");
                itemToEdit.GenrE = (Genre)genreCbx.SelectedItem;
                itemToEdit.Price = ExeptionHandler.ValidDouble(priceTbx.Text, "Price");
                itemToEdit.ISBN = ExeptionHandler.ValidLong(isbnTbx.Text, "ISBN");
                itemToEdit.Publisher = ExeptionHandler.ValidString(publisherTbx.Text, "Publisher");
                itemToEdit.PublishDate = ExeptionHandler.ValidDate(publishDateDp.Date.DateTime, "Publish Date");
                itemToEdit.Copies = ExeptionHandler.ValidInt(copiesTbx.Text, "Copies");
                itemToEdit.ImagePath = ExeptionHandler.ValidString(imagePathTbx.Text, "Image Path");
                itemToEdit.Description = ExeptionHandler.ValidString(descriptionTbx.Text, "Description");

                screenTbl.Text = "Item Updated";
            }
            catch (InvalidInputExeption er)
            {
                screenTbl.Text = $"{er.Message} {er.FailedProp}";
            }
            MainPage.MainPageFrame?.Navigate(typeof(InventoryViewPage), manager);
            MainPage.PageTitleTextBlock.Text = "Inventory";
        }
    }
}
