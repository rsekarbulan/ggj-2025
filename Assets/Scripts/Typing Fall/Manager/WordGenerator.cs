using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    //private static string[] wordList = { "next", "married", "skinny", "gigantic", "billowy", "plan", "ignore", "boiling", "crowd", "decisive", "hand", "kittens", "rest", "lean", "trick", "gather", "nervous", "hanging", "rule", "elite", "momentous", "harass", "piquant", "desire", "succeed", "deranged", "subsequent", "thing", "dinner", "different", "nostalgic", "brawny", "stuff", "potato", "internal", "rely", "undesirable", "vagabond", "obnoxious", "arch" };
    public Words[] wordList;

    public static WordGenerator Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Words GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        return wordList[randomIndex];
    }
    //public static string GetRandomWord()
    //{
    //    int randomIndex = Random.Range(0, wordList.Length);
    //    string randomWord = wordList[randomIndex];
    //    return randomWord;
    //}
}