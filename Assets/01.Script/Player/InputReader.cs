using UnityEngine;
using static Controls;
using UnityEngine.InputSystem;
using System;

[CreateAssetMenu(fileName ="InputReader",menuName ="SO/Input/InputReader")]
public class InputReader : ScriptableObject,IPlayerActions
{
    public event Action<Vector2> MovementEvent;

    private Controls _controlAction;
    private void OnEnable()
    {
        if (_controlAction == null)
        {
            _controlAction = new Controls();
            _controlAction.Player.SetCallbacks(this); //플레이어 인풋이 발생하면 이 인스턴스를 연결해주고
        }
        _controlAction.Player.Enable();//플레이어 입력 활성화
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 vec = context.ReadValue<Vector2>();
        MovementEvent?.Invoke(vec);
    }

   
}
