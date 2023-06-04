using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField]
    AudioSource _BackgroundSource;
    [SerializeField]
    AudioSource _SfxSource;

    [Header("Clips")]
    [SerializeField]
    AudioClip _WinClip;
    [SerializeField]
    AudioClip _LoseClip;

    private void OnEnable()
    {
        GameEvents.PlaySFX += PlaySoundEffect;
        GameEvents.PlayerWin+= PlayWinClip;
        GameEvents.PlayerDeath += PlayLoseClip;
    }

    private void OnDisable()
    {
        GameEvents.PlaySFX -= PlaySoundEffect;
        GameEvents.PlayerWin -= PlayWinClip;
        GameEvents.PlayerDeath -= PlayLoseClip;
    }

    void Start()
    {
        if (!_BackgroundSource.isPlaying)
            _BackgroundSource.Play();
    }

    void PlaySoundEffect(AudioClip audioClip)
    {
        _SfxSource.clip = audioClip;
        _SfxSource.Play();
    }

    void PlayWinClip()
    {
        _SfxSource.Stop();
        PlaySoundEffect(_WinClip);
    }

    void PlayLoseClip()
    {
        _SfxSource.Stop();
        PlaySoundEffect(_LoseClip);
    }
}
