using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject target;
    UnityEngine.AI.NavMeshAgent agent;

    public GameObject player;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        player = GameObject.Find("Player");

        target = player;
    }

    // Update is called once per frame
    void Update()
    {
        //ターゲットのポジションまで向かう
        agent.destination = target.transform.position;

    }
}
