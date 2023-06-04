using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSFX : MonoBehaviour
{
    [SerializeField]
    AudioSource _SheepSfxSource;
    [SerializeField]
    List<AudioClip> _clips;

    void Update()
    {
        if(!_SheepSfxSource.isPlaying)
        {
            PlaySheepSound();
        }
    }

    void PlaySheepSound()
    {
        int randomClip = Random.Range(0, _clips.Count);
        _SheepSfxSource.clip = _clips[randomClip];
        _SheepSfxSource.Play();
    }
}
