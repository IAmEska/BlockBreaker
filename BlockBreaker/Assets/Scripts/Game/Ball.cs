using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float constantSpeed = 5f;

	private Vector3 _direction;
	private Rigidbody2D _rigidbody;


	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_rigidbody.velocity = -Vector2.up * constantSpeed;
	}
		
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("trigger enter");
	}

	void OnCollisionEnter2D(Collision2D coll) { 
		Debug.Log ("collision enter");

		/*Vector2 from = coll.contacts [0].point;
		if (coll.gameObject.tag == "Platform") {
			//from.x = coll.transform.position.x;
		}
		Vector2 dir = from - new Vector2 (transform.position.x, transform.position.y);



		Vector2 old = _direction;
		Vector2 pos = transform.position;

		dir = -dir.normalized;

		if (dir.y == 0) {
			dir.y = _direction.y;
		} else if (dir.x == 0) {
			dir.x = _direction.x;
		}
		_direction = dir;

		Debug.DrawRay(from, coll.contacts[0].normal, Color.yellow, 4);
		Debug.DrawRay(transform.position.normalized, from, Color.white, 4);*/
			
		if (coll.gameObject.tag == "Brick") {
			Destroy (coll.gameObject);
		}
	}
}
