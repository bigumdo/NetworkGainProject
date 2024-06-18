using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class PlayerState
{

    protected Player _player;
    protected PlayerStateMachine _stateMachine;

    protected int _animHash;
    
    public PlayerState(Player player,PlayerStateMachine stateMachine, string anim)
    {
        _player = player;
        _stateMachine = stateMachine;
        _animHash = Animator.StringToHash(anim);
    }

    public virtual void Enter()
    {
        _player.AnimCompo.SetBool(_animHash, true);
    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {
        _player.AnimCompo.SetBool(_animHash, false);

    }


}
