using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Gun : MonoBehaviour
{

    [SerializeField] AudioClip[] sounds;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shootsound();
        }
    }

    public void Shootsound()
    {
        audio.PlayOneShot(sounds[Random.Range(0, 2)]);
    }
}
