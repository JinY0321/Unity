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

        // �̵� �Է��� ���� ���� ������ ����
        if (movementDirection != Vector2.zero)
        {
            lookDirection = movementDirection; // Ű���� ������ �ٶ󺸰� ����
        }
    }
}
