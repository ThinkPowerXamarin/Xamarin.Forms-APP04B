using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;

[assembly: Xamarin.Forms.ExportRenderer(typeof(App1.CustomVisualElement.MyEntry), typeof(App1.iOS.CustomVisualElementRenderer.MyEntryRenderer))]

namespace App1.iOS.CustomVisualElementRenderer
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var nativeControl = (UITextField)Control;
                nativeControl.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}