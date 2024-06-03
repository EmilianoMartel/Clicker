using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveData
{
    static string maxClicks_key = "maxClicks";

    private int maxClicks = 100;

    public void Start()
    {
        if (PlayerPrefs.HasKey(maxClicks_key))
            maxClicks = PlayerPrefs.GetInt(maxClicks_key);
        else
            maxClicks = 0;
    }

    public bool NewRecordCheck(int value)
    {
        if (value < maxClicks)
            return false;

        maxClicks = value;
        PlayerPrefs.SetInt(maxClicks_key, maxClicks);
        PlayerPrefs.Save();
        return true;
    }
}
