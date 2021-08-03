using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    private NavMeshAgent _agent;
    [SerializeField] private int _currentTarget;
    private bool _reverse;
    public bool _targetReached;
    private Animator  _anim;
    public bool coinTossed;
    private Player _player;
    

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _anim = GetComponent<Animator>();
        
        if(_anim==null)
        {
            Debug.Log("anim is null");
        }
        _agent = GetComponent<NavMeshAgent>();
        if (_anim==null)
        {
            Debug.Log("anim is null");
        }
    }
    // Update is called once per frame
    void Update()
    {      
        if (coinTossed==false)
        {
            if (wayPoints.Count > 0 && wayPoints[_currentTarget] != null)
            {
                _agent.SetDestination(wayPoints[_currentTarget].position);
                float distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);

                if (distance < 1.0f && _targetReached == false)
                {
                    if (wayPoints.Count < 2)
                    {
                        return;
                    }
                    if (_currentTarget == 0 || _currentTarget == wayPoints.Count - 1 && wayPoints.Count > 1)
                    {
                        _targetReached = true;
                        StartCoroutine("WaitBeforeMoving");
                    }
                    else
                    {
                        if (_reverse == true)
                        {
                            _currentTarget--;
                            if (_currentTarget <= 0)
                            {
                                _reverse = false;
                                _currentTarget = 0;
                            }
                        }
                        else
                        {
                            _currentTarget++;
                        }
                    }
                }
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, _player.coinTarget);
            if (distance < 5 )
            {
                _anim.SetBool("Walk", false);
            }
        }
       
    }
        
    IEnumerator WaitBeforeMoving()
    {
        if (_currentTarget == 0)
        {
            if (coinTossed==false)
            {
                _anim.SetBool("Walk", false);
                yield return new WaitForSeconds(Random.Range(2, 5));
                _reverse = false;
                _currentTarget = 0;
                _anim.SetBool("Walk", true);
            }
            else
            {
                _anim.SetBool("Walk", true);
             _agent.SetDestination(_player.coinTarget);
                float distance = Vector3.Distance(transform.position, _player.coinTarget);
                if (distance < 1.7f && _targetReached == false)
                {
                    _anim.SetBool("Walk", false);
                }
            }
            
        }
        else if (_currentTarget ==wayPoints.Count-1)//To solve the out of range exception
        {
            _anim.SetBool("Walk", false);
            yield return new WaitForSeconds(Random.Range(2, 5));
            _anim.SetBool("Walk", true);
            _reverse = true;           
        }

        if (_reverse==true)
        {       
            _currentTarget--;

        }
        else if (_reverse==false)
        {
            
            _currentTarget++;

            if (_currentTarget == wayPoints.Count)
            {
                yield return new WaitForSeconds(Random.Range(2, 5));
                _reverse = true;
                _currentTarget--;
            }
        }
            _targetReached = false;
    }
    public void StopPatrolling()
    {
        coinTossed = true;      
    }
}
