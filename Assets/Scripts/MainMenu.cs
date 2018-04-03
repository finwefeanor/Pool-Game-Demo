using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    [SerializeField] GameObject canvasGameObject;
    [SerializeField] GameObject gameElements;

    void Start() {
        canvasGameObject.SetActive(false);
        gameElements.SetActive(true);
    }

    public void StartNewGame() 
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
    }

    public void ResumeGame() { //on click event
        canvasGameObject.SetActive(false);
    }

    void Update() {
        Options();
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("volExposedParam", volume);
    }
    
    void Options() 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canvasGameObject == true)
        {
            canvasGameObject.SetActive(false);
            gameElements.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void QuitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
