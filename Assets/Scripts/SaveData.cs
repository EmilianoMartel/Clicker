using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveData
{
    static string _maxClicks_key = "maxClicks";

    private int _maxClicks = 0;

    public int maxClicks { get { return _maxClicks; } }

    public void Start()
    {
        if (PlayerPrefs.HasKey(_maxClicks_key))
            _maxClicks = PlayerPrefs.GetInt(_maxClicks_key);
        else
            _maxClicks = 0;
    }

    public bool NewRecordCheck(int value)
    {
        if (value < _maxClicks)
            return false;

        _maxClicks = value;
        PlayerPrefs.SetInt(_maxClicks_key, _maxClicks);
        PlayerPrefs.Save();
        return true;
    }
}
