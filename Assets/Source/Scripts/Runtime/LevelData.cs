using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Runtime
{
    public class LevelData : MonoBehaviour
    {
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private TimerSystem _timerSystem;


        public Action OnEmptyListOfObjects { get; set; }

        private List<PaoSelectableObject> _listOfAllObjectOnScene;

        public int _timeForLevel;
        
        private void Init()
        {
           
        }
        private void Start()
        {
            Init();
        }
        
        public void SetListOfAllObjects(List<PaoSelectableObject> list)
        {
            _listOfAllObjectOnScene = list;
        }
    }
}
