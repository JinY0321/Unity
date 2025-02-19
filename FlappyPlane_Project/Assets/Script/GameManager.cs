using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager; //�ڱ� �ڽ��� ������ �� �ִ� ����ƽ ����

    public static GameManager Instance
    {
        get { return gameManager; } //�ڱ� �ڽ��� �����ϴ� ����ƽ ������ �ܺη� ������ �� �ִ� ������Ƽ
    }

    private int currentScore = 0;

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this; //�̱��� ������ ������ �� ���, ���� ������ ��ü ����.
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //���� �ٽ� �Ѵ� �۾�
    }

    public void AddScore(int score) //���� �߰� �ϴ� ����.
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }

}