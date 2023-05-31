using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSystem : MonoBehaviour
{
    public static SelectionSystem Instance { get; set; }
    
    private Camera _camera;

    private Outline currentHighlight;

    private bool IsActive;
    private void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }
    
    private void Start()
    {
        IsActive = true;
        _camera = Camera.main;
    }

    public void DeactivateSelectionSystem() => IsActive = false;
    public void ActivateSelectionSystem() => IsActive = true;
    private void Update()
    {
        if (IsActive)
        {
            if (currentHighlight != null)
            {
                currentHighlight.enabled = false;
                currentHighlight.gameObject.transform.localScale /= 1.2f;
            }
            
        
        
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            bool hitSomething = Physics.Raycast(ray, out RaycastHit hit);

            if(!hitSomething)
                return;
        
            currentHighlight = hit.collider.gameObject.GetComponent<Outline>();

            if (currentHighlight != null)
            {
                currentHighlight.enabled = true;
                hit.collider.gameObject.transform.localScale *= 1.2f;
            }
            
        
            if(Input.GetMouseButtonDown(0))
            {
            
                ISelectable selectable = hit.collider.gameObject.GetComponent<ISelectable>();

                if(selectable == null)
                    return;
            
                selectable.OnSelect();
                Inventory.Instance.SetObjectToCell(selectable.Icon,selectable.Id);
            }
        }
    }

    
}
