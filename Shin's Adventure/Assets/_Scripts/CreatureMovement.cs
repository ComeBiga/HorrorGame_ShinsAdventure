using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CreatureMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform target;

    bool followTarget = false;

    Animator anim;

    public UnityEvent OnAttack;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(followTarget)
            agent.SetDestination(target.position);
    }

    public void WakeUpCreature()
    {
        followTarget = true;
        anim.SetBool("Attack", true);
        GetComponent<AudioSource>().Play();
    }

    public void StopChasing()
    {
        followTarget = false;
        agent.isStopped = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            OnAttack.Invoke();

            SoundManager.instance.Stop("CreatureChasing");
            GetComponent<AudioSource>().Stop();
            if (!SoundManager.instance.IsPlaying("CreatureAttack"))
                SoundManager.instance.Play("CreatureAttack");
            //followTarget = false;
        }
    }
}
