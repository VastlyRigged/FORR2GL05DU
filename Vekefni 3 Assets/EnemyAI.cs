using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public Transform M_Player;
    // Start is called before the first frame update
    void Start()
    {
        M_Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (M_Player.GetComponent<PlayerScript>().isDead == false)
        {
            gameObject.GetComponent<NavMeshAgent>().destination = M_Player.position;
        }
    }
}
