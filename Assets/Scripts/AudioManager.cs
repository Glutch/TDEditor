using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public float master = 1;
    public float sfx = 1;
    public float music = 1;

    public static AudioManager instance;

    AudioSource[] musicSources;
    int activeMusicSourceIndex;

    private void Awake()
    {
        instance = this;

        musicSources = new AudioSource[2];
        for (int i = 0; i < 2; i++)
        {
            GameObject newMusicSource = new GameObject("MusicSource" + (i + 1));
            musicSources[i] = newMusicSource.AddComponent<AudioSource>();
            newMusicSource.transform.parent = transform;
        }
    }

    public void PlayMusic(AudioClip clip, float fadeDuration = 1)
    {
        activeMusicSourceIndex = 1 - activeMusicSourceIndex;
        musicSources[activeMusicSourceIndex].clip = clip;
        musicSources[activeMusicSourceIndex].Play();

        StartCoroutine(AnimateCrossfade(fadeDuration));
    }

    public void PlaySound(AudioClip clip, Vector3 pos, float volume)
    {
        if (volume == 1) {
            volume = sfx * master;
        }
        AudioSource.PlayClipAtPoint(clip, pos, volume);
    }

    IEnumerator AnimateCrossfade(float duration)
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / duration;
            musicSources[activeMusicSourceIndex].volume = Mathf.Lerp(0, music * master, percent);
            musicSources[1 - activeMusicSourceIndex].volume = Mathf.Lerp(music * master, 0, percent);
            yield return null;
        }
    }

}
