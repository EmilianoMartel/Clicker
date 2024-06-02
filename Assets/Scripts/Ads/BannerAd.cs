using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : Ads
{
    public void Show()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Load(_data.AdUnitId, options);
    }

    private void OnBannerLoaded()
    {
        Advertisement.Banner.Show(_data.AdUnitId);
    }

    private void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }
}