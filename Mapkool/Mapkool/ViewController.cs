using System;

using UIKit;
using CoreGraphics;
using Foundation;
using CoreLocation;

using Google.Maps;

namespace Mapkool
{
	public partial class ViewController : UIViewController
	{

		MapView mapView;
	//	bool firstLocationUpdate;


		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			CLLocationManager locationManager = new CLLocationManager();
			locationManager.RequestWhenInUseAuthorization();

			// Perform any additional setup after loading the view, typically from a nib.
			var camera = CameraPosition.FromCamera(-33.868, 151.2086, 12);
			mapView = MapView.FromCamera(CGRect.Empty, camera);
			mapView.Settings.CompassButton = true;
			mapView.Settings.MyLocationButton = true;
			mapView.MyLocationEnabled = true;

			Console.WriteLine("my location:");
			Console.WriteLine(locationManager.Location.Coordinate.Latitude);
			// Listen to the myLocation property of GMSMapView.
			//mapView.AddObserver(this, new NSString("myLocation"), NSKeyValueObservingOptions.New, IntPtr.Zero);

			View = mapView;

		}

		/*
		public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
		{
			//base.ObserveValue (keyPath, ofObject, change, context);

			if (!firstLocationUpdate)
			{
				// If the first location update has not yet been recieved, then jump to that
				// location.
				firstLocationUpdate = true;
				var location = change.ObjectForKey(NSValue.ChangeNewKey) as CLLocation;
				mapView.Camera = CameraPosition.FromCamera(location.Coordinate, 14);
			}
		}
		*/
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}


	}
}
