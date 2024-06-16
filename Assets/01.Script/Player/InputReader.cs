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
            _controlAction.Player.SetCallbacks(this); //�÷��̾� ��ǲ�� �߻��ϸ� �� �ν��Ͻ��� �������ְ�
        }
        _controlAction.Player.Enable();//�÷��̾� �Է� Ȱ��ȭ
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 vec = context.ReadValue<Vector2>();
        MovementEvent?.Invoke(vec);
    }

   
}
