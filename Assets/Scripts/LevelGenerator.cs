using System;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Platform[] platforms;
    public float initialSpeed = 3;
    public float maxSpeed = 5;
    public float platformSpacing = 0;
    const float maxHeight = 10;
    const float minHeight = -10;
    const float amplitude = 20;
    const float startHorizontalPosition = 30;
    const float maxDiffBetweenPlatforms = 2;
    float lastPlatformHeight = 0;
    long initialTime;


    private void Start()
    {
        for(int i=0; i<platforms.Length; i++)
        {
            platforms[i].onReachViewEdge.AddListener(ReloadPlatform);
        }
        initialTime = DateTime.Now.Ticks;
    }
    void ReloadPlatform(Platform platform)
    {
        float time = 1.0f + (float)((DateTime.Now.Ticks - initialTime) / 10000000);
        float chanceForDown = Mathf.Clamp01((lastPlatformHeight-minHeight) / amplitude);
        float chanceForUp = 1.0f-chanceForDown;
        float randDir = Mathf.Sign(UnityEngine.Random.Range(-chanceForDown, chanceForUp));
        float rand = randDir * Mathf.Round(UnityEngine.Random.Range(0f, maxDiffBetweenPlatforms * 2.0f)) * 0.5f;
        float newHeight = lastPlatformHeight + rand;
        float velocity = initialSpeed + (maxSpeed - maxSpeed * 1 / Mathf.Pow(time,0.1f));
        platform.SetPositionAndVelovity(velocity, new Vector3(startHorizontalPosition, newHeight, 10));
        lastPlatformHeight = newHeight;
    }
}
