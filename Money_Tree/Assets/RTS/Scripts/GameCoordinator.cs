using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCoordinator : MonoBehaviour
{
    public KeyCode PauseKey = KeyCode.Escape;
    public static SceneManager marvin;
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

    public Camera Camera;

    public AudioClip InSfx;
    public AudioClip OutSfx;

    public float PauseIconScale = 0.05f;


    bool _paused = false;
    AudioSource _audioSource;
    SpriteRenderer _spriteRenderer;


    // Use this for initialization
    void Start()
    {
        marvin = GetComponent<SceneManager>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _paused = false;
        _spriteRenderer.enabled = false;
        SceneManager.UnloadScene("RTS");
        SceneManager.LoadScene("PartOne");
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
        var screenCenterVP = new Vector3(0.5f, 0.5f, Camera.nearClipPlane);
        this.transform.position = Camera.ViewportToWorldPoint(screenCenterVP);
        this.transform.localScale = Vector3.one * PauseIconScale;
        this.transform.LookAt(Camera.transform);
        _spriteRenderer.enabled = true;

        _audioSource.clip = InSfx;
        _audioSource.Play();

        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        _spriteRenderer.enabled = false;

        _audioSource.clip = OutSfx;
        _audioSource.Play();

        Time.timeScale = 1.0f;
    }
}
