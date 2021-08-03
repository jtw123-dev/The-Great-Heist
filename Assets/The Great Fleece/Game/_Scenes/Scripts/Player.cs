using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public NavMeshAgent _agent;
    private Animator _animator;
    public Vector3 _target;
    [SerializeField] GameObject _coinPrefab;
    [SerializeField] AudioClip _coinSoundEffect;
    private bool _hasThrown;
    private GuardAI _gaurdHandle;
    public Vector3 coinTarget;

    [SerializeField]private NavMeshAgent[] _guardCollection;

    // Start is called before the first frame update
    void Start()
    {        
       _animator = GameObject.Find("Player").GetComponentInChildren<Animator>();
       _agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {      
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                _agent.destination = hitInfo.point;
                _animator.SetBool("Walk", true);
                _target = hitInfo.point;            
            }
        }
        float distance = Vector3.Distance(transform.position, _target);
        if (distance<1)
        {
            _animator.SetBool("Walk", false);
        }

        if (Input.GetMouseButtonDown(1) && _hasThrown==false)
        {
            _hasThrown = true;
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Instantiate(_coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_coinSoundEffect, hitInfo.point);
                coinTarget = hitInfo.point;
                SendAIToCoinSpot(hitInfo.point);
                _animator.SetTrigger("Throw");
            }
        }
    }
  public  void SendAIToCoinSpot(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach (var guard in guards)
        {
            NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            Animator currentAnim = guard.GetComponent<Animator>();
           
            currentAnim.SetBool("Walk", true);
            currentAgent.SetDestination(coinPos);
            currentGuard.coinTossed = true;          
        }
    }
}
