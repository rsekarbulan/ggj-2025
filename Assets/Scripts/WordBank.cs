using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WordBank : MonoBehaviour
{
    public List<string> originalWords = new List<string>()
    {
        "pancake", "cream", "maple"
    };

    private List<string> workingWords = new List<string>();

    private void Awake()
    {
        ResetWorkingWords();
    }

    private void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;
        }
    }

    private void ConvertToLower(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    private void ResetWorkingWords()
    {
        workingWords.Clear();
        workingWords.AddRange(originalWords);
        Shuffle(workingWords);
        ConvertToLower(workingWords);
    }

    public string GetWord()
    {
        if (workingWords.Count == 0)
        {
            ResetWorkingWords(); 
        }

        string newWord = workingWords.Last();
        workingWords.RemoveAt(workingWords.Count - 1);

        return newWord;
    }
}
