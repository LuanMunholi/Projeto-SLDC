using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF_PopulaLista : MonoBehaviour
{
    public Transform matriz;

    public List<GameObject> populaposicao = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        GetValidBisnetos(matriz);
    }

    void GetValidBisnetos(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);

            for (int j = 0; j < child.childCount; j++)
            {
                Transform neto = child.GetChild(j);

                for (int k = 0; k < neto.childCount; k++)
                {
                    Transform bisneto = neto.GetChild(k);
                    GameObject bisnetoGameObject = bisneto.gameObject;

                    // Verifica se o objeto é um bisneto e, se for, adiciona à lista.
                    if (bisnetoGameObject != null)
                    {
                        populaposicao.Add(bisnetoGameObject);
                    }
                }
            }
        }
    }
}
