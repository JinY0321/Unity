using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //textMeshPro�� ������ ��ü�� �۾��� �����ϴ�.
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

        restartText.gameObject.SetActive(false); //ó������ ����ŸƮ �� �ʿ� �����Ƿ� false.
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true); //����ŸƮ �ؽ�Ʈ �ѱ�
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}