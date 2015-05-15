using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Widget;
using Android.App;
using Android.Views;

[assembly: Xamarin.Forms.ExportRenderer(typeof(App1.CustomVisualElement.MyEntry),    typeof(App1.Droid.CustomVisualElementRenderer.MyEntryRenderer))]
[assembly: Xamarin.Forms.ExportRenderer(typeof(App1.CustomVisualElement.MyAMapPage), typeof(App1.Droid.CustomVisualElementRenderer.MyAMapPageRenderer))]

namespace App1.Droid.CustomVisualElementRenderer
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var nativeControl = (EditText)Control;
                nativeControl.Background = null;
            }
        }
    }

    public class MyAMapPageRenderer : PageRenderer
    {
        App1.CustomVisualElement.MyAMapPage myAMapPage;
        Android.Widget.LinearLayout         layout1;
        Com.Amap.Api.Maps2d.MapView         mapView;
        Android.OS.Bundle                   bundle;
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            myAMapPage = e.NewElement as App1.CustomVisualElement.MyAMapPage;
            layout1 = new LinearLayout(this.Context);
            this.AddView(layout1);
            mapView = new Com.Amap.Api.Maps2d.MapView(this.Context)
            {
                LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
            };
            mapView.OnCreate(bundle);
            layout1.AddView(mapView);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            layout1.Measure(msw, msh);
            layout1.Layout(0, 0, r - l, b - t);
        }
    }
}