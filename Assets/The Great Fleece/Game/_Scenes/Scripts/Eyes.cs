using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField] GameObject _gameOverCutScene;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            _gameOverCutScene.SetActive(true);
        }
    }
}
