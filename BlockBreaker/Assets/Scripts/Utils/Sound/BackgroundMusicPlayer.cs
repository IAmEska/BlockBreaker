using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicPlayer : MonoBehaviour {

    static BackgroundMusicPlayer instance = null;

   private AudioSource _audioSource;

   void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

        instance = this;

        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

}
