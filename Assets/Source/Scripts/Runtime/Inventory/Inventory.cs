using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    
    [SerializeField] private List<Cell> _listOfCells;

    public Action OnInventoryFull { get; set; }

    private bool _checkInventoryFull;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }
    private void Start()
    {
        OnInventoryFull += OpenFullInventoryUI;
    }

    private void OpenFullInventoryUI()
    {
        SelectionSystem.Instance.DeactivateSelectionSystem();
        TimerSystem.Instance.PauseTimer();
        UISystem.Instance.OpenWindow("FullInventory");
    }

    public void SetObjectToCell(Sprite sprite,int id)
    {
        foreach (Cell cell in _listOfCells)
        {
            if (cell.IsEmpty())
            {
                cell.SetObject(sprite,id);
                break;
            }
        }
        CheckTriple();
        if(_checkInventoryFull)
            CheckInventoryFull();
    }
    

    private void CheckTriple()
    {
        for(int i=0;i<_listOfCells.Count;i++)
        {
            if(_listOfCells[i].IsEmpty())
                continue;
            
            int cnt = 1;

            for (int j = i + 1; j < _listOfCells.Count; j++)
            {
                if(_listOfCells[j].IsEmpty())
                    continue;
                
                if (_listOfCells[j].idObject == _listOfCells[i].idObject)
                    cnt++;
                
                if (cnt == 3)
                {
                    StartCoroutine(ClearCells(_listOfCells[i].idObject));
                    ScoreSystem.Instance.UpdateScore();
                    _checkInventoryFull = false;
                    return;
                }
            }
        }

        _checkInventoryFull = true;
    }
    
    private IEnumerator ClearCells(int id)
    {
        //Animation of destoying objects in inventory by ID
        yield return new WaitForSeconds(0.2f);
        int cnt = 0;
        foreach (Cell cell in _listOfCells)
        {
            if(cnt==3) 
                break;
            if (cell.idObject == id)
            {
                cell.ClearCell();
                cnt++;
            }
        }
    }
    
    //Check if we don't have any space in inventory
    private void CheckInventoryFull()
    {
        foreach (Cell cell in _listOfCells)
        {
            if (cell.IsEmpty())
            {
                return;
            }
        }
        OnInventoryFull?.Invoke();
    }

    public void SetListOfCells(List<Cell> list)
    {
        _listOfCells = list;
    }
}
