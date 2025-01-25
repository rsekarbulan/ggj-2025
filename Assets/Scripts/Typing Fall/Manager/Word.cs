using UnityEngine;

[System.Serializable]

public class Word
{


    public string word;
    private int typeIndex;
    private WordDisplay display;

    public Word(string _word, WordDisplay _display)
    {
        word = _word;
        typeIndex = 0;
        display = _display;
        display.SetWord(word);
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        display.RemoveLetter();

        if (typeIndex >= word.Length)
        {
            display.CompleteWord();
        }
    }

    public bool WordTyped()
    {
        return typeIndex >= word.Length;
    }
}   
