using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {
	public float standingThreshold;

	// Use this for initialization
	void Start () {
	
	}

	public bool IsStanding() {
		
		Vector3 angle = transform.rotation.eulerAngles;
		
		float tiltInX = Mathf.Abs(angle.x);
		
		float tiltInZ = Mathf.Abs(angle.z);
		
		if (tiltInX >= 180 && tiltInX <= 360) {
			
			tiltInX = 360 - tiltInX;
			
		}
		
		if (tiltInZ >= 180 && tiltInZ <= 360) {
			
			tiltInZ = 360 - tiltInZ;
			
		}
		
		if (tiltInX > standingThreshold && tiltInZ > standingThreshold) {

//
//				Debug.Log ("destroyed " + gameObject);
//				Destroy (gameObject,3f);


			return false;
			
		} else {
			
			return true;
			
		}
		
	}


	// Update is called once per frame
	void Update () {

	}
}
