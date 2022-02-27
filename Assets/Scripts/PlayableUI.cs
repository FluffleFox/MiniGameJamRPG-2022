using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableUI : MonoBehaviour
{
    public static PlayableUI instance;
    const int width = 900;
    const int height = 400;

    [SerializeField]
    GameObject _candyPrefab;

    private void Awake()
    {
        if (instance != null) Destroy(this);
        else { instance = this; }
    }

    public void AddCandle()
    {
        GameObject go = (GameObject)Instantiate(_candyPrefab);
        go.transform.parent = transform;
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = new Vector3(Random.Range(-width,width), Random.Range(0, height), 0.0f);
    }

}
