using System.Collections;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip GameMusic;
    public AudioClip MenuMusic;

    public AudioSource CurrentSource;
    public AudioSource IncomingSource;
    
    private float fadeDurationInSeconds = 2f;
    private float maximumVolume = 0.4f;

    public void Awake()
    {
        CurrentSource.loop = true;
        IncomingSource.loop = true;
        CurrentSource.volume = maximumVolume;
    }
    
    public void PlayMenuMusic()
    {
        if (CurrentSource.clip == null)
        {
            CurrentSource.clip = MenuMusic;
            CurrentSource.Play();
            return;
        }

        if (CurrentSource.clip == MenuMusic)
        {
            return;
        }
        StartCoroutine(CrossFade(MenuMusic));
    }

    public void PlayGameMusic()
    {
        if (CurrentSource.clip == GameMusic)
        {
            return;
        }
        StartCoroutine(CrossFade(GameMusic));
    }

    public IEnumerator CrossFade(AudioClip newClip)
    {
        IncomingSource.clip = newClip;
        IncomingSource.volume = 0f;
        IncomingSource.Play();

        float elapsedTimeInSeconds = 0f;

        while (elapsedTimeInSeconds < fadeDurationInSeconds)
        {
            elapsedTimeInSeconds += Time.deltaTime;
            float percentTime = elapsedTimeInSeconds / fadeDurationInSeconds;
            CurrentSource.volume = maximumVolume * (1 - percentTime);
            IncomingSource.volume = maximumVolume * percentTime;
            
            yield return null;
        }

        CurrentSource.Stop();
        CurrentSource.volume = maximumVolume;
        (CurrentSource, IncomingSource) = (IncomingSource, CurrentSource);
        
    }
}
