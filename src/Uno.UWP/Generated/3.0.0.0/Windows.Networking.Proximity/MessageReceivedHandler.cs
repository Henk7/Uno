#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Networking.Proximity
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
	public delegate void MessageReceivedHandler(global::Windows.Networking.Proximity.ProximityDevice @sender, global::Windows.Networking.Proximity.ProximityMessage @message);
	#endif
}
