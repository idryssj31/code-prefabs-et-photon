using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class NewsScript : MonoBehaviour
{
    private void Awake()
    {
        var request = new GetTitleNewsRequest();
        PlayFabClientAPI.GetTitleNews(request, SuccessTitleNews, FailedTitleNews);
    }

    private void FailedTitleNews(PlayFabError err)
    {
        GetComponent<Text>().text = "Bienvenue....";
    }

    private void SuccessTitleNews(GetTitleNewsResult result)
    {
        foreach( var item in result.News)
        {
            GetComponent<Text>().text = item.Timestamp + " " + item.Title + ":" + item.Body;
            Debug.Log(item.Title + ":" + item.Body);
        }
    }


}
