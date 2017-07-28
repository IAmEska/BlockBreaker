using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool autoPlay;

    private float _bricksPerLine;
    private float _minPos, _maxPos;
    private AudioSource _audioSource;
    private Ball ball;

    void Start()
    {
        _bricksPerLine = 2 * Camera.main.orthographicSize * Screen.width / Screen.height;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        _minPos = -_bricksPerLine / 2 + spriteRenderer.sprite.bounds.extents.x * transform.localScale.x;
        _maxPos = _bricksPerLine / 2 - spriteRenderer.sprite.bounds.extents.x * transform.localScale.x;
        _audioSource = GetComponent<AudioSource>();
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        if (autoPlay)
            AutoPlay();
        else
            MoveWithMouse();
    }

    void AutoPlay()
    {
        float halfBricks = _bricksPerLine / 2;
        Vector3 paddlePos = transform.position;
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, _minPos, _maxPos);
        transform.position = paddlePos;
    }
    
    void MoveWithMouse()
    {
        float halfBricks = _bricksPerLine / 2;
        float newPosX = -halfBricks + Input.mousePosition.x / Screen.width * _bricksPerLine;
        var newPos = transform.position;
        newPos.x = Mathf.Clamp(newPosX, _minPos, _maxPos);
        transform.position = newPos;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
            _audioSource.Play();
    }

}
