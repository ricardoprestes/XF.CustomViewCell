using System.ComponentModel;
using Android.Content;
using Android.Views;
using CustomViewCell;
using CustomViewCell.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyViewCell), typeof(MyViewCellRenderer))]
namespace CustomViewCell.Droid
{
    public class MyViewCellRenderer : ViewCellRenderer
    {
        protected Android.Views.View View { get; private set; }
        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);
            if (e.PropertyName == "IsSelected")
            {
                var isSelected = (sender as MyViewCell).IsSelected;
                View.SetBackgroundResource(isSelected ? Android.Resource.Color.HoloBlueLight : Android.Resource.Color.Transparent);
            }
        }

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            View = base.GetCellCore(item, convertView, parent, context);
            var cell = (MyViewCell)item;
            View.Visibility = ViewStates.Visible;
            return View;
        }
    }
}