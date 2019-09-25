using UnityEngine;

public class ImpactZone : MonoBehaviour
{
    private int count = 0;
    private void Update()
    {
        if (count == 1)
        {
            gameObject.SetActive(false);
        }
        count++;
    }
}