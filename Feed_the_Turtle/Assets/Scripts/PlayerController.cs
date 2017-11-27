using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Text looseText;

	private float moveHorizontal;
	private float moveVertical;
	private int count;
	private int badCount;

	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		badCount = 0;
		winText.text = "";
		looseText.text = "";
		SetCountText (); 
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		 
		rb2d.AddForce (movement*speed);
		
	}


	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.CompareTag ("Pickup")) {

			other.gameObject.SetActive (false);

			count = count + 1;
			SetCountText ();	
		}
		else if (other.gameObject.CompareTag ("BadPickup")) {

			other.gameObject.SetActive (false);
			badCount = badCount + 1;
			SetCountText ();	
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (badCount < 2) {
			if (count >= 9) {
				winText.text = "You Win!!";
				gameObject.SetActive (false);

			}
		} 
		else 
		{
			gameObject.SetActive (false);
			looseText.text = "You Lost!!!!";
		}
	}
}
