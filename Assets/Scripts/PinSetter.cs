using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public  Text StandingPinsText;
	// Use this for initialization
	void Start () {

	}

	public int CountStanding(){

		int standingPins=0;


		foreach (Pin thisPin in FindObjectsOfType<Pin>()) {
			if (thisPin.IsStanding()){
				standingPins++;
				Debug.Log (standingPins);
				StandingPinsText.text = standingPins.ToString ();
			}else{}
		}
		StandingPinsText.text = standingPins.ToString ();
		StandingPinsText.color=Color.black;
		return standingPins;

	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider ball){
		if (ball.GetComponent<Ball>()){
		Invoke("CountStanding",5f);
			StandingPinsText.color=Color.red;
		}
	}

	void OnTriggerExit(Collider other) {

		if (other.transform.parent){

		if (other.transform.parent.GetComponent<Pin>()){
			Debug.Log ("destroyed " + other.transform.parent.gameObject);
			Destroy (other.transform.parent.gameObject,1f);
			}
		}

		else if (other.GetComponent<Ball>()) {
			Debug.Log ("destroyed " + other.gameObject);
			Destroy (other.gameObject,1f);
		}


		}

	



}