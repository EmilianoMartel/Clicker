using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private ClickCounter _clicker;
    [SerializeField] private GameObject _finalPanel;

    private SaveData _saveData = new();

    private void OnEnable()
    {
        _timer.endTime += HandleEndTime;
        _clicker.finalCount += HandleFinalScore;
    }

    private void OnDisable()
    {
        _timer.endTime -= HandleEndTime;
        _clicker.finalCount -= HandleFinalScore;
    }

    private void Awake()
    {
        _saveData.Start();
    }

    private void HandleEndTime()
    {
        _finalPanel.SetActive(true);
    }

    private void HandleFinalScore(int score)
    {
        if (_saveData.NewRecordCheck(score))
            Debug.Log("sese");
    }
}