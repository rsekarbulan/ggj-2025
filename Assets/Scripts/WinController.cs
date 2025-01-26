using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WinController : MonoBehaviour
{
/*    [Header("bgm")]
    [SerializeField] private AudioSource[] BGM;
*/
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

    [Space(10)]
    [Header("PauseMenu")]
    public GameObject PauseMenu;

    [Space(10)]
    [Header("Menu")]
    public GameObject Menu;
/*
    [Space(10)]
    [Header("BGMAudio")]
    [SerializeField] private AudioSource BGMAudioSource;
*/
    [Space(10)]
    [Header("Audio")]
    [SerializeField] private AudioSource UIAudioSource;

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
        // Input handling for arrow outside the pause block
        if (gameObject.activeInHierarchy)
        {
            Menu.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                UIAudioSource.Play();

                if (PlaySpriteSelected.activeSelf)
                {
                    levelManager.Play();
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
                UIAudioSource.Play();
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
                UIAudioSource.Play();
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










}