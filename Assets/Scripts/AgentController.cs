using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    NavMeshAgent agent;

    public Material screenMat;
    public Light screenLight;

    [SerializeField] Color[] patrolColors;

    [SerializeField]
    GameObject target;

    [SerializeField] float distance = 20;

    [SerializeField] float patrolRadius = 10;
    [SerializeField] float patrolTimer;

    private float timer;

    // Start is called before the first frame update
    void Awake()
    {
        patrolColors = new Color[2];
        screenLight = transform.GetChild(9).GetComponent<Light>();
        agent = GetComponent<NavMeshAgent>();

        timer = patrolTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= distance)
        {
            agent.destination = target.transform.position;
            screenLight.color = patrolColors[1];
            screenMat.color = patrolColors[1] * 3;
            screenMat.color = patrolColors[1];
        }
        else
        {
            AgentPatrol();
            screenLight.color = patrolColors[0];
            screenMat.color = patrolColors[0] * 3;
        }

    }

    void AgentPatrol()
    {
        timer += Time.deltaTime;

        if (timer >= patrolTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, patrolRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }


}
