using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private Timer _timer;
    [SerializeField] private AdsData[] _adsData = new AdsData[3];
    [Tooltip("This value most be between 0 to 100, 100 is for always the game was ended a ad start.")]
    [SerializeField] private int _adChances = 50;

    //Ads
    private BannerAd _banner = new();
    private InterstitialAd _interstitial = new();
    private RewardedAd _rewardedAd = new();

    private string _gameId;

    public event Action rewardEvent;

    private void OnEnable()
    {
        _timer.endTime += HandleEndGame;
    }

    private void OnDisable()
    {
        _timer.endTime -= HandleEndGame;
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

        CheckAdsData(_adsData);
    }

    private void Start()
    {
        _banner.Show();
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
                    _rewardedAd.adEnded += HandleReward;
                    break;
                default:
                    break;
            }
        }
    }

    private void CheckAdsData(AdsData[] adsDataArray)
    {
        HashSet<AdsData> seen = new HashSet<AdsData>();
        List<AdsData> duplicates = new List<AdsData>();

        foreach (AdsData ad in adsDataArray)
        {
            if (!seen.Add(ad))
            {
                duplicates.Add(ad);
            }
        }

        if (duplicates.Count > 0)
        {
            Debug.LogError($"{name}: There are duplicate types of ads, check the SO\nDisabling component.");
            enabled = false;
            return;
        }
        else
        {
            DataConverter();
        }
    }

    private void HandleReward()
    {
        rewardEvent?.Invoke();
    }

    private void HandleEndGame()
    {
        int chance = UnityEngine.Random.Range(0,100);
        if (chance < _adChances)
        {
            _interstitial.Initialize();
        }
    }

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

}
