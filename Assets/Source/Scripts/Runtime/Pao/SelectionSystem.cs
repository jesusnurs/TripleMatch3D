using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSystem : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    
    private Camera _camera;

    private Outline currentHighlight;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
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
            _inventory.SetObjectToCell(selectable.Icon,selectable.Id);
        }
    }

    
}
