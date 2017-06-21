using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseBound : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D coll)
	{
		Debug.Log ("trigger");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log ("collision");
	}
}
