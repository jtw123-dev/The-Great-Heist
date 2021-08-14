using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    [SerializeField] private GameObject _winScene; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            if (GameManager.Instance.HasCard==true)
            {
                _winScene.SetActive(true);
            }
            else
            {
                Debug.Log("You do not have key");
            }
        }
    }
}
