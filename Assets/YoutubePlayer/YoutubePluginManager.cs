using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoutubePluginManager : MonoBehaviour
{
    [Header("For production change to your youtube developer key")]
    public string youtubeDeveloperKey = "AIzaSyDrM5OqmYUYiinRtenT4JcDSIOZtlTZFiw";
    private string youtubeAPPDownload = "https://play.google.com/store/apps/details?id=com.google.android.youtube";
    private AndroidJavaObject activityContext = null;
    private AndroidJavaObject mycall = null;
    public static YoutubePluginManager manager;

    void Start()
    {
        manager = this;
    }

    public void _PlayYoutubeVideo(string videoId, bool backWhenVideoFinish)
    {
        AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.lightshaft.youtube.MainActivity");

        if (pluginClass != null)
            {
            Debug.Log("OKAY!!");
                activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    
                    mycall = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    mycall.Call("setContext", activityContext);
                    if (mycall.Call<bool>("PlayYoutubeVideo", videoId, backWhenVideoFinish))
                    {
                        Debug.Log("OK PLAYBACK");
                    }
                    else
                    {
                        Debug.Log("YOU DONT HAVE YOUTUBE APP INSTALLED!");
                        Application.OpenURL(youtubeAPPDownload); //Open playstore to download the youtube
                    }
                }));
            }
        
    }

    public void _PlayCardboardVideo(string videoId)
    {
        AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.lightshaft.youtube.MainActivity");
        
            if (pluginClass != null)
            {
                activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    mycall = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    mycall.Call("setContext", activityContext);
                    if (mycall.Call<bool>("PlayForCardboard", videoId))
                    {
                        Debug.Log("OK PLAYBACK");
                    }
                    else
                    {
                        Debug.Log("YOU DONT HAVE YOUTUBE APP INSTALLED!");
                        Application.OpenURL(youtubeAPPDownload); //Open playstore to download the youtube
                    }
                }));
            }
    }

    public void _PlayYoutubeVideoWithStartTime(string videoId, bool autoPlay, string time, bool lightBoxMode)
    {
        AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.lightshaft.youtube.MainActivity");

            if (pluginClass != null)
            {
                activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    mycall = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    mycall.Call("setContext", activityContext);
                    if (mycall.Call<bool>("PlayYoutubeVideoFrom", videoId, autoPlay, youtubeDeveloperKey, time, lightBoxMode))
                    {
                        Debug.Log("OK PLAYBACK");
                    }
                    else
                    {
                        Debug.Log("YOU DONT HAVE YOUTUBE APP INSTALLED!");
                        Application.OpenURL(youtubeAPPDownload); //Open playstore to download the youtube
                    }
                }));
            }
    }

    public void _OpenChannel(string channelId)
    {
        AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.lightshaft.youtube.MainActivity");

            if (pluginClass != null)
            {
                activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    mycall = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    mycall.Call("setContext", activityContext);
                    if (mycall.Call<bool>("OpenChannel", channelId))
                    {
                        Debug.Log("OK PLAYBACK");
                    }
                    else
                    {
                        Debug.Log("YOU DONT HAVE YOUTUBE APP INSTALLED!");
                        Application.OpenURL(youtubeAPPDownload); //Open playstore to download the youtube
                    }
                }));
            }
    }

    public void _OpenUser(string userId)
    {
        AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.lightshaft.youtube.MainActivity");

            if (pluginClass != null)
            {
               
                activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    mycall = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    mycall.Call("setContext", activityContext);
                    if (mycall.Call<bool>("OpenUser", userId))
                    {
                        Debug.Log("OK PLAYBACK");
                    }
                    else
                    {
                        Debug.Log("YOU DONT HAVE YOUTUBE APP INSTALLED!");
                        Application.OpenURL(youtubeAPPDownload); //Open playstore to download the youtube
                    }
                }));
            }
    }

    public void _Search(string searchText)
    {
        AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.lightshaft.youtube.MainActivity");

            if (pluginClass != null)
            {
                activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    mycall = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    mycall.Call("setContext", activityContext);
                    if (mycall.Call<bool>("OpenSearch", searchText))
                    {
                        Debug.Log("OK PLAYBACK");
                    }
                    else
                    {
                        Debug.Log("YOU DONT HAVE YOUTUBE APP INSTALLED!");
                        Application.OpenURL(youtubeAPPDownload); //Open playstore to download the youtube
                    }
                }));
            }
    }

    AndroidJavaObject unityObject;
    AndroidJavaObject androidObject;

    public void _OpenUploadSystem()
    {
        AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.lightshaft.youtube.MainActivity");

            if (pluginClass != null)
            {
                activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    mycall = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    mycall.Call("setContext", activityContext);

                    if (mycall.Call<bool>("CanOpenUpload"))
                    {
                        AndroidJavaClass unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                        unityObject = unityClass.GetStatic<AndroidJavaObject>("currentActivity");

                        AndroidJavaClass androidClass = new AndroidJavaClass("com.lightshaft.youtube.VideoPicker");
                        androidObject = androidClass.GetStatic<AndroidJavaObject>("instance");
                        androidObject.Call("Upload", unityObject);
                    }
                    else
                    {
                        Debug.Log("YOU DONT HAVE YOUTUBE APP INSTALLED!");
                        Application.OpenURL(youtubeAPPDownload); //Open playstore to download the youtube
                    }
                }));
            }
        
    }

    public void _OpenPlaylist(string playlistID)
    {
        AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.lightshaft.youtube.MainActivity");

            if (pluginClass != null)
            {
                activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    mycall = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    mycall.Call("setContext", activityContext);
                    if (mycall.Call<bool>("OpenPlaylist", playlistID))
                    {
                        Debug.Log("OK PLAYBACK");
                    }
                    else
                    {
                        Debug.Log("YOU DONT HAVE YOUTUBE APP INSTALLED!");
                        Application.OpenURL(youtubeAPPDownload); //Open playstore to download the youtube
                    }
                }));
            }
    }

    public void _PlayPlaylist(string playlistID)
    {
        AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.lightshaft.youtube.MainActivity");

            if (pluginClass != null)
            {
                activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    mycall = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    mycall.Call("setContext", activityContext);
                    if (mycall.Call<bool>("PlayPlaylist", playlistID))
                    {
                        Debug.Log("OK PLAYBACK");
                    }
                    else
                    {
                        Debug.Log("YOU DONT HAVE YOUTUBE APP INSTALLED!");
                        Application.OpenURL("youtubeAPPDownload"); //Open playstore to download the youtube
                    }
                }));
            }
    }

    public void _PlayCustomVideolist(string[] videos, int startIndex, string time, bool autoplay, bool lightBoxMode )
    {
        AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.lightshaft.youtube.MainActivity");

            if (pluginClass != null)
            {
                activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    mycall = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    mycall.Call("setContext", activityContext);
                    if (mycall.Call<bool>("PlayCustomVideoList", videos, youtubeDeveloperKey, startIndex, time, autoplay, lightBoxMode))
                    {
                        Debug.Log("OK PLAYBACK");
                    }
                    else
                    {
                        Debug.Log("YOU DONT HAVE YOUTUBE APP INSTALLED!");
                        Application.OpenURL(youtubeAPPDownload); //Open playstore to download the youtube
                    }
                }));
            }
    }

    public void _playPlaylistWithCustomActions(string playlistID, int startIndex, string time, bool autoplay, bool lightBoxMode)
    {
        AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.lightshaft.youtube.MainActivity");

            if (pluginClass != null)
            {
               
                activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    mycall = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    mycall.Call("setContext", activityContext);
                    if (mycall.Call<bool>("PlayCustomPlaylist", playlistID, youtubeDeveloperKey, startIndex, time, autoplay, lightBoxMode))
                    {
                        Debug.Log("OK PLAYBACK");
                    }
                    else
                    {
                        Debug.Log("YOU DONT HAVE YOUTUBE APP INSTALLED!");
                        Application.OpenURL(youtubeAPPDownload); //Open playstore to download the youtube
                    }
                }));
            }
    }
}
