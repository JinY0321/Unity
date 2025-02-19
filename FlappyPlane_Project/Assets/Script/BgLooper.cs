using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BgLooper : MonoBehaviour
{
    public int obestacleCount = 0;
    public int numBgCount = 5;
    public Vector3 obstacleLastPosition = Vector3.zero;

    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>(); //게임 오브젝트 클래스 사용.
        obstacleLastPosition = obstacles[0].transform.position;
        obestacleCount = obstacles.Length;

        for (int i = 0; i < obestacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obestacleCount);
        } //랜덤 배치
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("BackGround")) //현재 충돌한 오브젝트의 태그 확인
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x; //백그라운드 태그를 가진 오브젝트는 박스 콜라이더를 달아놓았기 때문에 캐스팅 해야함.
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obestacleCount);
        }
    }
}