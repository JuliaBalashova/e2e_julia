using System;
using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class Main : MonoBehaviour {
	
	public bool FlagUpd = false;
	public string showres = "";
	


	IEnumerator PostponeShow() {
	
		yield return new WaitForSeconds(2);
		Advertisement.Show();

	}

	IEnumerator PostponeVideo() {
		yield return new WaitForSeconds(2);
		//Handheld.PlayFullScreenMovie ("videoviewdemo.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
		
	}

		void Awake() {


			//Advertisement.UnityDeveloperInternalTestMode = true;
			//Advertisement.Initialize("20071");

			//Advertisement.Initialize("20072");



		// ios Advertisement.Initialize("131623829");
		// android 
		//Advertisement.Initialize("28055"); //always has companies


			//Advertisement.Initialize("18581");//geogr filtering
			//Advertisement.Initialize("18922"); //problem with rewardzone

			//DEFECT   Advertisement.Initialize ("17287", true); //iOS
				//Advertisement.Initialize ("17872"); //Android


			//////////////DEBUG////////////////////////////////////////////////////////////////////////////////////

			//Defaults to ERROR, WARNING and INFO. For debug builds the default is ERROR, WARNING, INFO and DEBUG.

			//Advertisement.debugLevel = Advertisement.DebugLevel.DEBUG;
			//Advertisement.debugLevel = Advertisement.DebugLevel.ERROR;
			//Advertisement.debugLevel = Advertisement.DebugLevel.INFO;
			//Advertisement.debugLevel = Advertisement.DebugLevel.NONE;
			//Advertisement.debugLevel = Advertisement.DebugLevel.WARNING;

			Debug.Log("\n\n\n Advertisement.debugLevel = " + Advertisement.debugLevel.ToString()+"\n\n\n");

			
		}

	void Start()
	{
		//Advertisement.Initialize("131623110", true);
		}

	void Update() {

		if (FlagUpd) {

			FlagUpd =false;

			Advertisement.Show(null, new ShowOptions {
				
				resultCallback = result => {
					Debug.Log(result.ToString());
				}
			});

			Debug.Log("!!!!!!!!!!!!!!!! \n\n\n isShowing = " + Advertisement.isShowing + " \n\n\n !!!!!!!!!!!!!!!");
		}


	}


		void OnGUI() {
		if(GUI.Button(new Rect(10, 10, 150, 70), Advertisement.IsReady() ? "Show default Ad" : "Waiting when\nisReady() = true")) {
												 
			// Show with default zone, pause engine and print result to debug log
			Advertisement.Show(null, new ShowOptions {
				
				resultCallback = result => {
					Debug.Log("!!!!!!!!!!!!!!!!\n\n\nResult of Playing: " + result.ToString() + " \n\n\n!!!!!!!!!!!!!!!!");
					showres = result.ToString();
					}
				});
		}

		GUI.Label(new Rect(10,90,200,100),"Result of Playing:\n"+showres);

	
		///////1st Column
		/// 
		/// 

		if(GUI.Button(new Rect(Screen.width - 380, 10, 180, 50), Advertisement.IsReady() ? "Load the 2nd Scene" : "Waiting when \nisReady() = true"))
		{
			Application.LoadLevel("Scene2");

			StartCoroutine(PostponeShow());
		}

		
		if(GUI.Button(new Rect(Screen.width - 380, 70, 180, 50), Advertisement.IsReady() ? "Call Show()\nfrom Update function" : "Waiting when \nisReady() = true")) {

			FlagUpd = true;
		}


		if(GUI.Button(new Rect(Screen.width - 380, 130, 180, 50), "Print isInitialized value\ninto log")) {
			Debug.Log("isInitialized = " + Advertisement.isInitialized);
			
		}

		if(GUI.Button(new Rect(Screen.width - 380, 190, 180, 50), "Print isShowing value\ninto log")) {
			Debug.Log("isShowing = " + Advertisement.isShowing);
		}

		if(GUI.Button(new Rect(Screen.width - 380, 250, 180, 50), "Print isSupported value\ninto log")) {
			Debug.Log("isSupported = " + Advertisement.isSupported);
		}

		if(GUI.Button(new Rect(Screen.width - 380, 310, 180, 50), Advertisement.IsReady("pictureZone") ? "Show pictureZone Ads" : "Waiting when pictureZone\nAds are ready")) {
			Advertisement.Show("pictureZone", new ShowOptions {
				
				resultCallback = result => {
					Debug.Log(result.ToString());
				}
			});
		}
			
		if(GUI.Button(new Rect(Screen.width - 380, 370, 180, 50), Advertisement.IsReady("rewardedVideoZone") ? "Show\nrewardedVideoZone Ads" : "Waiting when\nrewardedVideoZone\nAds are ready")) {
			Advertisement.Show("rewardedVideoZone", new ShowOptions {
				
				resultCallback = result => {
					Debug.Log("!!!!!!!!!!!!!!!! \n\n\n isShowing = " + result.ToString() + " \n\n\n !!!!!!!!!!!!!!!");
				}
			});
		}

		if(GUI.Button(new Rect(Screen.width - 380, 440, 180, 50),  Advertisement.IsReady("defaultZone") ? "Show defaultZone Ads" : "Waiting when\ndefaultZone Ads are ready")) {
			Advertisement.Show("defaultZone", new ShowOptions {
				
				resultCallback = result => {
					Debug.Log(result.ToString());
				}
			});
		}

		///////2nd Column
		/// 
		/// 

		if (GUI.Button (new Rect (Screen.width - 190, 10, 180, 50), Advertisement.IsReady() ? "(Asycn) Load the 3rd Scene" : "Waiting when \nisReady() = true"))
		{
			Application.LoadLevelAsync("Scene3");
			StartCoroutine(PostponeShow());

		}


		if (GUI.Button (new Rect (Screen.width - 190, 70, 180, 50), "Play anyway: call Show()\nwithout checking isReady")) {						

			Advertisement.Show(null,new ShowOptions {
				
				resultCallback = result => {
					Debug.Log(result.ToString());
				}
			});
		}

		if (GUI.Button (new Rect (Screen.width - 190, 130, 180, 50), Advertisement.IsReady () ? "Try to show Ads\nwhile Video is played" : "Waiting when \nisReady() = true")) {						

			StartCoroutine(PostponeShow());
			//Handheld.PlayFullScreenMovie ("videoviewdemo.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);

		}

		if (GUI.Button (new Rect (Screen.width - 190, 190, 180, 50), Advertisement.IsReady () ? "Try to play Video\nwhile Ads are shown" : "Waiting when \nisReady() = true")) {						

			StartCoroutine(PostponeVideo());
			Advertisement.Show();
			
		}

		if(GUI.Button(new Rect(Screen.width - 190, 250, 180, 50), "Print isReady value\ninto log")) {
			Debug.Log("!!!!!!!!!!!!!!!!!       \n\n\n\nisReady = " + Advertisement.IsReady());

		}

		if(GUI.Button(new Rect(Screen.width - 190, 310, 180, 50), "Show unexisting\nPlacement #1")) {
			Advertisement.Show("sdsadksk", new ShowOptions {
				
				resultCallback = result => {
					Debug.Log(result.ToString());
				}
			});
			
		}

		if(GUI.Button(new Rect(Screen.width - 190, 370, 180, 50), "Show unexisting\nPlacement #2")) {
			Advertisement.Show("sdsadksk");
			
		}
		
		
	}

}
