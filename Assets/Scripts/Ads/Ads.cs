using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ads
{
    protected AdsData _data;

    public AdsData Data { set { _data = value; } }
    public AdType Type { get { return _data.AdType; } }
}