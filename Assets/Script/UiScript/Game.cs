using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private ShipMover _shipMover ;
    [SerializeField] private Window _startScreen;
    [SerializeField] private Window _endGameScreen;
    [SerializeField] private ScoreCounter _scoreCounter ;

    private void OnEnable()
    {
        _startScreen.ButtonClicked += OnPlayButtonClick;
        _endGameScreen.ButtonClicked += OnRestartButtonClick;
        _ship.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.ButtonClicked -= OnPlayButtonClick;
        _endGameScreen.ButtonClicked -= OnRestartButtonClick;
        _ship.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _scoreCounter.ResetScore();
        _endGameScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _shipMover.Reset();
    }
}