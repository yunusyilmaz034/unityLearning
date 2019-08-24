using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class loıginScript : MonoBehaviour
{
    public Text message;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onClick()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "144";
        }
        var req = new LoginWithCustomIDRequest { CustomId = "Sample Id1", CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(req, onSuccess, onFailure);
    }
    private void onSuccess (LoginResult result)
    {
        message.text = "Giriş İzni Verildi. Go Go Go ..."; ;
    }
    private void onFailure(PlayFabError error)
    {
        message.text = "Hata: " + error.GenerateErrorReport();
    }
}
  