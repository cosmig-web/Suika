using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using Unity.VisualScripting.FullSerializer;

public class Spawning : MonoBehaviour
{
    public int seed;
    public GameObject[] SpawnableObjects;
    private bool Spawned = false;

  

    void Update()
    {
        seed = Random.Range(0, SpawnableObjects.Length);
        if (!Spawned)
        {
            Instantiate(SpawnableObjects[seed], new Vector2(0,2.41f), Quaternion.identity);
            Spawned = true;
        }

       
    }
    private void OnTriggerEnter2D(Collider2D other)
    { 
        Spawned = false;
    }
}
