using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem Instance { get; set; }
    private void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }


    [SerializeField] private AudioClip _buttonSound;
    [SerializeField] private AudioClip _mainMusic;

    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _soundAudioSource;
    
    private void Start()
    {
        _musicAudioSource.clip = _mainMusic;
        
        if(PlayerPrefs.GetInt("musicOn") == 1)
            _musicAudioSource.Play();
        else
            _musicAudioSource.Pause();
    }

    private void PauseMainMusic()
    {
        PlayerPrefs.SetInt("musicOn",0);
        _musicAudioSource.Pause();
    }

    private void ResumeMainMusic()
    {
        PlayerPrefs.SetInt("musicOn",1);
        _musicAudioSource.Play();
    }
    
    public void SwitchMusic()
    {
        if(PlayerPrefs.GetInt("musicOn") == 1)
            PauseMainMusic();
        else
            ResumeMainMusic();
    }

    public void PlayOneShotButton()
    {
        if(PlayerPrefs.GetInt("soundsOn") == 1)
            _soundAudioSource.PlayOneShot(_buttonSound);
    }

    public void SwitchSounds()
    {
        if(PlayerPrefs.GetInt("soundsOn") == 1)
            DisableSounds();
        else
            EnableSounds();
    }
    
    public void DisableSounds() => PlayerPrefs.SetInt("soundsOn",0);
    
    public void EnableSounds() => PlayerPrefs.SetInt("soundsOn",1);
}
