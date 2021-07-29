using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Eyes : MonoBehaviour
{
    [SerializeField] GameObject _gameOverCutScene;
    private void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            _gameOverCutScene.SetActive(true);
        }
    }
}
