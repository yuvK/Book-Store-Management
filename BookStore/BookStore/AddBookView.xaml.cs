using BookLib;
using StoreManager;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace BookStore
{
    public sealed partial class AddBookView : Page
    {
        BSManager manager;
        public AddBookView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            manager = e.Parameter as BSManager;
            genreCbx.ItemsSource = Enum.GetValues(typeof(Genre)).Cast<Genre>();
            publishDateDp.MaxYear = DateTimeOffset.Now;
        }
        private void SaveBookBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TypeCbx.SelectedItem == null)
                screenTbl.Text = "Please Choose type of item to add";
            else
            {
                if (TypeCbx.SelectedItem.ToString() == "Book")
                {
                    try
                    {
                        Book b = new Book(
                              ExeptionHandler.ValidString(titleTbx.Text, "Title"),
                              ExeptionHandler.ValidString(authorTbx.Text, "Author"),
                              ExeptionHandler.ValidInt(editionTbx.Text, "Edition"),
                              (Genre)genreCbx.SelectedItem,
                              ExeptionHandler.ValidDouble(priceTbx.Text, "Price"),
                              ExeptionHandler.ValidLong(isbnTbx.Text, "ISBN"),
                              ExeptionHandler.ValidString(publisherTbx.Text, "Publisher"),
                              ExeptionHandler.ValidDate(publishDateDp.Date.DateTime, "Publish Date"),
                              ExeptionHandler.ValidInt(copiesTbx.Text, "Copies"),
                              imagePathTbx.Text,
                              ExeptionHandler.ValidString(descriptionTbx.Text, "Description"));;;

                        manager.AddItem(b);
                        screenTbl.Text = "Book Added To Inventory";
                    }
                    catch (InvalidInputExeption er)
                    {
                        screenTbl.Text = $"{er.Message} {er.FailedProp}";
                    }
                }
                else if (TypeCbx.SelectedItem.ToString() == "Journal")
                {
                    try
                    {
                        Journal j = new Journal(
                              ExeptionHandler.ValidString(titleTbx.Text, "Title"),
                              ExeptionHandler.ValidString(authorTbx.Text, "Author"),
                              ExeptionHandler.ValidInt(editionTbx.Text, "Edition"),
                              (Genre)genreCbx.SelectedItem,
                              ExeptionHandler.ValidDouble(priceTbx.Text, "Price"),
                              ExeptionHandler.ValidLong(isbnTbx.Text, "ISBN"),
                              ExeptionHandler.ValidString(publisherTbx.Text, "Publisher"),
                              ExeptionHandler.ValidDate(publishDateDp.Date.DateTime, "Publish Date"),
                              ExeptionHandler.ValidInt(copiesTbx.Text, "Copies"),
                              imagePathTbx.Text,
                              ExeptionHandler.ValidString(descriptionTbx.Text, "Description"));

                        manager.AddItem(j);
                        screenTbl.Text = "Journal Added To Inventory";
                    }
                    catch (InvalidInputExeption er)
                    {
                        screenTbl.Text = $"{er.Message} {er.FailedProp}";
                    }
                }
            }
        }
    }
}
