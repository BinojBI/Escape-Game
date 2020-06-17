using System.Collections;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject player;
    public GameObject giftbox;
    public GameObject block;
    public GameObject mainMenu;
    public GameObject howToPanel;
    public GameObject howtoplayModels;
    public AudioSource[] menuAudio;


    public void HowToPanelLoader()
    {
        menuAudio[1].Play();
        howToPanel.SetActive(true);
        mainMenu.SetActive(false);
        block.SetActive(false);
        giftbox.SetActive(false);
        player.SetActive(false);
        howtoplayModels.SetActive(true);
    }

    public void MainMenuLoader()
    {
        menuAudio[1].Play();
        howToPanel.SetActive(false);
        mainMenu.SetActive(true);
        block.SetActive(true);
        giftbox.SetActive(true);
        player.SetActive(true);
        howtoplayModels.SetActive(false);
    }

    public void ApplicationQuit()
    {
        menuAudio[1].Play();
        Application.Quit();
    }

}
