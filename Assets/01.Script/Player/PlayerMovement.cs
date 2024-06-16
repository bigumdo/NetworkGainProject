using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    [Header("Data")]
    [SerializeField] private InputReader _inputReader;

    private Rigidbody2D _rigidbody;

    [Header("Settings")]
    [SerializeField] private float _movementSpeed = 4f; //이동속도

    private Vector2 _movementInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;
        _inputReader.MovementEvent += HandleMovement;
    }

    public override void OnNetworkDespawn()
    {

        if (!IsOwner) return;
        _inputReader.MovementEvent -= HandleMovement;
    }

    private void HandleMovement(Vector2 movement)
    {
        _movementInput = movement;
    }

    private void FixedUpdate()
    {
 
        if (!IsOwner) return; //오너가 아니면 리턴

        _rigidbody.velocity = _movementInput * _movementSpeed;
        //Debug.Log(_rigidbody.velocity);

    }

}
