using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Platform platform;

	public float constantSpeed = 5f;
    public float horizontalLaunch = 2f;
    
	private Rigidbody2D _rigidbody;
    private Vector3 _paddleToBallVector;
    private bool _isStarted;


    // Use this for initialization
    void Start () {
        platform = FindObjectOfType<Platform>();
        _paddleToBallVector = transform.position - platform.transform.position;
        _isStarted = false;
		_rigidbody = GetComponent<Rigidbody2D> ();
		//_rigidbody.velocity = -Vector2.up * constantSpeed;
	}

    void Update()
    {
        if (_isStarted)
            return;

        transform.position = platform.transform.position + _paddleToBallVector;

        if (Input.GetMouseButton(0))
        {
            _rigidbody.velocity = new Vector2(horizontalLaunch, constantSpeed);
            _isStarted = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (_isStarted)
        {
            Debug.Log("enter");
            Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
            _rigidbody.velocity = _rigidbody.velocity + tweak;
        }
    }
}
