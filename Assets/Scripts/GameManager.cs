using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ClickCounter _counter;
    private int _clickCount = 0;
    private bool _startedGame = false;

    private void HandleClickCounter()
    {
        if (!_startedGame)
        {
            StartGame();
            return;
        }

        _clickCount++;
    }

    private void StartGame()
    {
        _startedGame = true;
    }
}
