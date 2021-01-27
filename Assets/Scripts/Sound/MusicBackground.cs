using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackground : MonoBehaviour
{

    [SerializeField] AudioClip background_music;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = background_music;
        audio.loop = true;
        audio.volume = 0.07f;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
