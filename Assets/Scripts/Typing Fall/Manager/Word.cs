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
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        display.RemoveLetter();
    }

    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if (wordTyped) {
            //display.RemoveWord();  
        }
        return wordTyped;
    }
}   
