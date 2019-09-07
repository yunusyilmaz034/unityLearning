using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class weatherScript : MonoBehaviour
{
    //public Text message;
    public Text cityName;
    public Text temp;
   /* public Text pressure;
    public Text humidity;
    public Text weatherStatus; //weatherForceCast
    public Image bgImage;
    public Image weatherStatus_Icon;
    */
    private string URL = "http://api.openweathermap.org/data/2.5/weather?q=Istanbul,tr&units=metric&appid=";
    private string APIKEY = "7e58b5f94bdf4a304e5c8c1605b07398";
    private WeatherModel w;
    private WWW www = null;
    private string key;
    private string value;

    // Start is called before the first frame update
    void Start()
    {
        w = new WeatherModel();
        URL = URL + APIKEY;
        StartCoroutine("callWeatherApi");
    }
    IEnumerator callWeatherApi()
    {
        www = new WWW(URL);
        yield return www;
        JSONObject json = new JSONObject(www.text);
        accessData(json);
        fillField();
    }
    void accessData(JSONObject obj)
    {
        switch (obj.type)
        {
            case JSONObject.Type.OBJECT:
                for (int i = 0; i < obj.list.Count; i++)
                {
                    string key = (string)obj.keys[i];
                    JSONObject j = (JSONObject)obj.list[i];
                    Debug.Log(key);
                    this.key = key;
                    accessData(j);
                }
                break;
            case JSONObject.Type.ARRAY:
                foreach (JSONObject j in obj.list)
                {
                    accessData(j);
                }
                break;
            case JSONObject.Type.STRING:
                Debug.Log(obj.str);
                if (key.Equals("name"))
                {
                    cityName.text = obj.str;
                }
                break;
            case JSONObject.Type.NUMBER:
                Debug.Log(obj.n);
                if (key.Equals("temp"))
                {
                    string str = obj.n.ToString();
                    str = str.Insert(2, ".");
                    temp.text = str + "°C";
                }
                break;
            case JSONObject.Type.BOOL:
                Debug.Log(obj.b);
                break;
            case JSONObject.Type.NULL:
                Debug.Log("NULL");
                break;

        }
    }
    private void fillField()
    {

    }
}
