using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private int emptyHandAttackForce = 1;
    [SerializeField] private int emptyHandHarvestLevel = 1;

    public static InventorySystem Instance { get; private set;}

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public int GetPlayerAttackForce()
    {
        var _pickableInHand = GetComponentInChildren<PickableFunction>();

        if (!_pickableInHand) return emptyHandAttackForce;
        return _pickableInHand.AttackForce;
    }

    public int GetPlayerHarvestLevel()
    {
        var _pickableInHand = GetComponentInChildren<PickableFunction>();

        if (!_pickableInHand) return emptyHandHarvestLevel;
        return _pickableInHand.HarvestLevel;
    }

    public string[] GetPlayerHarvestCategories()
    {
        var _pickableInHand = GetComponentInChildren<PickableFunction>();

        if (!_pickableInHand) return null;
        return _pickableInHand.HarvestCategories;
    }
}
