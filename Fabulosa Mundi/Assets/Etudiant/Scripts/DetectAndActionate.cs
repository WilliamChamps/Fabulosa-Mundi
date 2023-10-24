using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndActionate : MonoBehaviour
{
    [SerializeField] private float reach = 3;
    [SerializeField] private LayerMask layers;
    private RaycastHit _hit;
    private Actionable _objectLookedAt;
    private Actionable _actionable;
    private Actionable _actionableInHand;
    private bool _isWaiting = false;
    private float _waitingTimeBetweenActions = 0.7f;


    private Animator _handAnimator;
    public Animator ArmAnimator;
    private int _animParameterHit;
    private int _animParameterLog;

    private void Start()
    {
        _handAnimator = InventorySystem.Instance.GetComponentInParent<Animator>();
        _animParameterHit = Animator.StringToHash("Hit");
        _animParameterLog = Animator.StringToHash("Log");
    }

    void Update()
    {
        DetectActionable();
    }

    private void DetectActionable()
    {
        _objectLookedAt = null;
        if (Physics.Raycast(transform.position, transform.forward, out _hit, reach, layers))
            _objectLookedAt = _hit.transform.GetComponent<Actionable>();
        
        if (_objectLookedAt == _actionable) return;
        
        if (_actionable)
            _actionable.StopLookingAt();
        
        _actionable = _objectLookedAt;

        if (_actionable)
            _actionable.StartLookingAt();   
    }

    public void ActionateObjectMainAction()
    {
        if (_isWaiting) return;

        _actionableInHand = InventorySystem.Instance.GetComponentInChildren<Actionable>();
        if (_actionableInHand)
        {
            _handAnimator.SetTrigger(_animParameterHit);
            ArmAnimator.SetTrigger(_animParameterHit);
        }
            

        if (!_actionable) return;
        _actionable.ActionateMainAction();
        StartCoroutine(Wait());
    }

    public void ActionateObjectSecondaryAction()
    {
        if (_isWaiting) return;

        _actionableInHand = InventorySystem.Instance.GetComponentInChildren<Actionable>();
        if(_actionableInHand)
        {
            _actionableInHand.ActionateSecondaryAction();
            StartCoroutine(Wait());
            return;
        }

        if(_actionable)
        {
            _actionable.ActionateSecondaryAction();
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        _isWaiting = true;
        yield return new WaitForSeconds(_waitingTimeBetweenActions);
        _isWaiting = false;
    }

    public void PickupLog(bool isPickup)
    {
        ArmAnimator.SetBool(_animParameterLog, isPickup);
    }
}
