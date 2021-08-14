using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if (_instance==null)
            {
                GameObject _spawnManager = new GameObject("Spawn Manager");
                _spawnManager.AddComponent<SpawnManager>();
            }
            return _instance;
        }
    }
    public void Awake()
    {
        _instance = this;
    }
    public void StartSpawning()
    {
        Debug.Log("Hi");
    }
    

}
