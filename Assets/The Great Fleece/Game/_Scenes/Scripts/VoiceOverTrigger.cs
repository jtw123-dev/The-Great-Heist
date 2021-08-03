using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _voiceOver;
    [SerializeField] private AudioClip _voiceTrack;
     private bool _hasplayed;
    // Start is called before the first frame update
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player"&& _hasplayed==false)
        {
           // AudioSource.PlayOneShot
            AudioSource.PlayClipAtPoint(_voiceTrack,Camera.main.transform.position);
            _hasplayed = true;
        }
    }
}
