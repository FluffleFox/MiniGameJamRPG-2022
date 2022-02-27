using UnityEngine;

public class Candle : MonoBehaviour
{
    ParticleSystem particle;
    float maxLifeTime = 20;
    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    public void SetMaxLifeTime(float value)
    {
        maxLifeTime = value;
    }

    public void SetLiveTime(float newLifeTime)
    {
        ParticleSystem.MainModule temp = particle.main;
        float percent = Mathf.Clamp01(newLifeTime / maxLifeTime);
        temp.startSpeed = percent * Random.Range(4, 6);
        if (newLifeTime <= 0.0f) temp.loop = false;
        else 
        {
            temp.loop = true;
            particle.Play();
        }
    }
}
