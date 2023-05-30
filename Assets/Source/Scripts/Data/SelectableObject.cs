using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Selectable Object", menuName = "Data/Object Data", order = 0)]
    public class SelectableObject : ScriptableObject
    {
        [field:SerializeField]
        public int Id { get; set; }
        
        [field: SerializeField]
        public GameObject Prefab { get; set; }
        
        [field: SerializeField]
        public Sprite Icon { get; set; }
    }
}

