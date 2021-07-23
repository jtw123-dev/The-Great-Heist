using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private int _cameraID;
    [SerializeField]private Transform _cameraPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            switch (_cameraID)
            {
                case 0:
                    {
                        Debug.Log("Trigger Activated");
                        Camera.main.transform.position = _cameraPos.transform.position;
                        Camera.main.transform.rotation = _cameraPos.transform.rotation;
                        //Camera.main.transform.rotation = _cameraID;
                    }
                    break;
                case 1:
                    {
                        Camera.main.transform.position = _cameraPos.transform.position;
                        Camera.main.transform.rotation = _cameraPos.transform.rotation;
                        break;   
                    }
                case 2:
                    {
                        Camera.main.transform.position = _cameraPos.transform.position;
                        Camera.main.transform.rotation = _cameraPos.transform.rotation;
                        break;
                    }
                case 3:
                    {
                        Camera.main.transform.position = _cameraPos.transform.position;
                        Camera.main.transform.rotation = _cameraPos.transform.rotation;
                        break;
                    }
                case 4:
                    {
                        Camera.main.transform.position = _cameraPos.transform.position;
                        Camera.main.transform.rotation = _cameraPos.transform.rotation;
                        break;
                    }
                case 5:
                    {
                        Camera.main.transform.position = _cameraPos.transform.position;
                        Camera.main.transform.rotation = _cameraPos.transform.rotation;
                        break;
                    }
            }
    }
    }
}
