using UnityEngine;

[System.Serializable]

public class Word
{


    public string word;
    public Words words;

    private int typeIndex;

    WordDisplay display;

    public Word(Words _word, WordDisplay _display)
    {
        words = _word;
        word = words.wordLetter;

        typeIndex = 0;
        display = _display;
        display.SetWord(word);  
        display.words = _word;
    }

    public char GetNextLetter()
    {
        if (typeIndex < word.Length)
        {
            return word[typeIndex];
        }
        else
        {
            // Jika tidak ada huruf berikutnya, kembalikan '\0'
            Debug.LogWarning($"GetNextLetter called with out-of-bounds typeIndex ({typeIndex}) for word: '{word}'");
            return '\0';
        }
    }

    public void TypeLetter()
    {
        if (typeIndex < word.Length)
        {
            display.RemoveLetter();
            typeIndex++;
        }
        else
        {
            Debug.Log($"TypeLetter called but typeIndex ({typeIndex}) is out of bounds for word: '{word}'");
        }
    }

    public bool WordTyped()
    {
        if (typeIndex >= word.Length)
        {
            // Optionally reset or remove the word from the game
            return true;
        }
        return false;
    }

    public GameObject GetGameObject()
    {
        // Check if display is null or the associated GameObject is destroyed
        if (display == null || display.gameObject == null)
        {
            return null;
        }
        return display.gameObject;
    }
}   
