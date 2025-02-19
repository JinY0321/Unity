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
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>(); //���� ������Ʈ Ŭ���� ���.
        obstacleLastPosition = obstacles[0].transform.position;
        obestacleCount = obstacles.Length;

        for (int i = 0; i < obestacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obestacleCount);
        } //���� ��ġ
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("BackGround")) //���� �浹�� ������Ʈ�� �±� Ȯ��
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x; //��׶��� �±׸� ���� ������Ʈ�� �ڽ� �ݶ��̴��� �޾Ƴ��ұ� ������ ĳ���� �ؾ���.
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