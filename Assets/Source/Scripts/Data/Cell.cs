using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image _icon;

    public int idObject = Int32.MaxValue;

    private void Start()
    {
        ClearCell();
    }

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
        idObject = Int32.MaxValue;
    }

    public bool IsEmpty()
    {
        return _icon.sprite == null;
    }
    
}
