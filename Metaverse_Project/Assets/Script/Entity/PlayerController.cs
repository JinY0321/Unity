using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        // 이동 입력이 있을 때만 방향을 변경
        if (movementDirection != Vector2.zero)
        {
            lookDirection = movementDirection; // 키보드 방향을 바라보게 설정
        }
    }
}
