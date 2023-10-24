using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPickUp : MonoBehaviour
{
    [SerializeField] private string[] harvestCategories;
    public string[] HarvestCategories => harvestCategories;

    public Animator LogAnimator;
    private InventorySystem _inventory;
    private int _animParameterHit;

    private void Start()
    {
        _inventory = InventorySystem.Instance;
        _animParameterHit = Animator.StringToHash("Hit");
    }

    public void Have()
    {
        if(transform.parent = _inventory.GetComponent<Transform>())
        {
            LogAnimator.SetTrigger(_animParameterHit);
        }
    }
}
