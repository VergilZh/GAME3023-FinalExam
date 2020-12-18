using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManagement : MonoBehaviour
{
    public bool AutoChangeWeather;
    public float MyChangeTime;
    public float TimeSpeedUp;
    private int WeatherNum;
    private float ChangeTime;
    private Animator WeatherAnim;
    [SerializeField] Weather myWeather;
    
    [Header("Audio")]
    public AudioSource SunnyAUD;
    public AudioSource CloudyAUD;
    public AudioSource RainnyAUD;
    public AudioSource StormAUD;
    public AudioSource SnowAUD;

    enum Weather
    {
        Sunny,
        Cloudy,
        Rainy,
        Storm,
        Snow
    }
    // Start is called before the first frame update
    void Start()
    {
        WeatherAnim = GetComponent<Animator>();
        Time.timeScale = TimeSpeedUp;
        myWeather = Weather.Sunny;
        ChangeTime = MyChangeTime;
        AutoChangeWeather = false;

        SunnyAUD.Play();
        CloudyAUD.Play();
        RainnyAUD.Play();
        StormAUD.Play();
        SnowAUD.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(AutoChangeWeather == true)
        {
            ChangeTime -= Time.deltaTime;
            if(ChangeTime <= 0)
            {
                WeatherNum = Random.Range(0, 4);
                if(WeatherNum == 0)
                {
                    myWeather = Weather.Cloudy;
                }
                if (WeatherNum == 1 || WeatherNum == 3)
                {
                    myWeather = Weather.Rainy;
                }
                if (WeatherNum == 2)
                {
                    myWeather = Weather.Storm;
                }

                ChangeTime = MyChangeTime;
            }
        }
        else
        {

        }

        switch (myWeather)
        {
            case Weather.Sunny:
                WeatherAnim.SetInteger("AnimState", 0);
                WeatherNum = 0;
                break;
            case Weather.Cloudy:
                WeatherAnim.SetInteger("AnimState", 1);
                WeatherNum = 1;
                break;
            case Weather.Rainy:
                WeatherAnim.SetInteger("AnimState", 2);
                WeatherNum = 2;
                break;
            case Weather.Storm:
                WeatherAnim.SetInteger("AnimState", 3);
                WeatherNum = 3;
                break;
            case Weather.Snow:
                WeatherAnim.SetInteger("AnimState", 4);
                WeatherNum = 4;
                break;
            default:
                break;
        }
    }
}
