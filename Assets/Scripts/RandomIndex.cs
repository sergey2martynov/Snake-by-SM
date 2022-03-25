
using UnityEngine;

public class RandomIndex : MonoBehaviour
{
    public int ReturnRandomIndex()
    {
        int randomIndex = Random.Range(0, 10);
        return randomIndex;
    }
}
