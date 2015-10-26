using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	public int lastStandingCount =-1;
	public  Text StandingPinsText;

	private Ball ball;
	private int standingPins=0;
	private float lastChangeTime;
	private bool ballEnteredBox=false;


	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}

	public int CountStanding(){

		standingPins=0;


		foreach (Pin thisPin in FindObjectsOfType<Pin>()) {
			if (thisPin.IsStanding()){
				standingPins++;
				Debug.Log (standingPins);
			
			}else{}
		}

		if (int.Parse(StandingPinsText.text) != standingPins){
			StandingPinsText.text = standingPins.ToString ();
			lastChangeTime=Time.time;
		}

		return standingPins;

	}
	// Update is called once per frame
	void Update(){
	if (ballEnteredBox) {
			CountStanding();
			CheckStanding();
		}
	}

	void CheckStanding(){
		Debug.Log (Time.time - lastChangeTime);
		if ((Time.time - lastChangeTime) >= 3f) {
			PinsHaveSettled ();
			}

	}

	void PinsHaveSettled(){
		StandingPinsText.text = standingPins.ToString ();
		StandingPinsText.color=Color.green;
		lastStandingCount = standingPins;
		ballEnteredBox = false;
		ball.Reset();
	}


	void OnTriggerEnter(Collider ball){
		if (ball.GetComponent<Ball>()){
			ballEnteredBox=true;
			lastChangeTime=Time.time;
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

	

		}

	



}