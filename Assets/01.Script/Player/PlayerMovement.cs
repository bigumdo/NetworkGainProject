using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    [Header("Data")]
    public InputReader _inputReader;
    [SerializeField] private Transform _groundCheckTrm;
    [SerializeField] private Vector3 _groundCheckSize;
    [SerializeField] private LayerMask _groundLayer;


    [Header("Settings")]
    [SerializeField] private float _movementSpeed = 4f; //이동속도

    public bool IsGround { get; private set; }
    public float XMove { get; private set; }

    private Vector2 _movementInput;
    private Rigidbody2D _rigidbody;
    private Player _player;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
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
        XMove = _movementInput.x;
    }

    private void FixedUpdate()
    {
 
        if (!IsOwner) return; //오너가 아니면 리턴
        float xVelocity = XMove * _movementSpeed;
        _rigidbody.velocity = new Vector2(xVelocity, _rigidbody.velocity.y);
        CheckGround();
    }

    public void CheckGround()
    {
        Collider2D collider = Physics2D.OverlapBox(_groundCheckTrm.position, _groundCheckSize, 0, _groundLayer);
        IsGround = collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_groundCheckTrm.position, _groundCheckSize);
    }

}
