using Xamarin.Forms;

namespace CustomViewCell
{
    public class MyViewCell : ViewCell
    {
        public static BindableProperty IsSelectedProperty = BindableProperty.Create("IsSelected", typeof(bool), typeof(MyViewCell), false);

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

    }
}
