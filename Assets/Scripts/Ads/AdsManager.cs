using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private AdsData[] _adsData = new AdsData[3];
    private BannerAd _banner = new();
    private InterstitialAd _interstitial = new();
    private RewardedAd _rewardedAd = new();

    private string _gameId;

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        _banner.Show();
        _interstitial.Initialize();
        _rewardedAd.Initialize();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    private void Awake()
    {
#if UNITY_IOS
        _gameId = "5629781";
#elif UNITY_ANDROID
        _gameId = "5629780";
#elif UNITY_EDITOR
        _gameId = "5629780";
#endif
    
        if(!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, true, this);
        }

        DataConverter();
    }
    
    private void DataConverter()
    {
        for (int i = 0; i < _adsData.Length; i++)
        {
            switch (_adsData[i].AdType)
            {
                case AdType.Banner:
                    _banner.Data = _adsData[i];
                    break;
                case AdType.Interstitial:
                    _interstitial.Data = _adsData[i];
                    break;
                case AdType.Rewarded:
                    _rewardedAd.Data = _adsData[i];
                    break;
                default:
                    break;
            }
        }
    }

    private void CheckAdsData()
    {
        for (int i = 0; i < _adsData.Length; i++)
        {
            switch (_adsData[i].AdType)
            {
                case AdType.Banner:
                    _banner.Data = _adsData[i];
                    break;
                case AdType.Interstitial:
                    _interstitial.Data = _adsData[i];
                    break;
                case AdType.Rewarded:
                    _rewardedAd.Data = _adsData[i];
                    break;
                default:
                    break;
            }
        }
    }
}
