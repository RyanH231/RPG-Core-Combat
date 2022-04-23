using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
    private Ray lastRay;
    [SerializeField]private float speed;
    private Transform destination;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        destination = GameObject.Find("Target").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //To convert the mouse position to a ray on screen
        if(Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);

        if(hasHit)
        {
            navMeshAgent.SetDestination(hit.point);
            navMeshAgent.speed = speed;
        }
    }
}
