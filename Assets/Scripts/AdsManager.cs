using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GoogleMobileAds.Api;
using ChartboostSDK;

public class AdsManager : MonoBehaviour {

	public Text consoleText;

	public static AdsManager instance;

	GoogleBannerAd googleAd;
	ChartboostAd chartAd;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);

		googleAd = new GoogleBannerAd ();
		chartAd = new ChartboostAd ();
	}
	
	public void ShowBannerAd() {
		googleAd.ShowBannerAd ();
	}

	public void HideBannerAd() {
		googleAd.HideBannerAd ();
	}

	public void CacheInterstitialAd() {
		chartAd.CacheInterstitialAd ();
	}

	public void ShowInterstitialAd() {
		chartAd.ShowInterstitialAd ();
	}

	void CacheRewardedVideo() {

	}

	void ShowRewardedVideo() {

	}

	class GoogleBannerAd {

		BannerView bannerView;

		public void RequestBanner() {
			#if UNITY_ANDROID
			string adUnitId = "ca-app-pub-3940256099942544/6300978111";
			#elif UNITY_IPHONE
			string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
			#else
			string adUnitId = "unexpected_platform";
			#endif

			// Create a 320x50 banner at the top of the screen.
			bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
			// Create an empty ad request.
			AdRequest request = new AdRequest.Builder().Build();
			// Load the banner with the request.
			bannerView.LoadAd(request);
		}

		public void ShowBannerAd() {
			RequestBanner ();
			bannerView.Show ();
		}

		public void HideBannerAd() {
			bannerView.Hide ();
		}
	}

	class ChartboostAd {
		public void CacheInterstitialAd() {
			Chartboost.cacheInterstitial(CBLocation.HomeScreen);
		}

		public void ShowInterstitialAd() {
			if (Chartboost.hasInterstitial (CBLocation.HomeScreen)) {
				Chartboost.showInterstitial (CBLocation.HomeScreen);
			} else {
				Debug.Log ("Ad not cached, not showing"); 
			}
		}
	}
}
