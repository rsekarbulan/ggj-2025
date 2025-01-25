using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    [Header("bgm")]
    [SerializeField] private AudioSource[] BGM;

    float Selection;

    [SerializeField] private GameObject player;

    //private Script1 script1;
    //private Script2 script2;

    //private PlayerInput playerInput;

    private DragWithoutClick playerMovement;


    LevelManager levelManager;

    [Space(10)]
    [Header("start")]
    public GameObject PlaySprite;
    public GameObject PlaySpriteSelected;

    [Space(10)]
    [Header("Petunjuk")]
    public GameObject MiddleSprite;
    public GameObject MiddleSpriteSelected;

    [Space(10)]
    [Header("Quit")]
    public GameObject QuitSprite;
    public GameObject QuitSpriteSelected;

    public static bool GamePaused = false;


    public bool PausingGame
    {
        get { return GamePaused; }
        set { GamePaused = value; }
    }


    [Space(10)]
    [Header("PauseMenu")]
    public GameObject PauseMenu;

    [Space(10)]
    [Header("Menu")]
    public GameObject Menu;


    /*[Space(10)]
    [Header("Audio")]*/
    //[SerializeField] private AudioSource UIAudioSource;

    private void Awake()
    {

        //playerInput = player.GetComponent<PlayerInput>();
        playerMovement = player.GetComponent<DragWithoutClick>();
        //petunjuk = false;

        PauseMenu.SetActive(false);
        Menu.SetActive(false);
        //Petunjuk.SetActive(false);
        levelManager = FindObjectOfType<LevelManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        Selection = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //UIAudioSource.Play();
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        // Input handling for arrow outside the pause block
        if (GamePaused)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                //UIAudioSource.Play();

                if (PlaySpriteSelected.activeSelf)
                {
                    Resume();
                }
                else if (MiddleSpriteSelected.activeSelf)
                {
                    levelManager.MainMenu();
                    Time.timeScale = 1f;
                }
                else if (QuitSpriteSelected.activeSelf)
                {
                    Application.Quit();

                }

            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //UIAudioSource.Play();
                Debug.Log("arrow bawah");

                if (Selection <= 3)
                {
                    Selection++;
                }

                if (Selection > 3)
                {
                    Selection = 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //UIAudioSource.Play();
                Debug.Log("arrow atas");

                if (Selection >= 1)
                {
                    Selection--;
                }

                if (Selection < 1)
                {
                    Selection = 3;
                }
            }

            // Set sprite based on selection
            if (Selection == 1)
            {
                PlaySprite.SetActive(false);
                PlaySpriteSelected.SetActive(true);
                QuitSprite.SetActive(true);
                QuitSpriteSelected.SetActive(false);
                MiddleSprite.SetActive(true);
                MiddleSpriteSelected.SetActive(false);
            }
            else if (Selection == 2)
            {
                PlaySprite.SetActive(true);
                PlaySpriteSelected.SetActive(false);
                MiddleSprite.SetActive(false);
                MiddleSpriteSelected.SetActive(true);
                QuitSprite.SetActive(true);
                QuitSpriteSelected.SetActive(false);
            }
            else if (Selection == 3)
            {
                PlaySprite.SetActive(true);
                PlaySpriteSelected.SetActive(false);
                MiddleSprite.SetActive(true);
                MiddleSpriteSelected.SetActive(false);
                QuitSprite.SetActive(false);
                QuitSpriteSelected.SetActive(true);
            }
        }
    }


    void Resume()
    {
        //playerInput.enabled = true;
        playerMovement.enabled = true;


        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Menu.SetActive(false);
        //Petunjuk.SetActive(false);

        foreach (var audioSource in BGM)
        {
            if (audioSource != null)
            {
                audioSource.UnPause();
            }
        }
    }


    void Pause()
    {
        //playerInput.enabled = false;
        playerMovement.enabled = false;

        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Menu.SetActive(true);
        //Petunjuk.SetActive(false);
        foreach (var audioSource in BGM)
        {
            if (audioSource != null)
            {
                audioSource.Pause();
            }
        }

    }









}