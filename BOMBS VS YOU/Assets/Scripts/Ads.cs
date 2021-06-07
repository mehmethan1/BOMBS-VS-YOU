using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


public class Ads : MonoBehaviour
{
    string gameId = "4028481";
    void Start()
    {
        Advertisement.Initialize(gameId);
    }

    public void Reklam()
    {
        Advertisement.Show();
    }

    public void Restart()
    {
        int counter = PlayerPrefs.GetInt("CliclkCount", 0);
        counter++;
        if (counter % 5 == 0)
        {
            this.Reklam();
        }
        PlayerPrefs.SetInt("CliclkCount", counter);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
