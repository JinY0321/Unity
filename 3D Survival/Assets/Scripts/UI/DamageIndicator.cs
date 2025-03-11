using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Image image;
    public float flashSpeed;

    private Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.Player.condition.onTakeDamage += Flash;
    }

    public void Flash()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        image.enabled = true;
        image.color = new Color(1f, 100f / 255f, 100f / 255f);
        coroutine = StartCoroutine(FadeAway());
    }
    private IEnumerator FadeAway() //코루틴 사용, 메인에 있는 작업 일시 정지, 코루틴 작업 수행 후 메인 작업 실행.
    {
        float startAlpha = 0.3f;
        float a = startAlpha;

        while (a > 0)
        {
            a-=(startAlpha/flashSpeed)*Time.deltaTime;
            image.color = new Color(1f, 100f / 255f, 100f / 255f, a);
            yield return null;
        }

        image.enabled = false;
    }
}
