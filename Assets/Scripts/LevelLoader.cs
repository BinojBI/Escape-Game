using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    private AudioSource playSound;

    private void Start()
    {
        playSound = GetComponent<AudioSource>();
    }
    public void LoadLevel(int sceneIndex)
    {
        playSound.Play();
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    public void LoadFacebook(int sceneIndex)
    {
        playSound.Play();
        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
