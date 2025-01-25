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
    private Word activeWord;

    public WordSpawner wordSpawner;

    string objectWord;
    private int typeIndex;
    ObjectDataSO objectDataSO;
    WordDisplay wordDisplay;
    public GameObject wordObj {get ; private set;}

    private void Awake()
    {
        instance = this;
    }

    public void AddWord()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-8.45f, 8.39f), 7f);
        int randomObject = Random.Range(0, wordPrefab.Length);

        wordObj = Instantiate(wordPrefab[randomObject].objectPrefab, randomPosition, Quaternion.identity, wordCanvas);
        wordObj.GetComponentInChildren<SpriteRenderer>().sprite = wordPrefab[randomObject].bubbleSprite;

        objectWord = wordPrefab[randomObject].objectName;
        wordDisplay = wordObj.GetComponent<WordDisplay>();
        wordDisplay.text.text = wordPrefab[randomObject].objectName;

        objectDataSO = wordPrefab[randomObject];

        hasActiveWord = true;
    }

        
    public void TypeLetter (char letter)
    {
        if (hasActiveWord) {
            if (objectWord[typeIndex] == letter) {
                typeIndex++;
                wordDisplay.RemoveLetter();
                if (typeIndex >= objectWord.Length)
                {
                    Debug.Log("TYping correct");
                    hasActiveWord=false;
                    wordObj.GetComponentInChildren<SpriteRenderer>().sprite = objectDataSO.popSprite;
                    typeIndex = 0;

                    return;
                }
            }
        }
        else
        {
            foreach (Word word in words) {
                if (word.GetNextLetter() == letter) {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }


    }

}
