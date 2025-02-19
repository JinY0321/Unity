using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    GameManager gameManager; //게임매니저 추가.

    public void Start() //게임 매니저에 Awake 사용하므로 start사용.
    {
        gameManager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D other) //실제로 물리적 충돌x, 장애물 객체가 박스 콜라이더를 벗어날 때 점수가 추가 된다.
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
            gameManager.AddScore(1); //게임 매니저에서 점수가 추가되는 메서드를 이미 제작해놨으므로 불러와서 사용한다.
    }

}