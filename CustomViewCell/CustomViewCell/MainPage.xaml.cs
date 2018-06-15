using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomViewCell
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Item> Items { get; set; }
        public MainPage()
        {
            InitializeComponent();
            listView.ItemTapped += ListView_ItemTapped;
            Items = new ObservableCollection<Item>();
            Items.Add(new Item { Name = "Item 1", IsSelected = false });
            Items.Add(new Item { Name = "Item 2", IsSelected = false });
            Items.Add(new Item { Name = "Item 3", IsSelected = false });
            Items.Add(new Item { Name = "Item 4", IsSelected = false });
            Items.Add(new Item { Name = "Item 5", IsSelected = false });
            listView.ItemsSource = Items;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            listView.SelectedItem = null;
            var item = e.Item as Item;
            item.IsSelected = !item.IsSelected;
        }
    }

    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }
}
