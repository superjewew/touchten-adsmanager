using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AndroidInfo : MonoBehaviour {

	public Text consoleText;

	AndroidDevice device = new AndroidDevice();

	public void GetDeviceId() {
		string id = device.GetDeviceId ();
		consoleText.text += "Device Id: " + id + "\n";
	}

	class AndroidDevice {

		public string GetDeviceId() {
			AndroidJavaClass infoClass = new AndroidJavaClass ("com.meyourours.androidinfo.MainActivity");
			string deviceId = infoClass.Call<string> ("GetDeviceId");
			return deviceId;
		}

	}
}
