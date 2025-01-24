using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    float Selection;

    [Space(10)]
    [Header("start")]
    public GameObject PlaySprite;
    public GameObject PlaySpriteSelected;

    [Space(10)]
    [Header("Quit")]
    public GameObject QuitSprite;
    public GameObject QuitSpriteSelected;

    [Header("LevelManager Reference")]
    public LevelManager levelManager; // Drag LevelManager here in the Inspector

    /*[Header("BGM")]
    [SerializeField] private AudioSource AudioBGM;

    [Space(10)]
    [SerializeField] private AudioSource UIAudioSource;*/

    private void Awake()
    {
        //AudioBGM.Play();

        // Check if the levelManager reference is assigned
        if (levelManager == null)
        {
            Debug.LogError("levelManager is not assigned in the Inspector!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Selection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //UIAudioSource.Play();
            if (PlaySpriteSelected.activeSelf)
            {
                levelManager.Play();
            }

            if (QuitSpriteSelected.activeSelf)
            {
                levelManager.Quit();
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //UIAudioSource.Play();
            Selection = Mathf.Clamp(Selection + 1, 1, 2);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //UIAudioSource.Play();
            Selection = Mathf.Clamp(Selection - 1, 1, 2);
        }

        if (Selection == 1)
        {
            PlaySprite.SetActive(false);
            PlaySpriteSelected.SetActive(true);
            QuitSprite.SetActive(true);
            QuitSpriteSelected.SetActive(false);
        }

        if (Selection == 2)
        {
            PlaySprite.SetActive(true);
            PlaySpriteSelected.SetActive(false);
            QuitSprite.SetActive(false);
            QuitSpriteSelected.SetActive(true);
        }
    }
}
