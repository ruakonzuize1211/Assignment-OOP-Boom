using UnityEngine;
using System.Collections;

public enum soundsGame
{
   
    play,
    option,
    exit,
    about,
    menu
}

public class SoundController : MonoBehaviour
{
    public AudioClip soundPlay;
    public AudioClip soundOption;
    public AudioClip soundAbout;
    public AudioClip soundExit;
    public AudioClip soundMenu;

    public static SoundController instance;

    // Use this for initialization
    void Start()
    {
        instance = this;
    }
    public static void PlaySound(soundsGame currentSound)
    {
        switch (currentSound)
        {
            case soundsGame.play:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundPlay);
                    instance.Invoke("PlaySoundDie", 2f);
                }
                break;
            case soundsGame.option:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundOption);
                   
                }
                break;
            case soundsGame.about:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundAbout);
                }
                break;
            case soundsGame.exit:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundExit);
                }
                break;
            case soundsGame.menu:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundMenu);
                }
                break;
        }
    }
    private void PlaySoundDie()
    {
        PlaySound(soundsGame.play);
    }

}
