using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


    public  static class levelDescription
    {
        public static List<int> leveList1 = new List<int> 
        {
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 3, 3,
            3, 1, 3, 0, 3,
            3, 3, 3, 5, 1  
        };
        
        // Escrevi as listas de posição e coordenadas desta maneira pq visualmente fica mais fácil identificar o
        // posicionamento dos objetos.
        
            
        public static  List<int> positionList = new List<int> 
        {
            0,  1,  2,  3,  4,
            5,  6,  7,  8,  9,
            10, 11, 12, 13, 14,
            15, 16, 17, 18, 19,
            20, 21, 22, 23, 24  
        };
    
        public static List<float> xPosition = new List<float> 
        {
            -2.5f,  -0.5f,  1.5f,  3.5f,  5.5f,
            -2.5f,  -0.5f,  1.5f,  3.5f,  5.5f,
            -2.5f,  -0.5f,  1.5f,  3.5f,  5.5f,
            -2.5f,  -0.5f,  1.5f,  3.5f,  5.5f,
            -2.5f,  -0.5f,  1.5f,  3.5f,  5.5f,
        };
        public static List<float> zPosition = new List<float> 
        {
            6.0f,  6.0f,  6.0f, 6.0f, 6.0f,
            4.0f, 4.0f, 4.0f, 4.0f, 4.0f,
            2.0f, 2.0f, 2.0f, 2.0f, 2.0f,
            0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 
            -2.0f, -2.0f, -2.0f, -2.0f, -2.0f  
        };

    }
