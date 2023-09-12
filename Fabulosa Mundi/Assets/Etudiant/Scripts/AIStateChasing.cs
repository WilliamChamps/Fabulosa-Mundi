using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateChasing : MonoBehaviour
{
    [SerializeField] private float stopRange = 3;
    [SerializeField] private string agressiveIdleAnimation = "isAttack-Idle";

    private AIMovementFunctionAdvanced _aiMovement;

    private int _agressiveIdleAnimationId;
    private Animator _animator;

    private NavMeshAgent _agent;

    void Awake()
    {
        _aiMovement = GetComponent<AIMovementFunctionAdvanced>();

        _agent = GetComponent<NavMeshAgent>();

        _animator = GetComponent<Animator>();
        _agressiveIdleAnimationId = Animator.StringToHash(agressiveIdleAnimation);
    }

    

    public void StateUpdate(Vector3 targetPosition)
    {
        if (Vector3.Distance(targetPosition, transform.position) >= stopRange)
        {
            _aiMovement.RunTo(targetPosition);
        }
        else
        {
            _aiMovement.RunTo(transform.position);
            _animator.SetBool(_agressiveIdleAnimationId, true);
            transform.LookAt(new Vector3(targetPosition.x, transform.position.y, targetPosition.z));
        }
    }
    void Update()
    {
        if (_agent.remainingDistance > 0.1f)
        {
            _animator.SetBool(_agressiveIdleAnimationId, false);
        }
    }
}
