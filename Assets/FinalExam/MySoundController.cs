using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySoundController : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip ShrinkingSound, Resettingsound;
    static AudioSource audioSrc;



    void Start()
    {
        ShrinkingSound = Resources.Load<AudioClip>("Shrinking");
        Resettingsound = Resources.Load<AudioClip>("Resetting");

        audioSrc = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Shrinking":
                audioSrc.PlayOneShot(ShrinkingSound);
                break;
            case "Resetting":
                audioSrc.PlayOneShot(Resettingsound);
                break;
        }
    }

}
