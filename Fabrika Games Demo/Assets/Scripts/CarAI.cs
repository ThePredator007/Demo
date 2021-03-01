using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    public GameObject[] Targets;
    public GameObject Target;
    NavMeshAgent agent;
    int RandomIndex;


    // İncelediğiniz için ve önem gösterdiğiniz için çok teşekkür ederim. Fabrika games ile çalışmayı çok istiyorum :) iyi günler dilerim.
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        Targets = GameObject.FindGameObjectsWithTag("Players");
        MoveToPlayer();
    }

    
    void Update()
    {
        if (Target == null)
        {
            agent.isStopped = true;
            RandomIndex = Random.Range(0, Targets.Length);
            Target = Targets[RandomIndex];

        }
        else if (Target != null)
        {

            agent.isStopped = false;
            agent.SetDestination(Target.transform.position);
        }

        Targets = GameObject.FindGameObjectsWithTag("Players");
        
        

        float distance = Vector3.Distance(transform.position, Target.transform.position);
        if (distance == 0)
        {
            RandomIndex = Random.Range(0, Targets.Length);
            Target = Targets[RandomIndex];
        }


    }



    private void MoveToPlayer()
    {
        

        RandomIndex = Random.Range(0, Targets.Length);
        Target = Targets[RandomIndex];

        
    }
    

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Players")
        {

            col.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(250,380));
        }
    }
}
