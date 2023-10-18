using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Celso_LevelInstantiator : MonoBehaviour
{
    [SerializeField] public GameObject edgeBoard; 
    [SerializeField] private  GameObject airplane1; 
    [SerializeField] private  GameObject airplane2;
    private List<int> getLevel = new List<int>();
    


    void Start()
    {
        EdgeInstantiation();
    }

    private void EdgeInstantiation()
    {
        
    }
}
