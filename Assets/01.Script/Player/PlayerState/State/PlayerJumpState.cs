using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerGroundState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string anim) : base(player, stateMachine, anim)
    {
    }

}
