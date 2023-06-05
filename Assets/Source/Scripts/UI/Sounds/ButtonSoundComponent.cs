using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSoundComponent : MonoBehaviour
{
    private Button button;
    private AudioSystem audioSystem => AudioSystem.Instance;
    private void Awake()
    {
        button = GetComponent<Button>();
            
        button.onClick.AddListener(OnButtonPress);
    }

    private void OnButtonPress()
    {
        audioSystem.PlayOneShotButton();
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnButtonPress);
    }
}
