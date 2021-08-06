using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _gameOver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
             MeshRenderer render = GetComponent<MeshRenderer>();
            Color color = new Color(0.6f, .1f,.1f, .3f);           
            render.material.SetColor("_TintColor", color);
            _gameOver.SetActive(true);
            _animator.enabled = false;
            StartCoroutine("WaitToPlay");                
        }
    }
    private IEnumerator WaitToPlay()
    {
        yield return new WaitForSeconds(.5f);      
    }
}



