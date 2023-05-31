using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image _icon;

    public int idObject = -1;
    
    public void SetObject(Sprite sprite,int id)
    {
        _icon.enabled = true;
        _icon.sprite = sprite;
        idObject = id;
    }

    public void ClearCell()
    {
        _icon.enabled = false;
        _icon.sprite = null;
        idObject = -1;
    }

    public bool IsEmpty()
    {
        return _icon.sprite == null;
    }
    
}
