using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Celso_Definitions 
{
    public static int _lvlScaleDeterminant = 5;
    public static int[,] _mapReferenceDeterminant = new int[_lvlScaleDeterminant,_lvlScaleDeterminant];


    public static void Level1()
    {
        _mapReferenceDeterminant[0, 0] = 1;
        _mapReferenceDeterminant[0, 1] = 2;
    }


    
}
