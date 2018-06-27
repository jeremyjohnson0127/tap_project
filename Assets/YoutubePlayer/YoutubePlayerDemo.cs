using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YoutubePlayerDemo : MonoBehaviour {

    private AndroidJavaObject activityContext = null;
    private AndroidJavaObject mycall = null;

    public string[] demoVideoList;
    

    //START DEMO FUNCTIONS YOU CAN USE IN THE WAY YOU WANT
    public void PlayDemoVideoWithBackOnFinish(string vID)
    {
        PlayYoutubeVideo(vID, true);
    }

    public void PlayDemoVideoWithoutBackOnFinish(string vID)
    {
        PlayYoutubeVideo(vID, false);
    }

    public void PlayDemo360Video(string vID)
    {
        PlayYoutubeVideo(vID, true);
    }

    public void PlayDemo360VideoWithVR(string vID)
    {
        PlayCardboard(vID);
    }

    public void PlayDemoLiveVideo(string vID) //Dont work on emulator
    {
        PlayYoutubeVideo(vID, true);
    }
    
    public void PlayDemoYoutubeVideoWithCustomStart(string vID)
    {
        PlayYoutubeVideoWithStartTime(vID, true,"03:06",false);
    }

    public void PlayYoutubeWithLightBox(string vID)
    {
        PlayYoutubeVideoWithStartTime(vID, true, "00:00", true);
    }


    public void PlayDemoYoutubeVideoWithCustomStartWithLightBoxMode(string vID)
    {
        PlayYoutubeVideoWithStartTime(vID, true, "03:06", true);
    }

    public void OpenDemoChannel(string channelID)
    {
        OpenChannel(channelID);
    }

    public void OpenDemoUser(string userID)
    {
        OpenUser(userID);
    }

    public void OpenDemoSearch(string searchSTR)
    {
        OpenSearch(searchSTR);
    }

    public void OpenDemoPlaylist(string playlistID)
    {
        OpenPlaylist(playlistID);
    }

    public void PlayDemoPlaylist(string playlistID)
    {
        PlayPlaylist(playlistID);
    }

    public void PlayDemoCustomPlaylist(string playlistID)
    {
        PlayCustomPlaylist(playlistID, 4, "00:00", true, false);
    }

    public void PlayDemoCustomVideoList()
    {
        PlayCustomVideoList(demoVideoList,1,"00:00",true,false);
    }


    public void BackToHome()
    {
        SceneManager.LoadScene("menu");
    }

    //FINISHED THE DEMO FUNCTIONS


    /*SIMPLIFIED FUNCTIONS YOU CAN SEE THE WHOLE FUNCTION IN THE YoutubePluginManager class, used this functions bellow to show a 
    simplified version with not much hard code like in the YoutubePluginManager class.*/


    //Simple playback
    private void PlayYoutubeVideo(string videoId, bool backWhenVideoFinish)
    {
        YoutubePluginManager.manager._PlayYoutubeVideo(videoId, backWhenVideoFinish);
    }

    //Start at desired time of the video you can type the time like this (02:30) (00:30), !important only will works if use this pattern (00:00) if something goes wrong with time will play from start of the video etc...
    private void PlayYoutubeVideoWithStartTime(string videoId, bool autoPlay, string time, bool lightBoxMode)
    {
        Debug.Log("Tried!");
        YoutubePluginManager.manager._PlayYoutubeVideoWithStartTime(videoId,autoPlay,time,lightBoxMode);
    }

    //Open a channel from youtube
    private void OpenChannel(string channelId)
    {
        YoutubePluginManager.manager._OpenChannel(channelId);
    }

    //Open User account from youtuber
    private void OpenUser(string userId)
    {
        YoutubePluginManager.manager._OpenUser(userId);
    }

    //Open search system from youtube
    private void OpenSearch(string searchText)
    {
        YoutubePluginManager.manager._Search(searchText);
    }

    //Call upload system
    public void Upload()
    {
        YoutubePluginManager.manager._OpenUploadSystem();
    }

    //This open the playslist (don't play auto use PlayPlaylist instead)
    private void OpenPlaylist(string playlistID)
    {
        YoutubePluginManager.manager._OpenPlaylist(playlistID);
    }

    //This start a playback of a playlist
    private void PlayPlaylist(string playlistID)
    {
        YoutubePluginManager.manager._PlayPlaylist(playlistID);
    }

    //With this you can play a playlist with custom conditions, example: you can start playing from the 3º video of a playlist and can set the time of the video.
    private void PlayCustomPlaylist(string playlistID, int startIndex, string time, bool autoplay, bool lightBoxMode)
    {
        YoutubePluginManager.manager._playPlaylistWithCustomActions(playlistID, startIndex, time, autoplay, lightBoxMode);
    }

    //Using this you can play a custom video list using the video id of the videos that you want to use.
    private void PlayCustomVideoList(string[] videos, int startIndex, string time, bool autoplay, bool lightBoxMode)
    {
        YoutubePluginManager.manager._PlayCustomVideolist(videos, startIndex, time, autoplay, lightBoxMode);
    }

    //Play with option to enable cardboard (youtube dont provide a way to start direct a cardboardVideo, then we need to use this method.
    private void PlayCardboard(string videoId)
    {
        YoutubePluginManager.manager._PlayCardboardVideo(videoId);
    }

}
