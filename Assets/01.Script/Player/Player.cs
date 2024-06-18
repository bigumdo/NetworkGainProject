using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
public enum PlayerStateEnum
{
    Idle,
    Run,
    Jump,
    Fall
}

public class Player : NetworkBehaviour
{

    public PlayerMovement MoveCompo { get; private set; }
    public Animator AnimCompo { get; private set; }

    public PlayerStateMachine stateMachine;

    private void Awake()
    {
        MoveCompo = GetComponent<PlayerMovement>();
        AnimCompo = GetComponentInChildren<Animator>();

        stateMachine = new PlayerStateMachine();

        stateMachine.AddState(PlayerStateEnum.Run, new PlayerRunState(this, stateMachine, "Run"));
        stateMachine.AddState(PlayerStateEnum.Idle, new PlayerIdleState(this, stateMachine, "Idle"));
        stateMachine.AddState(PlayerStateEnum.Jump, new PlayerJumpState(this, stateMachine, "Jump"));

        stateMachine.InitState(PlayerStateEnum.Idle, this);

    }

    private void Update()
    {
        stateMachine.CurrentState.Update();
    }



}
