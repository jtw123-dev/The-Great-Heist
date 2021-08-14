using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    private Player _player;
    [SerializeField]private GameObject _cardCutScene;
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            _cardCutScene.SetActive(true);
            _player.StopPlayer();
            GameManager.Instance.HasCard = true;
        }
    }
}
