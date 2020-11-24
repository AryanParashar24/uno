﻿#nullable enable
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Uno;

namespace Windows.UI.Xaml.Media.Imaging
{
	public partial class SvgImageSource : ImageSource
	{
		private SvgImageSourceLoadStatus? _lastStatus;

		public Uri UriSource
		{
			get => (Uri)GetValue(UriSourceProperty);
			set => SetValue(UriSourceProperty, value);
		}

		public static DependencyProperty UriSourceProperty { get; } =
			DependencyProperty.Register(
				nameof(UriSource), typeof(Uri),
				typeof(SvgImageSource),
				new FrameworkPropertyMetadata(default(Uri), (s, e) => (s as SvgImageSource)?.OnUriSourceChanged(e)));

		private void OnUriSourceChanged(DependencyPropertyChangedEventArgs e)
		{
			if (!object.Equals(e.OldValue, e.NewValue))
			{
				UnloadImageData();
			}
			InitFromUri(e.NewValue as Uri);
#if NETSTANDARD
			InvalidateSource();
#endif
		}

		public SvgImageSource()
		{
			InitPartial();
		}

		public SvgImageSource(Uri uriSource)
		{
			UriSource = uriSource;

			InitPartial();
		}

		internal async Task<SvgImageSourceLoadStatus> SetSourceAsync(Stream streamSource)
		{
			if (streamSource == null)
			{
				//Same behavior as windows, although the documentation does not mention it!!!
				throw new ArgumentException(nameof(streamSource));
			}

			var copy = new MemoryStream();
			await streamSource.CopyToAsync(copy);
			copy.Position = 0;
			Stream = copy;

			_lastStatus = null;

#if NETSTANDARD
			await RequestOpen();
#else
			// TODO: assign _lastStatus somewhere
#endif
			return _lastStatus ?? SvgImageSourceLoadStatus.Other;
		}

		public void SetSource(IRandomAccessStream streamSource)
			// We prefer to use the SetSourceAsync here in order to make sure that the stream is copied ASYNChronously,
			// which is important since we are using a stream wrapper of and <In|Out|RA>Stream which might freeze the UI thread / throw exception.
			=> Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => SetSourceAsync(streamSource.GetInputStreamAt(0).AsStreamForRead()));

		public IAsyncOperation<SvgImageSourceLoadStatus> SetSourceAsync(IRandomAccessStream streamSource) =>
			AsyncOperation<SvgImageSourceLoadStatus>.FromTask((ct, _) => SetSourceAsync(streamSource.GetInputStreamAt(0).AsStreamForRead()));

		partial void InitPartial();

		private void RaiseImageFailed(SvgImageSourceLoadStatus loadStatus)
		{
			_lastStatus = loadStatus;
			OpenFailed?.Invoke(this, new SvgImageSourceFailedEventArgs(loadStatus));
		}

		private void RaiseImageOpened()
		{
			_lastStatus = SvgImageSourceLoadStatus.Success;
			Opened?.Invoke(this, new SvgImageSourceOpenedEventArgs());
		}

#pragma warning disable 67
		public event TypedEventHandler<SvgImageSource, SvgImageSourceFailedEventArgs>? OpenFailed;

		public event TypedEventHandler<SvgImageSource, SvgImageSourceOpenedEventArgs>? Opened;
#pragma warning restore 67
	}
}
