using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToPlayerFunction : MonoBehaviour
{
    [SerializeField] private int attackForce = 1;
    [SerializeField] private int attackRange = 3;
    private Health health;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<Health>();
    }

    public void DealDamageToPlayer()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            health.Decrease(attackForce);
    }
}
