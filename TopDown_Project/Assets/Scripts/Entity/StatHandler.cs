using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [Range(1, 100)][SerializeField] private int health = 10;
    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, 100); //0부터 100까지만 사용 할 수 잇도록 제한.
    }

    [Range(1f, 20f)][SerializeField] private float speed = 3; //스피드 기본 값 3
    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20); //0에서 20까지 사용 할 수 있도록.
    }
}