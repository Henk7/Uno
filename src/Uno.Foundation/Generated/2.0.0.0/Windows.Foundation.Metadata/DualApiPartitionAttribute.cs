#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Foundation.Metadata
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class DualApiPartitionAttribute : global::System.Attribute
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
		[global::Uno.NotImplemented]
		public DualApiPartitionAttribute() : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Foundation.Metadata.DualApiPartitionAttribute", "DualApiPartitionAttribute.DualApiPartitionAttribute()");
		}
		#endif
		// Forced skipping of method Windows.Foundation.Metadata.DualApiPartitionAttribute.DualApiPartitionAttribute()
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
		public  uint version;
		#endif
	}
}
