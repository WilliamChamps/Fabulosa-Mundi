using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgressiveDirector : MonoBehaviour
{
    private GameObject _player;
    private AIStateChasing _aiStateChasing;
    private AIStateWandering _aiStateWandering;
    private AISenses _aiSenses;

    void Awake()
    {
        _aiStateChasing = GetComponent<AIStateChasing>();
        _aiStateWandering = GetComponent<AIStateWandering>();
        _aiSenses = GetComponent<AISenses>();
    }

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        bool playerSpotted = _aiSenses.DoEntitySeeTarget(_player)|| _aiSenses.DoEntitySmellTarget(_player);

        if(playerSpotted)
        {
            _aiStateChasing.StateUpdate(_player.transform.position);
            return;
        }

        _aiStateWandering.StateUpdate();
    }
}
