using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; //플레이어
    float offsetX;

    void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x;
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position; //내 위치
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}
