using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndActionate : MonoBehaviour
{
    [SerializeField] private float reach = 3;
    [SerializeField] private LayerMask layers;
    private RaycastHit _hit;
    private Actionable _objectLookedAt;

    void Update()
    {
        DetectActionable();
    }

    private void DetectActionable()
    {
        _objectLookedAt = null;
        if (Physics.Raycast(transform.position, transform.forward, out _hit, reach, layers))
            _objectLookedAt = _hit.transform.GetComponent<Actionable>();

        Debug.Log(_objectLookedAt);
    }
}
