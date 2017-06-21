using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BoundInit : MonoBehaviour {

	public enum BoundType { Left, Right, Top, Bottom }

	public BoundType type;

	// Use this for initialization
	void Start () {
		var unitPerScreenX = 2*Camera.main.orthographicSize * Screen.width / Screen.height;
		var collider = GetComponent<BoxCollider2D> ();
		var position = transform.position;
		Vector2 size = collider.size;

		switch (type) {
		case BoundType.Left:
			position.x = -unitPerScreenX / 2 - collider.bounds.extents.x;
			size.y = Camera.main.orthographicSize*2;
			break;
		case BoundType.Right:
			position.x = unitPerScreenX / 2 + collider.bounds.extents.x;
			size.y = Camera.main.orthographicSize*2;
			break;
		case BoundType.Top:
			position.y = Camera.main.orthographicSize - 1 + collider.bounds.extents.y;
			size.x = unitPerScreenX;
			break;
		case BoundType.Bottom:
			position.y = -Camera.main.orthographicSize + 1 - collider.bounds.extents.y;
			size.x = unitPerScreenX;
			break;
		}

		transform.position = position;
		collider.size = size;

	}

}
