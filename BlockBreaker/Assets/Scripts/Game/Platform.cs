using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	private float _bricksPerLine;
	private float _minPos, _maxPos;

	void Start() {
		_bricksPerLine = 2*Camera.main.orthographicSize * Screen.width / Screen.height;
		var spriteRenderer = GetComponent<SpriteRenderer> ();
		_minPos = -_bricksPerLine / 2 + spriteRenderer.sprite.bounds.extents.x * transform.localScale.x;
		_maxPos = _bricksPerLine / 2 - spriteRenderer.sprite.bounds.extents.x * transform.localScale.x ;
	}

	void Update() {
		
		float halfBricks = _bricksPerLine / 2;
		float newPosX = -halfBricks + Input.mousePosition.x / Screen.width * _bricksPerLine;
		var newPos = transform.position;
		newPos.x = Mathf.Clamp(newPosX, _minPos, _maxPos);
		transform.position = newPos;

		Debug.Log (newPosX);
	}

}
