using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState //������ ���µ��� ��� ����
{
    public void Enter(); // ���°� ��
    public void Exit(); // ���°� ����
    public void HandleInput();
    public void Update(); // ���°� ������ ������ ���ư���
    public void PhysicsUpdate(); //�߷� ����
}

public abstract class StateMachine
{
    protected IState currentState; //���� ����

    public void ChangeState(IState state)
    {
        currentState?.Exit(); //���� state ����
        currentState = state; //���� state ����
        currentState?.Enter(); //������ ���Դ�.
    }

    public void HandleInput()
    {
        currentState?.HandleInput();
    }

    public void Update()
    {
        currentState?.Update();
    }

    public void PhysicsUpdate()
    {
        currentState?.PhysicsUpdate();
    }
}
