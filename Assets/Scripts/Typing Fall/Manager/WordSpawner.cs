using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public WordDisplay SpawnWord()
    {

        return WordManager2.instance.GetWordObject();
    }
}
