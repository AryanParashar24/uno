﻿// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

using Windows.UI.Xaml.Controls;

namespace FrameworkPoolEditorRecycling.Editors;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class EditorXBindView : Page
{
	public EditorViewModel ViewModel { get; private set; }

	public EditorXBindView()
	{
		this.InitializeComponent();
		this.DataContextChanged += EditorXBindView_DataContextChanged;
	}

	private void EditorXBindView_DataContextChanged(Windows.UI.Xaml.FrameworkElement sender, Windows.UI.Xaml.DataContextChangedEventArgs args)
	{
		if (DataContext is EditorViewModel editor)
		{
			ViewModel = editor;
			Bindings.Update();
		}
	}
}
