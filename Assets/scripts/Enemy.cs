using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
      
    public Transform player;
    public float velocidade = 5f; 
    
    private NavMeshAgent agent;

    void Start(){
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){
        agent.destination = player.position;
    }

    public void Freeze(){
        agent.velocity = Vector3.zero;
        agent.isStopped = true;
    }
}