using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //textMeshPro로 생성한 객체의 글씨를 선택하는.
    public TextMeshProUGUI restartText;

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        restartText.gameObject.SetActive(false); //처음에는 리스타트 뜰 필요 없으므로 false.
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true); //리스타트 텍스트 켜기
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}