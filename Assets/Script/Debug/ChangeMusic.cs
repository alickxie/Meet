using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public List<AudioClip> MusicList;
    public AudioSource currentMusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if player press number 1, change music to music1
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // change current music audioclip to music1
            currentMusic.clip = MusicList[0];
            //play music
            currentMusic.Play();
        }
        // if player press 2, change music to music2
        if (Input.GetKeyDown(KeyCode.W))
        {
            // change current music audioclip to music2
            currentMusic.clip = MusicList[1];
            currentMusic.Play();
        }
        // if player press 3, change music to music3
        if (Input.GetKeyDown(KeyCode.E))
        {
            // change current music audioclip to music3
            currentMusic.clip = MusicList[2];
            currentMusic.Play();
        }
        // if player press 4, change music to music4
        if (Input.GetKeyDown(KeyCode.R))
        {
            // change current music audioclip to music4
            currentMusic.clip = MusicList[3];
            currentMusic.Play();
        }
    }
}
