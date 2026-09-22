using System.Collections.Generic;
namespace Facebook.Unity
{
	public delegate void InitDelegate();
	public delegate void HideUnityDelegate(bool isUnityShown);
	public static class FB
	{
		public static bool IsInitialized { get { return false; } }
		public static void Init(InitDelegate onInitComplete = null, HideUnityDelegate onHideUnity = null, string authResponse = null) { }
		public static void ActivateApp() { }
		public static void LogPurchase(float amount, string currency = null, Dictionary<string, object> parameters = null) { }
	}
}
