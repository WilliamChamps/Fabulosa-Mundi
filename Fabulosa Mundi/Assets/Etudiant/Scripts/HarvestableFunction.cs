using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Health))]
public class HarvestableFunction : MonoBehaviour
{
    [SerializeField] private string harvestCategory = "wood";
    [SerializeField] private int harvestLevelMin = 2;

    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    public void Harvest()
    {
        InventorySystem inventory = InventorySystem.Instance;
        if (inventory.GetPlayerHarvestLevel() >= harvestLevelMin
        && inventory.GetPlayerHarvestCategories().Contains(harvestCategory))
        {
            health.Decrease(inventory.GetPlayerAttackForce());
        }
    }
}
