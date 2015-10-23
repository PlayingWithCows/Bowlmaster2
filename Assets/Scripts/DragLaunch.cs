using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Vector3 fingerStartPos, fingerEndPos;
	private float startDragTime, dragEndTime;
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
	}

	public void DragStart(){
		fingerStartPos = Input.mousePosition;
		Debug.Log (fingerStartPos);
		startDragTime = Time.time;
	}

	public void MoveStart (float amount){
		switch (ball.ballIsLaunched){
		case true:
			Debug.Log ("unable to change position. Ball is launched already.");
			return;

		case false:
			if(transform.position.x+amount >=-50 && transform.position.x+amount <=50){
				ball.transform.Translate (new Vector3 (amount, 0, 0));
			}

			else{Debug.Log ("New position would be out of lane");} 
			return;
		}
	}


	public void DragEnd(){
		fingerEndPos = Input.mousePosition;
		dragEndTime = Time.time;

		Vector3 dragDistance = fingerEndPos-fingerStartPos;
		float dragTime = dragEndTime-startDragTime;
		float launchSpeed =(fingerEndPos.x - fingerStartPos.x)/dragTime;


		Debug.Log (fingerEndPos);
		Debug.Log ("Moved "+ dragDistance.x + "in x direction, and "+ dragDistance.y + "in y direction.");
		Debug.Log ("took " + dragTime + " seconds to drag.");

		Vector3 dragParameters = new Vector3(Mathf.Clamp(launchSpeed/10,-6f,6f), 0f, Mathf.Clamp ((dragDistance.y/10/dragTime),80f,120f));
		ball.Launch(dragParameters);
	
	}

}
