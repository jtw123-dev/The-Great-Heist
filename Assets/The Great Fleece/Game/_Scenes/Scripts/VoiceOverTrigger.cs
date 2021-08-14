using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    private bool _hasplayed;
    public AudioClip clipToPlay;
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player"&& _hasplayed==false)
        {
            AudioManager.Instance.PlayVoiceOver(clipToPlay);
            _hasplayed = true;
        }
    }
}
