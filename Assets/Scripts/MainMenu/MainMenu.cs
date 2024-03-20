using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private Transform planet;
    private float newRotation = 0;
    [SerializeField]
    public int rotationSpeed = 10;

    private void Start()
    {
        planet = transform.Find("World");
    }

    private void Update()
    {
        newRotation += Time.deltaTime * rotationSpeed;
        planet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, newRotation));
    }

    public void sledecaScena()
    {
        Invoke("play", 1);
    }
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quit()
    {
        Application.Quit();
    }

    public void opts()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void goMonke()
    {
        SceneManager.LoadScene(0);
    }

    public void FullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
