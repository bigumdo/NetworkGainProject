using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerGroundState
{
    public PlayerRunState(Player player, PlayerStateMachine stateMachine, string anim) : base(player, stateMachine, anim)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (Mathf.Abs(_player.MoveCompo.XMove) == 0)
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
    }
}
