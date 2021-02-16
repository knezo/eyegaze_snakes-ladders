using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip diceSound, successSound, failSound, winSound;
    static AudioSource audioSrc = new AudioSource ();

    // Start is called before the first frame update
    void Start(){

        diceSound = Resources.Load<AudioClip> ("Sounds/dice");
        successSound = Resources.Load<AudioClip> ("Sounds/success-bell");
        failSound = Resources.Load<AudioClip> ("Sounds/negative-beeps");
        winSound = Resources.Load<AudioClip> ("Sounds/winning_2");

        audioSrc = GetComponent<AudioSource> ();

        // audioSrc.PlayOneShot(winSound);
        // audioSrc.PlayOneShot(failSound);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string sound){
        switch (sound) {
            case "dice":
                audioSrc.PlayOneShot (diceSound);
                break;
            
            case "ladder":
                audioSrc.PlayOneShot (successSound);
                break;

            case "snake":
                audioSrc.PlayOneShot (failSound);
                break;
            
            case "win":
                audioSrc.PlayOneShot (winSound);
                break;
        
        }
    }

}
