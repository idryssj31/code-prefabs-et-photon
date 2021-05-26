using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterIA : MonoBehaviour
{
    //def une valeur mini et maxi pour notre variable
    [Range(0.5f, 50)]
    //pour la distance de detection
    public float detectDistance = 3;
    //tableaux de nos points
    public Transform[] points;
    //le composant navmesh pour naviguer
    NavMeshAgent agent;
    //cibler un point du tableaux
    int destinationIndex = 0;
    // l'élement a surveiller
    public Transform player;

    private void Start()
    {
        
        
        agent = GetComponent<NavMeshAgent>();
        if(agent != null)
        {
            agent.destination = points[destinationIndex].position;
        }
    }

    private void Update()
    {
        Walk();
        SearchPlayer();
    }


    public void SearchPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if(distanceToPlayer <= detectDistance)
        {
            //le joueur est détecté
            agent.destination = player.position;
            agent.speed = 2f;
        }
        else
        {
            //on sort de son champ de vision
            agent.destination = points[destinationIndex].position;
            agent.speed = 1.5f;
        }
    }

    public void Walk()
    {
        //nouveaux pathpoints apres en avoir atteint un
        float dist = agent.remainingDistance;
        //pour si on na mal placé le point
        if (dist <= 0.05f)
        {
            destinationIndex++;
            if (destinationIndex > points.Length - 1)
                destinationIndex = 0;
            agent.destination = points[destinationIndex].position;
        }
    }


    //dessiner la distance de detection
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectDistance);
    }

}
