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
	VungleAd vungleAd;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	public void Init() {
		googleAd = new GoogleBannerAd ();
		chartAd = new ChartboostAd ();
		vungleAd = new VungleAd (consoleText);
		consoleText.text += "Initialized = true\n";
	}
	
	public void ShowBannerAd() {
		googleAd.ShowBannerAd ();
		consoleText.text += "Showing Banner Ad\n";
	}

	public void HideBannerAd() {
		googleAd.HideBannerAd ();
		consoleText.text += "Hiding Banner Ad\n";
	}

	public void CacheInterstitialAd() {
		chartAd.CacheInterstitialAd ();
		consoleText.text += "Caching Interstitial Ad\n";
	}

	public void ShowInterstitialAd() {
		chartAd.ShowInterstitialAd ();
		consoleText.text += "Showing Interstitial Ad\n";
	}

	public void CacheRewardedVideo() {

	}

	public void ShowRewardedVideo() {
		if (Vungle.isAdvertAvailable ()) {
			Vungle.playAd ();
			consoleText.text += "Playing Rewarded Video Ad\n";
		}
	}

	class GoogleBannerAd {

		BannerView bannerView;
		string adUnitId;

		public GoogleBannerAd() {
			#if UNITY_ANDROID
			adUnitId = "ca-app-pub-3940256099942544/6300978111";
			#elif UNITY_IPHONE
			string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
			#else
			string adUnitId = "unexpected_platform";
			#endif
		}

		public void RequestBanner() {
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

	class VungleAd {

		public VungleAd(Text consoleText) {


			Vungle.init ("577947f3bc8623f86800006c", "", "");

			Vungle.adPlayableEvent += (adPlayable) => {
				consoleText.text += "Ad's playable state has been changed! Now: " + adPlayable + "\n";
			};
		}
	}
}
