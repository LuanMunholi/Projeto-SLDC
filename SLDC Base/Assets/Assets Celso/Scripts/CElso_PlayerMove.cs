using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private  GameObject airplane1;
    [SerializeField] private  GameObject airplane2;
    private List<int> getLevel = new List<int>();
    private List<float> _locationX = new List<float>();
    private List<float> _locationZ = new List<float>();
    
    // Start is called before the first frame update
    void Start()
    {
        getLevel = levelDescription.leveList1;
        _locationX = levelDescription.xPosition;
        _locationZ = levelDescription.zPosition;
 
        PlayerPosition();
    }

   private void PlayerPosition()
   {
       List<int> planePosition = new List<int>();
       int planeID = 1;

       for (int i = 0; i < getLevel.Count; i++)
       {
           if (getLevel[i] == planeID)
           {
               planePosition.Add(i);
           }
       }

       if (planePosition.Any())
       {
           GameObject messer = Instantiate(airplane1,this.gameObject.transform,true);
           messer.transform.position = new Vector3(_locationX[planePosition[0]], 1, _locationZ[planePosition[0]]-.5f); 
          GameObject spitfire =Instantiate(airplane2, gameObject.transform,true);
           spitfire.transform.position =new Vector3(_locationX[planePosition[1]], 1, _locationZ[planePosition[1]]+0.5f); 
       }
       
   }
}
