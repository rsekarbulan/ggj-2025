using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class WordManager : MonoBehaviour
{
    public List<Word> words;


    private bool hasActiveWord;
    private Word activeWord;

    public WordSpawner wordSpawner;

    public void AddWord()
    {
        Words newWords = WordGenerator.Instance.GetRandomWord();
        WordDisplay wordDisplay = wordSpawner.SpawnWord(newWords);

        Word word = new Word(newWords, wordDisplay);
        words.Add(word);
    }




    private void ResetActiveWord()
    {
        if (activeWord != null)
        {
            Debug.Log($"Resetting active letter: {activeWord.word}");
        }
        else
        {
            Debug.Log("Resetting active letter: null or already destroyed");
        }

        activeWord = null;
        hasActiveWord = false;
    }

    private void Update()
    {
        //Debug.Log($"Has Active Word: {hasActiveWord}");

        // Check if activeWord's associated GameObject is null or destroyed
        if (hasActiveWord)
        {
            var activeWordGameObject = activeWord?.GetGameObject();
            if (activeWord == null || activeWordGameObject == null)
            {
                Debug.Log("Active word's GameObject is destroyed or null. Resetting active word.");
                ResetActiveWord();
                return;
            }
            else
            {
                Debug.Log($"Active word's GameObject is: {activeWordGameObject.name}");
            }
        }

        // Handle typing logic
        if (Input.anyKeyDown)
        {
            char letter = Input.inputString.Length > 0 ? char.ToLower(Input.inputString[0]) : '\0';

            if (letter != '\0')
            {
                Debug.Log($"Key pressed: {letter}");

                if (hasActiveWord)
                {
                    if (activeWord.GetNextLetter() == letter)
                    {
                        Debug.Log($"Typing letter: {letter} on active word: {activeWord.word} ({activeWord.GetGameObject()?.name ?? "GameObject destroyed"})");

                        activeWord.TypeLetter();

                        if (activeWord.WordTyped())
                        {
                            Debug.Log($"Word '{activeWord.word}' completed. Removing and resetting.");

                            // Panggil fungsi EnableDestruction di ColliderManager
                            ColliderManager colliderManager = activeWord.GetGameObject().GetComponentInChildren<ColliderManager>();
                            if (colliderManager != null)
                            {
                                colliderManager.EnableDestruction();
                            }

                            words.Remove(activeWord);
                            ResetActiveWord();
                        }
                    }
                    else
                    {
                        Debug.Log($"Letter '{letter}' does not match the next letter of active word: {activeWord.word}");
                    }
                }
                else
                {
                    Debug.Log("No active word. Searching for a word to activate.");

                    foreach (Word word in words)
                    {
                        Debug.Log($"Checking word: {word.word} ({word.GetGameObject()?.name ?? "GameObject destroyed"})");

                        if (word.GetNextLetter() == letter)
                        {
                            activeWord = word;
                            hasActiveWord = true;
                            Debug.Log($"New active word set: {word.word} ({activeWord.GetGameObject()?.name ?? "GameObject destroyed"})");
                            word.TypeLetter();
                            break;
                        }
                    }
                }
            }
        }    
    }
}
