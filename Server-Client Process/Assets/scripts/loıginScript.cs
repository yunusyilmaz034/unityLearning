using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.Networking;

public class loıginScript : MonoBehaviour
{
    public Text message;
    public Text response;
    private string URL = "http://api.openweathermap.org/data/2.5/weather?q=Istanbul,tr&appid=";
    private string APIKEY = "7e58b5f94bdf4a304e5c8c1605b07398";

    // Start is called before the first frame update
    void Start()
    {
        URL = URL + APIKEY;
        StartCoroutine("callWeatherApi");
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
    IEnumerator callWeatherApi()
    {
        // WWWForm form1 = new WWWForm();

        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log(": Error: " + request.error);
            }
            response.text = request.downloadHandler.text;
        }
        
    }
}
  