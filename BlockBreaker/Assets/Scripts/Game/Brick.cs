using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public static int bricksLeft = 0;

    public Sprite[] sprites;
    public AudioClip[] audioClips;

    private int _hits;
    private SpriteRenderer _spriteRenderer;

	// Use this for initialization
	void Start ()
    {
        _hits = 0;
        _spriteRenderer = GetComponent<SpriteRenderer>();

        bricksLeft++;
    }

    void HandleHit()
    {
        if (_hits < audioClips.Length)
            AudioSource.PlayClipAtPoint(audioClips[_hits], transform.position);

        _hits++;
        
        if (_hits >= sprites.Length)
        {
            Destroy(gameObject);
            bricksLeft--;

            if (bricksLeft == 0)
            {
                //TODO start new level;
            }
            return;
        }

        _spriteRenderer.sprite = sprites[_hits];
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        HandleHit();
    }
}
