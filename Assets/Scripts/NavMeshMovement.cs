using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        speed = 10;
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
        //Shoot a ray from the camera and move to the camera if a collision is detected
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
