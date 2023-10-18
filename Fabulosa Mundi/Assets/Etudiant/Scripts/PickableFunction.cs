using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PickableFunction : MonoBehaviour
{
    [SerializeField] private Vector3 pickupPosition;
    [SerializeField] private Quaternion pickupRotation;
    [SerializeField] private Vector3 pickupScale;
    [SerializeField] private UnityEvent onPickedUp;
    [SerializeField] private UnityEvent onDrop;

    private InventorySystem _inventory;
    private Rigidbody _rigidbody;

    [SerializeField] private int attackForce = 3;
    public int AttackForce => attackForce;

    [SerializeField] private string[] harvestCategories;
    public string[] HarvestCategories => harvestCategories;

    [SerializeField] private int harvestLevel = 3;
    public int HarvestLevel => harvestLevel;

    private void Start()
    {
        _inventory = InventorySystem.Instance;
        _rigidbody = GetComponent<Rigidbody>();
    }

    [ContextMenu("Ramasser")]
    public void Pickup()
    {
        onPickedUp.Invoke();

        transform.parent = _inventory.GetComponent<Transform>();
        transform.localRotation = pickupRotation;
        transform.localPosition = pickupPosition;
        transform.localScale = pickupScale;

        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;

        foreach (var col in GetComponents<Collider>())
            col.enabled = false;

        var detect = GameObject.FindGameObjectWithTag("CameraFPS").GetComponent<DetectAndActionate>();

        detect.PickupLog(Array.IndexOf(harvestCategories, "log") >= 0);
    }
    public void Drop()
    {
        onDrop.Invoke();

        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;

        foreach (var col in GetComponents<Collider>())
            col.enabled = true;

        transform.parent = null;

        var detect = GameObject.FindGameObjectWithTag("CameraFPS").GetComponent<DetectAndActionate>();

        detect.PickupLog(false);
    }
}
