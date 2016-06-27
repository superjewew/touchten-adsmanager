using UnityEngine;
using System.Collections;

public class AdsManager : MonoBehaviour {

	public static AdsManager instance;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
	
	void ShowBannerAd() {

	}

	void HideBannerAd() {

	}

	void CacheInterstitialAd() {

	}

	void ShowInterstitialAd() {

	}

	void CacheRewardedVideo() {

	}

	void ShowRewardedVideo() {

	}
}
