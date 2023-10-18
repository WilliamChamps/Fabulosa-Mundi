using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int quantity = 3;
    [SerializeField] private GameObject prefab;

    public void Spawn()
    {
        for(int i = 0; i < quantity; i++)
        {
            Instantiate(prefab, null).transform.localPosition = transform.position + Vector3.up;
        }
    }
}
