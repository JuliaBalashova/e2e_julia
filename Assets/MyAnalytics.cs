using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class MyAnalytics : MonoBehaviour {



	void OnGUI() {

		if (GUI.Button (new Rect (10, 150, 150, 50), "Transaction")) {
			Analytics.Transaction("6879code code", 3.49m, "USD", "abc", "signature");		
		}




		if(GUI.Button(new Rect(10, 210, 150, 50), "Custom Event 1")) {
	
			Analytics.CustomEvent("event1", new Dictionary<string, object>
			                      {
				{ "power", 189 },
				{ "health", 170 },
				{ "score", 100555 }
			});
		
		}


		if(GUI.Button(new Rect(10, 270, 150, 50), "Custom Event 2")) {
			Analytics.CustomEvent("event2", new Dictionary<string, object>
			                      {
				{ "potions", 1 },
				{ "coins", 2 },
				{ "potions2", "sss" },
				{ "level", 5 }
			});
			
		}

		if(GUI.Button(new Rect(10, 330, 150, 50), "User info")) {
  			Gender gender = Gender.Female;
 			Analytics.SetUserGender(gender);

  			int birthYear = 2014;
  			Analytics.SetUserBirthYear(birthYear);
		}

	}


}
