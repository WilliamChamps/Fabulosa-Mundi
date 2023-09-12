using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISenses : MonoBehaviour
{
    [SerializeField] private float seeRange = 30f;
    [SerializeField] private float seeFov = 0.3f;
    [SerializeField] private float smellRange = 10f;

    public bool DoEntitySeeTarget(GameObject target)
    {
        Vector3 targetDirection = target.transform.position - transform.position;

        float dotProduct = Vector3.Dot(targetDirection.normalized, transform.forward);

        if (dotProduct < seeFov)
        {
            return false;
        }

        return Vector3.Distance(target.transform.position, transform.position) <= seeRange;
    }

    public bool DoEntitySmellTarget(GameObject target)
    {
        return Vector3.Distance(target.transform.position, transform.position) <= smellRange;
    }
}
