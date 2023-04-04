﻿#nullable enable

using Windows.UI.Xaml;

namespace Uno.UI.Media;

internal class HtmlVideo : UIElement
{
	public HtmlVideo() : base("video")
	{
		SetAttribute("background-color", "transparent");
		SetStyle("width", "100%");
		SetStyle("height", "100%");
	}

	internal void SetAnonymousCORS(bool enable)
	{
		if (enable)
		{
			SetAttribute("crossorigin", "anonymous");
		}
		else
		{
			if (string.IsNullOrEmpty(GetAttribute("controls")))
			{
				RemoveAttribute("controls");
			}
		}
	}
}
