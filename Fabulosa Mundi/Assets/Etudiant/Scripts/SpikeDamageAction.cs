using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamageAction : MonoBehaviour
{
    [SerializeField] private int attackForce = 1;

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health)
            health.Decrease(attackForce);
    }
}
