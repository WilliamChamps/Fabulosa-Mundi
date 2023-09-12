using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StudioXP.Scripts.Events;

public class InputsController : MonoBehaviour
{
    [SerializeField] private InputEvent[] inputs;
    
    void Update()
    {
        foreach(var input in inputs)
            input.Update();
    }
}
