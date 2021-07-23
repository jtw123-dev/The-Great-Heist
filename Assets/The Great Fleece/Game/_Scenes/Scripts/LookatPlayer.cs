using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_target);
    }
}
