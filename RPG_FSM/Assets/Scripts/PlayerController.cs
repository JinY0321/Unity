using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // PlayerInput�� Behavior : Invoke C Sharp Events �������� ������ �װ�!
    public PlayerInputs playerInput { get; private set; }
    // �� �� ������ Action Map�� ������ ����
    public PlayerInputs.PlayerActions playerActions { get; private set; }

    private void Awake()
    {
        playerInput = new PlayerInputs();
        playerActions = playerInput.Player;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}
