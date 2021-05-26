using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using System;

public class AuthScript : MonoBehaviour
{

    [SerializeField]
    InputField ifEmail, ifPassword, ifDisplayName;

    [SerializeField]
    PlayFabManager playFabmanager;




    public void RegisterPlayer()
    {
        playFabmanager.LoadingMessage("Connecting server...");
        var request = new RegisterPlayFabUserRequest()
        {
            Email = ifEmail.text,
            Password = ifPassword.text,
            DisplayName = ifDisplayName.text,
            Username = ifDisplayName.text
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, Success, Failed);
    }

    private void Failed(PlayFabError err)
    {
        playFabmanager.LoadingMessage(err.ErrorMessage);
        playFabmanager.LoadingHide();
    }

    private void Success(RegisterPlayFabUserResult success)
    {
        playFabmanager.LoadingMessage("Register Succesfull");
        playFabmanager.LoadingHide();
    }

    public void LoginPlayer()
    {
        playFabmanager.LoadingMessage("Connecting server...");

        var request = new LoginWithEmailAddressRequest()
        {
            Password = ifPassword.text,
            Email = ifEmail.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, LoginSuccess, LoginFailed);
    }

    private void LoginFailed(PlayFabError err)
    {
        playFabmanager.LoadingMessage(err.ErrorMessage);
        playFabmanager.LoadingHide();
    }

    private void LoginSuccess(LoginResult success)
    {
        playFabmanager.LoadingMessage("Login Successfull");
        playFabmanager.Player_ID = success.PlayFabId;
        playFabmanager.LoadingHide();
        UnityEngine.SceneManagement.SceneManager.LoadScene("loading");
    }
}
