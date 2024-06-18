using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, string anim) : base(player, stateMachine, anim)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.MoveCompo._inputReader.OnJumpEvent += HandleJumpEvent;
    }


    public override void Update()
    {
        base.Update();
        
    }
    public override void Exit()
    {
        base.Exit();
        _player.MoveCompo._inputReader.OnJumpEvent += HandleJumpEvent;
    }

    private void HandleJumpEvent()
    {
        throw new NotImplementedException();
    }
}
