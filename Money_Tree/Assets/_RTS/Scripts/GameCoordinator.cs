using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCoordinator : MonoBehaviour
{
    public KeyCode PauseKey = KeyCode.Escape;
    public bool Paused
    {
        get
        {
            return _paused;
        }
        set
        {
            _paused = value;
            if(value)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public AudioClip InSfx;
    public AudioClip OutSfx;

    bool _paused = false;
    AudioSource _audioSource;
    Canvas _canvas;


    // Use this for initialization
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _canvas = GetComponent<Canvas>();

        _paused = false;
        _canvas.enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(PauseKey))
        {
            Paused = !Paused;
        }
    }

    public void Pause()
    {
        _canvas.enabled = true;

        _audioSource.clip = InSfx;
        _audioSource.Play();

        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        _canvas.enabled = false;

        _audioSource.clip = OutSfx;
        _audioSource.Play();

        Time.timeScale = 1.0f;
    }
}
