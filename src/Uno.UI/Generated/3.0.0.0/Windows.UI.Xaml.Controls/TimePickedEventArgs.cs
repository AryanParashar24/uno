#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Controls
{
	#if false || false || false || false || false || false || false
	[global::Uno.NotImplemented]
	#endif
	public  partial class TimePickedEventArgs : global::Windows.UI.Xaml.DependencyObject
	{
<<<<<<< HEAD
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.TimeSpan NewTime
		{
			get
			{
				throw new global::System.NotImplementedException("The member TimeSpan TimePickedEventArgs.NewTime is not implemented in Uno.");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.TimeSpan OldTime
		{
			get
			{
				throw new global::System.NotImplementedException("The member TimeSpan TimePickedEventArgs.OldTime is not implemented in Uno.");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || false || false || false || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__MACOS__")]
		public TimePickedEventArgs() : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TimePickedEventArgs", "TimePickedEventArgs.TimePickedEventArgs()");
		}
		#endif
=======
		// Skipping already declared property NewTime
		// Skipping already declared property OldTime
		// Skipping already declared method Windows.UI.Xaml.Controls.TimePickedEventArgs.TimePickedEventArgs()
>>>>>>> 1563a5b8f1 (feat!: Implement TimePicker's SelectedTime/TimeChanged/SelectedTimeChanged)
		// Forced skipping of method Windows.UI.Xaml.Controls.TimePickedEventArgs.TimePickedEventArgs()
		// Forced skipping of method Windows.UI.Xaml.Controls.TimePickedEventArgs.OldTime.get
		// Forced skipping of method Windows.UI.Xaml.Controls.TimePickedEventArgs.NewTime.get
	}
}
