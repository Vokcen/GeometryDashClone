using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GameState
{
    Menu,
    Game
}
public class GameManager : MonoBehaviour
{

    [SerializeField] AudioSource gameMusic;

    GameState state = GameState.Menu;


    [SerializeField] private TMP_Text attemptText;
    private int attemptIndex = 1;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

    }


    private void OnEnable()
    {
        EventManager.OnHitSpike += OnHitSpike;
    }

    private void OnDisable()
    {
        EventManager.OnHitSpike -= OnHitSpike;
    }

    private void OnHitSpike(object sender, EventArgs e)
    {
        attemptIndex++;

        UpdateAttemptText();
    }

    private void UpdateAttemptText()
    {
        attemptText.text = "Attempt  " + attemptIndex.ToString("0");
    }

    public void StartGame()
    {
        gameMusic.Play();

        state = GameState.Game;

    }


    public GameState GetState()
    {
        return state;
    }
}
