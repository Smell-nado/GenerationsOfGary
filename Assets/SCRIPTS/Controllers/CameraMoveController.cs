using UnityEngine;
using System.Collections;


public class CameraMoveController : TapSteveElement {

//Adult Transform
Vector3 _adultPos = new Vector3(0, 1.955f, -4.902f);
Vector3 _adultRot = new Vector3(2.6894f,0,0);

//Child Transfrom


//BabyTransform
Vector3 _babyPos = new Vector3(0, 1.94f, -1.27f);
Vector3 _babyRot = new Vector3(79.8331f,0,0);


	// Use this for initialization
	void Start () {
		Camera.main.transform.position = _babyPos;
		Camera.main.transform.rotation = Quaternion.Euler(_babyRot);
	}

    // Handles the events
    public void OnNotification(string p_event_path,Object p_target,params object[] p_data)
    {

    }
}
