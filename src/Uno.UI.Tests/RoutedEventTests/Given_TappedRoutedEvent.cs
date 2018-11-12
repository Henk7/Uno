using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Uno.UI.Tests.RoutedEventTests
{
	[TestClass]
	public class Given_TappedRoutedEvent
	{
		[TestMethod]
		public void When_SubscribingOnControlDirectly()
		{
			var events = new List<(object sender, TappedRoutedEventArgs args)>();

			var root = new Border();

			void OnTapped(object snd, TappedRoutedEventArgs evt) => events.Add((snd, evt));

			root.Tapped += OnTapped;

			// TODO: check native vs managed
			var evt1 = new TappedRoutedEventArgs();
			root.RaiseEvent(UIElement.TappedEvent, evt1);

			events.Should().HaveCount(1)
				.And.ContainSingle(x => x.sender == root && x.args == evt1);
		}

		[TestMethod]
		public void When_SubscribingUsingAddHandler()
		{
			var events = new List<(object sender, TappedRoutedEventArgs args)>();

			var root = new Border();

			void OnTapped(object snd, TappedRoutedEventArgs evt) => events.Add((snd, evt));

			root.AddHandler(UIElement.TappedEvent, (TappedEventHandler) OnTapped, false);

			var evt1 = new TappedRoutedEventArgs();
			root.RaiseEvent(UIElement.TappedEvent, evt1);

			events.Should().HaveCount(1)
				.And.ContainSingle(x => x.sender == root && x.args == evt1);
		}

		[TestMethod]
		public void When_SubscribingUsingAddHandler_And_EventRaisedChildControl()
		{
			var events = new List<(object sender, TappedRoutedEventArgs args)>();

			var child2 = new Border();
			var child1 = new Border
			{
				Child = child2
			};
			var root = new Border
			{
				Child = child1
			};

			void OnTapped(object snd, TappedRoutedEventArgs evt)
			{
				events.Add((snd, evt));
				evt.Handled = true;
			}

			root.AddHandler(UIElement.TappedEvent, (TappedEventHandler)OnTapped, false);
			child1.AddHandler(UIElement.TappedEvent, (TappedEventHandler)OnTapped, false);

			var evt1 = new TappedRoutedEventArgs();
			child2.RaiseEvent(UIElement.TappedEvent, evt1);

			events.Should().HaveCount(1)
				.And.ContainSingle(x => x.sender == root && x.args == evt1);
		}
	}
}
