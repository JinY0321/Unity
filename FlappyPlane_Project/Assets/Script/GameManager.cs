using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager; //자기 자신을 참조할 수 있는 스태틱 변수

    public static GameManager Instance
    {
        get { return gameManager; } //자기 자신을 참조하는 스태틱 변수를 외부로 가져갈 수 있는 프로퍼티
    }

    private int currentScore = 0;

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this; //싱글턴 패턴을 제작할 때 사용, 가장 최초의 객체 설정.
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //씬을 다시 켜는 작업
    }

    public void AddScore(int score) //점수 추가 하는 로직.
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }

}