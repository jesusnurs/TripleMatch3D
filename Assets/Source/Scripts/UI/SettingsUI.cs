using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUI : UIElement
{
    [SerializeField] private Button _closeButton;

    [Space]
    [Header("Music/Sound buttons")]
    [SerializeField] private Button _musicButton;
    [SerializeField] private Button _soundsButton;
    
    [Space]
    [Header("Music/Sound swap sprites")]
    [SerializeField] private Sprite _musicOnSprite;
    [SerializeField] private Sprite _musicOffSprite;
    [SerializeField] private Sprite _soundsOnSprite;
    [SerializeField] private Sprite _soundsOffSprite;
    
    public override void AddListeners()
    {
        _closeButton.onClick.AddListener(CloseWindow);
        _musicButton.onClick.AddListener(SwitchMusicButton);
        _soundsButton.onClick.AddListener(SwitchSoundsButton);
    }

    public override void RemoveListeners()
    {
        _closeButton.onClick.RemoveListener(CloseWindow);
        _musicButton.onClick.RemoveListener(SwitchMusicButton);
        _soundsButton.onClick.RemoveListener(SwitchSoundsButton);
    }

    public override void Init()
    {
        if (PlayerPrefs.GetInt("musicOn") == 1)
            _musicButton.gameObject.GetComponent<Image>().sprite = _musicOnSprite;
        else
            _musicButton.gameObject.GetComponent<Image>().sprite = _musicOffSprite;
        
        if (PlayerPrefs.GetInt("soundsOn") == 1)
            _soundsButton.gameObject.GetComponent<Image>().sprite = _soundsOnSprite;
        else
            _soundsButton.gameObject.GetComponent<Image>().sprite = _soundsOffSprite;
    }
    
    private void CloseWindow()
    {
        UISystem.Instance.CloseCurrentWindow();
    }

    private void SwitchMusicButton()
    {
        AudioSystem.Instance.SwitchMusic();
        
        if (PlayerPrefs.GetInt("musicOn") == 1)
            _musicButton.gameObject.GetComponent<Image>().sprite = _musicOnSprite;
        else
            _musicButton.gameObject.GetComponent<Image>().sprite = _musicOffSprite;
    }
    
    private void SwitchSoundsButton()
    {
        AudioSystem.Instance.SwitchSounds();
        
        if (PlayerPrefs.GetInt("soundsOn") == 1)
            _soundsButton.gameObject.GetComponent<Image>().sprite = _soundsOnSprite;
        else
            _soundsButton.gameObject.GetComponent<Image>().sprite = _soundsOffSprite;
    }
}