using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{

    public float curValue; //현재 값
    public float startValue;
    public float maxValue; //최댓값
    public float passiveValue;
    public Image uiBar; //using UnityEngine.UI;

    // Start is called before the first frame update
    void Start()
    {
        curValue = startValue; //시작했을때 현재 값.
    }

    // Update is called once per frame
    void Update()
    {
        //ui 업데이트
        uiBar.fillAmount = GetPercentage(); //현재 체력을 구해서 ui바를 채우도록 해주는 코드. fillAmount는 최댓값이 1.
    }

    float GetPercentage() // 현재 체력을 구하는.
    {
        return curValue / maxValue;
    }

    public void Add(float value)//값들을 업데이트 해줄 것. 외부에서 add를 호출하여 사용 curValue 증가.
    {
        curValue = Mathf.Min(curValue + value, maxValue); //두개의 매개변수를 받아서 더 작은 값을 넣어줌.
    }

    public void Subtract(float value) //값들을 업데이트. curValue 감소.
    {
        curValue = Mathf.Max(curValue - value, 0); //위랑 반대로 생각하면 됨.
    }
}
