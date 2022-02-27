using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    public UnityEvent<Platform> onReachViewEdge;
    Vector3 translation = new Vector3(-3, 0, 0);
    public GameObject candle;
    private void Start()
    {
        float travelTime = (-30 - transform.position.x ) / translation.x;
        Invoke("InvokeEvents", travelTime);
    }

    void Update()
    {
        transform.Translate(translation * Time.deltaTime);
    }

    public void SetPositionAndVelovity(float velocity, Vector3 newPos)
    {
        transform.position = newPos;
        float travelTime = (newPos.x * 2.0f) / velocity;
        translation.x = -velocity;
        Invoke("InvokeEvents", travelTime);
        if (Random.Range(0.0f, 100.0f) > 90.0f) { candle.SetActive(true); }
    }

    void InvokeEvents()
    {
        onReachViewEdge.Invoke(this);
    }
}
