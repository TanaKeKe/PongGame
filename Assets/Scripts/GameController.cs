using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject resume;
    [SerializeField] private GameObject pause;
    public void Pause()
    {
        Time.timeScale = 0f;
        pause.SetActive(false);
        resume.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pause.SetActive(true);
        resume.SetActive(false);
    }
    
}
