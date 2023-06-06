using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime
{
    public class SpawnObjects : MonoBehaviour
    {
        public static SpawnObjects Instance;
        
        [SerializeField] private Transform _spawnBoxCenter;
        
        
        private List<SelectableObject> _listOfObjects;
        private List<PaoSelectableObject> _listOfAllObjects = new List<PaoSelectableObject>();

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            else
                Instance = this;
        }

        private void Start()
        {
            
        }

        public void StartSpawnObjects(PaoLevelObject level)
        {
            _listOfObjects = level.ListOfObjects;
            
            foreach (SelectableObject item in _listOfObjects)
            {
                for (int i = 0; i < level.AmountOfPairs * 3; i++)
                {
                    Vector3 rndSpawnPos = new Vector3(_spawnBoxCenter.position.x + Random.Range(-2, 2),
                        _spawnBoxCenter.position.y + Random.Range(0, 3),
                        _spawnBoxCenter.position.z + Random.Range(-2, 2));
                    PaoSelectableObject obj = Instantiate(item.Prefab, rndSpawnPos, Quaternion.identity).GetComponent<PaoSelectableObject>();
                    obj.Icon = item.Icon;
                    obj.Id = item.Id;
                    _listOfAllObjects.Add(obj);
                }
            }

            LevelObjectsCounter.Instance.SetAllObjects(_listOfAllObjects);
        }
        
        public void SpawnObjectsFromInventory(PaoLevelObject level)
        {
            _listOfObjects = level.ListOfObjects;
            
            foreach (SelectableObject item in _listOfObjects)
            {
                for (int i = 0; i < level.AmountOfPairs * 3; i++)
                {
                    Vector3 rndSpawnPos = new Vector3(_spawnBoxCenter.position.x + Random.Range(-2, 2),
                        _spawnBoxCenter.position.y + Random.Range(0, 3),
                        _spawnBoxCenter.position.z + Random.Range(-2, 2));
                    PaoSelectableObject obj = Instantiate(item.Prefab, rndSpawnPos, Quaternion.identity).GetComponent<PaoSelectableObject>();
                    obj.Icon = item.Icon;
                    obj.Id = item.Id;
                    _listOfAllObjects.Add(obj);
                }
            }

            LevelObjectsCounter.Instance.SetAllObjects(_listOfAllObjects);
        }
    }
}

