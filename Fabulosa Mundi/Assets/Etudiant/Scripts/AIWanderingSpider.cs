using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWanderingSpider : MonoBehaviour
{
    [SerializeField] private bool waiting = false;

    [SerializeField] private float range = 5;
    [SerializeField] private float minWaitTime = 0;
    [SerializeField] private float maxWaitTime = 2;

    private AIMovementFunction _aiMovement;

    void Awake()
    {
        _aiMovement = GetComponent<AIMovementFunction>();
    }

    void Update()
    {
        if(!waiting)
        {
            waiting = true;
            _aiMovement.MoveToRandom(transform.position, range);
            StartCoroutine(StopWait());
        }
    }

    private IEnumerator StopWait()
    {
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        waiting = false;
    }
}
