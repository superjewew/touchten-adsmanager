using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AndroidInfo : MonoBehaviour {

	public Text consoleText;
	AndroidDevice device = new AndroidDevice();

	void Start() {
		
	}

	public void GetDeviceId() {
		string id = device.GetDeviceId ();
		consoleText.text += "Device Id: " + id + "\n";
	}

	public void GetDeviceLocation() {
		string loc = device.GetDeviceLocation ();
		consoleText.text += "Device Loc: " + loc + "\n";
	}

	class AndroidDevice {

		AndroidJavaClass infoClass {
			get {
				return new AndroidJavaClass ("com.meyourours.androidinfo.MainActivity");
			}
		}

		public string GetDeviceId() {	
			string deviceId = infoClass.Call<string> ("GetDeviceId");
			return deviceId;
		}
			
		public string GetDeviceLocation() {
			string deviceLoc = infoClass.CallStatic<string> ("GetLocation");
			return deviceLoc;
		}
	}
}
