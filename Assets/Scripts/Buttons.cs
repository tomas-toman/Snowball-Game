using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    public int sceneNumber;

    public AudioSource audio;
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public Scene currentScene;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(currentScene.name);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void HoverSound()
    {
        audio.PlayOneShot(hoverSound);
    }

    public void ClickSound() 
    { 
        audio.PlayOneShot(clickSound);
    }
}
