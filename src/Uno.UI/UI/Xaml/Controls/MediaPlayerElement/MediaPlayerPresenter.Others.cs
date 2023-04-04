#nullable enable

#if !__ANDROID__ && !__IOS__ && !__MACOS__
using System;
using Windows.Foundation;
using Windows.Media.Playback;
using Windows.UI.Xaml.Media;
using Uno.Media.Playback;
using Uno.Foundation.Extensibility;
using Uno.Foundation.Logging;

namespace Windows.UI.Xaml.Controls
{
	public partial class MediaPlayerPresenter : Border
	{
		private IMediaPlayerPresenterExtension? _extension;

		partial void InitializePartial()
		{
			Console.WriteLine($"MediaPlayerPresenter");

			if (!ApiExtensibility.CreateInstance<IMediaPlayerPresenterExtension>(this, out _extension))
			{
				if (this.Log().IsEnabled(LogLevel.Error))
				{
					this.Log().Error("Unable to create an instance of IMediaPlayerPresenterExtension. MediaPlayerPresenter will not work.");
				}
			}
		}

		partial void OnMediaPlayerChangedPartial(MediaPlayer mediaPlayer)
			=> _extension?.MediaPlayerChanged();

		private void OnStretchChanged(Stretch newValue, Stretch oldValue)
			=> _extension?.StretchChanged();

		internal void ApplyStretch()
			=> _extension?.StretchChanged();

		internal void RequestFullScreen()
			=> _extension?.RequestFullScreen();

		internal void ExitFullScreen()
			=> _extension?.ExitFullScreen();
	}
}
#endif
