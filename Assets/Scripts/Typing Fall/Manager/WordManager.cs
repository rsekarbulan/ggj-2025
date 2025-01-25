using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class WordManager : MonoBehaviour
{
    public static WordManager instance;

    public ObjectDataSO[] wordPrefab;
    public Transform wordCanvas;

    public List<Word> words;
    public List<char> characters;


    private bool hasActiveWord;
    private bool isLocked = false; // Status apakah objek terkunci
    private Word activeWord;

    public WordSpawner wordSpawner;

    private GameObject activeWordObj;
    private string objectWord;
    private int typeIndex;
    private ObjectDataSO objectDataSO;
    private WordDisplay wordDisplay;

    public GameObject wordObj { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public void AddWord()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-8.45f, 8.39f), 7f);
        int randomObject = Random.Range(0, wordPrefab.Length);

        GameObject newWordObj = Instantiate(wordPrefab[randomObject].objectPrefab, randomPosition, Quaternion.identity, wordCanvas);
        newWordObj.GetComponentInChildren<SpriteRenderer>().sprite = wordPrefab[randomObject].bubbleSprite;

        string newObjectWord = wordPrefab[randomObject].objectName;

        // Tambahkan ke daftar kata jika belum terkunci
        if (!isLocked && !hasActiveWord)
        {
            SetActiveWord(newWordObj, wordPrefab[randomObject], newObjectWord);
            Debug.Log(newObjectWord, newWordObj);
        }
    }

    private void SetActiveWord(GameObject wordObj, ObjectDataSO dataSO, string word)
    {
        hasActiveWord = true;        // Menandai bahwa ada objek aktif
        activeWordObj = wordObj;     // Menetapkan objek aktif
        objectDataSO = dataSO;       // Menyimpan data objek
        objectWord = word;           // Menyimpan kata dari objek
        typeIndex = 0;               // Mengatur ulang indeks huruf

        wordDisplay = activeWordObj.GetComponent<WordDisplay>();
        if (wordDisplay != null)
        {
            // Menampilkan teks dari objectName
            wordDisplay.text.text = objectWord;
        }
        else
        {
            Debug.LogError("WordDisplay component not found on prefab.");
        }
    }

    public void TypeLetter(char letter)
    {
        // Abaikan huruf jika tidak ada objek aktif
        if (!hasActiveWord)
        {
            Debug.LogWarning("No active word to type.");
            return;
        }

        // Mengunci fokus setelah huruf pertama diketik
        isLocked = true;

        // Proses huruf untuk objek aktif
        if (objectWord[typeIndex] == letter)
        {
            typeIndex++;
            wordDisplay.RemoveLetter();

            // Jika kata selesai diketik
            if (typeIndex >= objectWord.Length)
            {
                Debug.Log("Typing correct");
                activeWordObj.GetComponentInChildren<SpriteRenderer>().sprite = objectDataSO.popSprite;
                Destroy(activeWordObj, 1f); // Hapus objek aktif dengan delay

                // Reset state
                hasActiveWord = false;
                isLocked = false; // Membuka kunci untuk objek berikutnya
                activeWordObj = null;
                objectWord = null;
            }
        }
    }


}
