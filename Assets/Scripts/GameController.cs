using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    private Player player;
    public GameObject resultWindow;
    public float currentTime;
    public bool getvalue = false;
    public Text runDistanceText;
    public float highScore = 0;
    public Text highScoreText;
    public Slider sheildSlider;
    public bool sheildActiveTime = false;
    public GameObject sheild;
    public AudioSource[] gameSounds;
    private bool sheildSoundOn = false;
    public TextMeshProUGUI distanceText;
    private float distance;
    public GameObject distanceCube;

    private void Start()
    {
        player = GameObject.FindWithTag("Respawn").GetComponent<Player>();
        distance = 0;
    }

    private void Update()
    {
        if (!player.died)
        {
            distanceCube.transform.position -= new Vector3(0, 0, GameMgr.movementSpeed * Time.deltaTime);
        }

        distance = Mathf.Abs(distanceCube.transform.position.z - 0f);
        SpeedCalculator();


        if (player.died)
        {
            resultWindow.SetActive(true);
            GameMgr.movementSpeed = 5f;
        }

        distanceText.text = distance.ToString("F1") + " M";
        

        if (player.died && !getvalue)
        {

            if (distance> PlayerPrefs.GetFloat("highscore"))
            {
                highScore = distance;
                PlayerPrefs.SetFloat("highscore", highScore);
            }

            highScoreText.text = PlayerPrefs.GetFloat("highscore").ToString("F1") + " m";
            
            runDistanceText.text = distance.ToString("F1") + " m";
            getvalue = true;
        }

        sheildController();
    }

    public void sheildController()
    {
        if (player.sheildOn)
        {
            sheildSlider.value = 500;
            player.sheildOn = false;

        }

        if (sheildSlider.value>0)
        {
            player.sheildParticle.SetActive(true);
            sheildActiveTime = true;
            sheild.SetActive(true);
            if (!sheildSoundOn)
            {
                PlaySheildSound();
            }

        }

        if (sheildSlider.value == 0)
        {
            player.sheildParticle.SetActive(false);
            sheildActiveTime = false;
            sheild.SetActive(false);
            gameSounds[1].Stop();
            sheildSoundOn = false;
        }

        sheildSlider.value -= 1;
    }
    public void PlayAgain(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        resultWindow.SetActive(false);

    }

    public void BacktoMenu(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        resultWindow.SetActive(false);
    }

    public void PlaySheildSound()
    {
        gameSounds[1].Play();
        sheildSoundOn = true;
    }

    public void SpeedCalculator()
    {
        if (distance >= 0f && distance <= 100f)
        {
            GameMgr.movementSpeed = 6f;
        }
        else if (distance > 100f && distance <= 500f)
        {
            GameMgr.movementSpeed = 7f;
        }
       else if (distance > 500f && distance <= 1000f)
        {
            GameMgr.movementSpeed = 9f;
        }
        else if (distance > 1000f && distance <= 1500f)
        {
            GameMgr.movementSpeed = 11f;
        }
        else if (distance > 1500f && distance <= 2000f)
        {
            GameMgr.movementSpeed = 13f;
        }
        else if (distance > 2000f && distance <= 2500f)
        {
            GameMgr.movementSpeed = 15f;
        }
        else if (distance > 2500f)
        {
            GameMgr.movementSpeed = 17f;
        }
    }
}
