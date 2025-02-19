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

    GameManager gameManager; //���ӸŴ��� �߰�.

    public void Start() //���� �Ŵ����� Awake ����ϹǷ� start���.
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

    private void OnTriggerExit2D(Collider2D other) //������ ������ �浹x, ��ֹ� ��ü�� �ڽ� �ݶ��̴��� ��� �� ������ �߰� �ȴ�.
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
            gameManager.AddScore(1); //���� �Ŵ������� ������ �߰��Ǵ� �޼��带 �̹� �����س����Ƿ� �ҷ��ͼ� ����Ѵ�.
    }

}