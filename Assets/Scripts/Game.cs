using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    public UI Ui;
    public Corgi Corgi;
    public GameTimer GameTimer;
    public BeerPlacer BeerPlacer;
    public BonePlacer BonePlacer;
    public PillPlacer PillPlacer;
    public MoonshinePlacer MoonshinePlacer;

    public Music Music;

    private bool isGameRunning = false;
    
    void Start()
    {
        Ui.HideGameOverScreen();
        Ui.ShowStartScreen();
        Music.PlayMenuMusic();
    }
    
    void Update()
    {
        Ui.ShowTime();
    }

    public bool IsPlaying()
    {
        return isGameRunning;
    }

    public void OnStartButtonClicked()
    {
        Ui.HideStartScreen();
        InitializeGame();
    }

    public void InitializeGame()
    {
        isGameRunning = true;
        GameTimer.StartTimer(10, OnTimerFinished);
        StartPlacers();
        ScoreKeeper.ResetScore();
        Ui.ResetScore();
        Corgi.Reset();
        Music.PlayGameMusic();
    }

    private void StartPlacers()
    {
        BeerPlacer.StartPlacing();
        BonePlacer.StartPlacing();
        PillPlacer.StartPlacing();
        MoonshinePlacer.StartPlacing();
    }
    
    private void StopPlacers()
    {
        BeerPlacer.StopPlacing();
        BonePlacer.StopPlacing();
        PillPlacer.StopPlacing();
        MoonshinePlacer.StopPlacing();
    }

    public void OnPlayAgainButtonClicked()
    {
        Ui.HideGameOverScreen();
        InitializeGame();
    }

    private void StartGame()
    {
        GameTimer.StartTimer(10, OnTimerFinished);
    }

    public void OnTimerFinished()
    {
        isGameRunning = false;
        Ui.ShowGameOverScreen();
        StopPlacers();
        Music.PlayMenuMusic();
    }
}
