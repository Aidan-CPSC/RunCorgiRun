using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    public UI Ui;
    public GameTimer GameTimer;
    
    void Start()
    {
        Ui.HideGameOverScreen();
        Ui.ShowStartScreen();
    }
    
    void Update()
    {
        Ui.ShowTime();
    }

    public void OnStartButtonClicked()
    {
        Ui.HideStartScreen();
        StartGame();
    }

    public void OnPlayAgainButtonClicked()
    {
        Ui.HideGameOverScreen();
        StartGame();
    }

    private void StartGame()
    {
        GameTimer.StartTimer(10, OnTimerFinished);
    }

    public void OnTimerFinished()
    {
        Ui.ShowGameOverScreen();
    }
}
