using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{  
    public AudioSource audioSource;
    public List<AudioClip> audioClips;
    public Dictionary<string, AudioClip> soundDictionary;

    public TouchHandler touchHandler;
    public PLMover pLMover;

    private void OnEnable()
    {
        touchHandler.OnTouch += TouchScreen;
        pLMover.EndMove += TakeGem;
    }

    private void OnDisable()
    {
        touchHandler.OnTouch -= TouchScreen;
        pLMover.EndMove -= TakeGem;
    }

    void Awake()
    {
        soundDictionary = new Dictionary<string, AudioClip>();

        foreach (AudioClip clip in audioClips)
        {
            soundDictionary.Add(clip.name, clip);
        }
    }

    private void Start()
    {
        PlayBackgroundMusic("Background", 0.1f);
    }

    public void TakeGem()
    {
        PlaySound("TakeGem");
    }

    public void TouchScreen(Vector2 vector2)
    {
        PlaySound("TouchScreen");
    }

    public void PlaySound(string soundName)
    {
        if (soundDictionary.TryGetValue(soundName, out AudioClip clip))
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Sound not found: " + soundName);
        }
    }

    public void PlayBackgroundMusic(string musicName, float volume = 1f)
    {
        if (soundDictionary.TryGetValue(musicName, out AudioClip clip))
        {
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.volume = volume;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Music not found: " + musicName);
        }
    }

    public void StopBackgroundMusic()
    {
        audioSource.Stop();
    }

}
