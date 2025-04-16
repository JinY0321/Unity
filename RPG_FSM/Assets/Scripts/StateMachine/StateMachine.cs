using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState //각각의 상태들이 상속 받음
{
    public void Enter(); // 상태가 들어감
    public void Exit(); // 상태가 나옴
    public void HandleInput();
    public void Update(); // 상태가 나오기 전까지 돌아가는
    public void PhysicsUpdate(); //중력 관련
}

public abstract class StateMachine
{
    protected IState currentState; //현재 상태

    public void ChangeState(IState state)
    {
        currentState?.Exit(); //이전 state 종료
        currentState = state; //현재 state 설정
        currentState?.Enter(); //설정이 들어왔다.
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
