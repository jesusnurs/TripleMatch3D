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
    [SerializeField] private ScoreSystem _scoreSystem;
    
    public Action OnInventoryFull { get; set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }
    private void Start()
    {
        OnInventoryFull += GameStateCallBacks.Instance.OnGameLost;
    }

    public void SetObjectToCell(Sprite sprite,int id)
    {
        CheckInventoryFull();
        foreach (Cell cell in _listOfCells)
        {
            if (cell.IsEmpty())
            {
                cell.SetObject(sprite,id);
                CheckTriple();
                return;
            }
        }
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
                    _scoreSystem.UpdateScore(3);
                    return;
                }
            }
        }
    }

    private IEnumerator ClearCells(int id)
    {
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

    private void CheckInventoryFull()
    {
        foreach (Cell cell in _listOfCells)
        {
            if (cell.IsEmpty() && cell != _listOfCells[_listOfCells.Count-1])
            {
                return;
            }
        }
        OnInventoryFull?.Invoke();
    }
}