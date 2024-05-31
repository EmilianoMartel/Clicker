using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private ClickCounter _counter;
    [SerializeField] private Timer _timer;
    [SerializeField] private TMPro.TMP_Text _actualClicksText;
    [SerializeField] private TMPro.TMP_Text _currentTimeText;

    private void OnEnable()
    {
        _counter.actualCount += HandleClickAmount;
        _timer.actualTime += UpdateTimerText;
    }

    private void OnDisable()
    {
        _counter.actualCount -= HandleClickAmount;
        _timer.actualTime -= UpdateTimerText;
    }

    private void HandleClickAmount(int count)
    {
        _actualClicksText.text = count.ToString() + " Clicks";
    }

    private void UpdateTimerText(float currentTime)
    {
        int seconds = Mathf.FloorToInt(currentTime);
        int miliSeconds = Mathf.FloorToInt((currentTime - seconds) * 1000);
        _currentTimeText.text = string.Format("{0:00}:{1:000}", seconds, miliSeconds);
    }
}