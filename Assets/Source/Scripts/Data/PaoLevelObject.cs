using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Pao Level Object", menuName = "Data/Level Data", order = 1)]
    public class PaoLevelObject : ScriptableObject
    {
        [field:SerializeField]
        public int Id { get; set; }
        
        [field: SerializeField]
        public List<SelectableObject> ListOfObjects;

        [field: SerializeField] 
        public int AmountOfPairs;
        
        [field: SerializeField] 
        public int Timer;
    }
}
