using System.Collections;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
    public void ReturnToPool(float delay)
    {
        StartCoroutine(Delay(delay));
    }
    IEnumerator Delay(float Delay)
    {
        yield return new WaitForSeconds(Delay);
        ReturnToPool();
    }
}
