using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public Vector3 launchVelocity;
	private AudioSource audioSource;
    private Rigidbody rigidBody;

	public bool ballIsLaunched = false;

	private Vector3 startPos, startVelocity, startAngVelocity;
	private Quaternion startRot;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
		rigidBody.useGravity=false;
		startPos = transform.position;
		startRot = transform.rotation;
	}

	public void Launch (Vector3 velocity)
	{
		Debug.Log ("Launching Ball with parameters x, y, z :" + velocity);
		rigidBody.velocity = velocity;
		rigidBody.useGravity=true;

		audioSource = GetComponent<AudioSource>();
		audioSource.Play ();
		ballIsLaunched = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset(){
		ballIsLaunched = false;
		rigidBody.useGravity=false;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.velocity = Vector3.zero;
		transform.rotation = startRot;
		transform.position = startPos;

	}
}
