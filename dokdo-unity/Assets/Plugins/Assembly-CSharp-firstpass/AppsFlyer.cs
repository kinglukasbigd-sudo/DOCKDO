using System.Collections.Generic;
using UnityEngine;
public class AppsFlyer : MonoBehaviour
{
	public static void trackEvent(string eventName, string eventValue) {  }
	public static void setCurrencyCode(string currencyCode) {  }
	public static void setCustomerUserID(string customerUserID) {  }
	public static void loadConversionData(string callbackObject) {  }
	public static void loadConversionData(string callbackObject, string callbackMethod, string callbackFailedMethod) {  }
	public static void setCollectIMEI(bool shouldCollect) {  }
	public static void setCollectAndroidID(bool shouldCollect) {  }
	public static void init(string key, string callbackObject) {  }
	public static void init(string key) {  }
	public static void setAppsFlyerKey(string key) {  }
	public static void trackAppLaunch() {  }
	public static void setAppID(string packageName) {  }
	public static void createValidateInAppListener(string aObject, string callbackMethod, string callbackFailedMethod) {  }
	public static void validateReceipt(string publicKey, string purchaseData, string signature, string price, string currency, Dictionary<string, string> extraParams) {  }
	public static void trackRichEvent(string eventName, Dictionary<string, string> eventValues) {  }
	public static void setImeiData(string imeiData) {  }
	public static void setAndroidIdData(string androidIdData) {  }
	public static void setIsDebug(bool isDebug) {  }
	public static void setIsSandbox(bool isSandbox) {  }
	public static void getConversionData() {  }
	public static void handleOpenUrl(string url, string sourceApplication, string annotation) {  }
	public static string getAppsFlyerId() { return default(string); }
	public static void setGCMProjectNumber(string googleGCMNumber) {  }
	public static void updateServerUninstallToken(string token) {  }
	public static void enableUninstallTracking(string senderId) {  }
}
