using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public class LocalNotificationManager : MonoBehaviour
{
    private static string CHANNEL_ID = "notis01";
#if UNITY_IOS
        private void Start()
    {
        string NotiChannels_Created_Key = "NotiChannels_Created";
        if (!PlayerPrefs.HasKey(NotiChannels_Created_Key))
        {
            var group = new AndroidNotificationChannelGroup()
            {
                Id = "Main",
                Name = "Main notifications",
            };
            AndroidNotificationCenter.RegisterNotificationChannelGroup(group);
            var channel = new AndroidNotificationChannel()
            {
                Id = CHANNEL_ID,
                Name = "Default Channel",
                Importance = Importance.Default,
                Description = "Generic notifications",
                Group = "Main",
            };
            AndroidNotificationCenter.RegisterNotificationChannel(channel);

            StartCoroutine(RequestPermission());

            PlayerPrefs.SetString(NotiChannels_Created_Key, "y");
            PlayerPrefs.Save();
        }
        else
        {
            ScheduleNotis();
        }
    }

    private IEnumerator RequestPermission()
    {
        var request = new PermissionRequest();
        while (request.Status == PermissionStatus.RequestPending)
            yield return null;

        ScheduleNotis();
    }

    private void ScheduleNotis()
    {
        AndroidNotificationCenter.CancelAllScheduledNotifications();

        var notification3days = new AndroidNotification();
        notification3days.Title = "Come back i miss you  :(";
        notification3days.Text = "Can you do a new high score?";
        notification3days.FireTime = System.DateTime.Now.AddMinutes(3);

        AndroidNotificationCenter.SendNotification(notification3days, CHANNEL_ID);
    }
#elif UNITY_ANDROID
    private void Start()
    {
        string NotiChannels_Created_Key = "NotiChannels_Created";
        if (!PlayerPrefs.HasKey(NotiChannels_Created_Key))
        {
            var group = new AndroidNotificationChannelGroup()
            {
                Id = "Main",
                Name = "Main notifications",
            };
            AndroidNotificationCenter.RegisterNotificationChannelGroup(group);
            var channel = new AndroidNotificationChannel()
            {
                Id = CHANNEL_ID,
                Name = "Default Channel",
                Importance = Importance.Default,
                Description = "Generic notifications",
                Group = "Main",
            };
            AndroidNotificationCenter.RegisterNotificationChannel(channel);

            StartCoroutine(RequestPermission());

            PlayerPrefs.SetString(NotiChannels_Created_Key, "y");
            PlayerPrefs.Save();
        }
        else
        {
            ScheduleNotis();
        }
    }

    private IEnumerator RequestPermission()
    {
        var request = new PermissionRequest();
        while (request.Status == PermissionStatus.RequestPending)
            yield return null;

        ScheduleNotis();
    }

    private void ScheduleNotis()
    {
        AndroidNotificationCenter.CancelAllScheduledNotifications();

        var notification3days = new AndroidNotification();
        notification3days.Title = "Come back i miss you  :(";
        notification3days.Text = "Can you do a new high score?";
        notification3days.FireTime = System.DateTime.Now.AddMinutes(3);

        AndroidNotificationCenter.SendNotification(notification3days, CHANNEL_ID);
    }
#else
    private void Awake()
    {
        gameObject.SetActive(false);
    }
#endif
}