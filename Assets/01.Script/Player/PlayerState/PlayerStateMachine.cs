using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{

    Dictionary<PlayerStateEnum, PlayerState> _stateDictionary;

    public PlayerState CurrentState { get; private set; }

    private Player _player;


    public PlayerStateMachine()
    {
        _stateDictionary = new Dictionary<PlayerStateEnum, PlayerState>();
    }

    public void InitState(PlayerStateEnum stateEnum, Player player)
    {
        _player = player;
        CurrentState = _stateDictionary[stateEnum];
        CurrentState.Enter();
    }

    public void ChangeState(PlayerStateEnum changeEnum)
    {
        CurrentState.Exit();
        CurrentState = _stateDictionary[changeEnum];
        CurrentState.Enter();
    }

    public void AddState(PlayerStateEnum stateEnum, PlayerState state)
    {
        _stateDictionary.Add(stateEnum,state);
    }

}
