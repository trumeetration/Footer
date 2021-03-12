using Footer.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Footer.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}