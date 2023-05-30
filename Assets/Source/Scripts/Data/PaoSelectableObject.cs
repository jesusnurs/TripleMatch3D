using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PaoSelectableObject : MonoBehaviour,ISelectable
{
    public Sprite Icon { get; set; }
    //public GameObject Prefab  { get; set; } 
    public int Id { get; set; }

    public void OnSelect()
    {
        Destroy(gameObject);
    }
}

public interface ISelectable
{
    public Sprite Icon { get; set; }
    //public GameObject Prefab  { get; set; } 
    public int Id { get; set; }
    public void OnSelect();
    
}