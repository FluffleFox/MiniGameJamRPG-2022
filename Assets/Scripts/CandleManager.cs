using UnityEngine;

public class CandleManager : MonoBehaviour
{
    public static CandleManager instance;
    public float candleLifeTime = 5;
    public Candle[] candles;
    int currentIndex;
    float currentScore;

    private void Start()
    {
        if (instance != null) { Destroy(this); return; }
        else instance = this;
        currentScore = candles.Length * candleLifeTime;
        currentIndex = candles.Length - 1;
        for(int i=0; i<candles.Length; i++)
        {
            candles[i].SetMaxLifeTime(candleLifeTime);
        }
    }

    private void Update()
    {
        currentScore -= Time.deltaTime;
        if (currentScore <= 0)
        {
            Debug.Log("Game Over");
            this.enabled = false;
            return;
        }
        int index = Mathf.FloorToInt(currentScore / candleLifeTime);
        float time = currentScore - index * candleLifeTime;
        candles[index].SetLiveTime(time);
        if (currentIndex > index)
        {
            candles[currentIndex].SetLiveTime(-1);
        }
        currentIndex = index;

        
    }

    public void AddScore(float scoreToAdd)
    {
        currentScore += scoreToAdd;
        currentScore = Mathf.Clamp(currentScore, 0.0f, candles.Length * candleLifeTime - 0.5f);
    }
}
