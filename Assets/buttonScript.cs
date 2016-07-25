using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class buttonScript : MonoBehaviour {

	bool rewardBasedEventHandlersSet = false;

	// Use this for initialization
	void Start () {

		RewardBasedVideoAd rewardBasedVideo = RewardBasedVideoAd.Instance;
		if (!rewardBasedEventHandlersSet)
		{
			// Ad event fired when the rewarded video ad
			// has been received.
//			rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
//			// has failed to load.
//			rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
//			// is opened.
//			rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
//			// has started playing.
//			rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
//			// is closed.
//			rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
//			// is leaving the application.
//			rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
			// has rewarded the user.
			rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;

			rewardBasedEventHandlersSet = true;
		}

		RequestRewardBasedVideo ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showAd() {
		print("===showAd ==");
		RewardBasedVideoAd rewardBasedVideo = RewardBasedVideoAd.Instance;
		rewardBasedVideo.Show();
	}

//	public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
//	{
//		print("====== HandleRewardBasedVideoLoaded ======" );
//	}
//
//	public void HandleRewardBasedVideoFailedToLoad(object sender, Reward args)
//	{
//		print("====== HandleRewardBasedVideoFailedToLoad ======" );
//	}
//
//	public void HandleRewardBasedVideoOpened(object sender, Reward args)
//	{
//		print("====== HandleRewardBasedVideoOpened ======" );
//	}
//
//	public void HandleRewardBasedVideoStarted(object sender, Reward args)
//	{
//		print("====== HandleRewardBasedVideoStarted ======" );
//	}
//
//	public void HandleRewardBasedVideoClosed(object sender, Reward args)
//	{
//		print("====== HandleRewardBasedVideoClosed ======" );
//	}
//
//	public void HandleRewardBasedVideoLeftApplication(object sender, Reward args)
//	{
//		print("====== HandleRewardBasedVideoLeftApplication ======" );
//	}
//
	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
		string type = args.Type;
		double amount = args.Amount;
		print("===User rewarded with: " + amount.ToString() + " " + type);
	}

	private void RequestRewardBasedVideo()
	{

		print("===request ==");
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "INSERT_AD_UNIT_HERE";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-4891026035420920/4599988296";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		RewardBasedVideoAd rewardBasedVideo = RewardBasedVideoAd.Instance;

		AdRequest request = new AdRequest.Builder().Build();
		rewardBasedVideo.LoadAd(request, adUnitId);
	}

}
