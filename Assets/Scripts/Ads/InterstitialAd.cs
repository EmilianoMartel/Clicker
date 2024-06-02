using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : Ads, IUnityAdsLoadListener, IUnityAdsShowListener
{
    bool _adLoaded = false;

    internal void Initialize()
    {
        Advertisement.Load(_data.AdUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        _adLoaded = true;
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Interstitial: Error loading Ad Unit: {_data.AdUnitId} - {error.ToString()} - {message}");
    }

    public void ShowInterstitial()
    {
        if (_adLoaded)
            Advertisement.Show(_data.AdUnitId, this);
    }
    public void OnUnityAdsShowStart(string _adUnitId)
    {
        Debug.Log($"Showing Ad Unit {_data.AdUnitId}");
    }

    public void OnUnityAdsShowClick(string _adUnitId)
    {
        Debug.Log($"Clicked Ad Unit {_data.AdUnitId}");
    }

    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"Ad Unit {_data.AdUnitId} was ended");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {_data.AdUnitId}: {error.ToString()} - {message}");
    }
}