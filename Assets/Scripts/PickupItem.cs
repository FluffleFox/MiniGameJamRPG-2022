using UnityEngine;

public class PickupItem : MonoBehaviour
{
    /*private void OnMouseDown()
    {
        CandleManager.instance.AddScore(5);
    }*/
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Dupa");
        CandleManager.instance.AddScore(5);
        gameObject.SetActive(false);
    }
}
