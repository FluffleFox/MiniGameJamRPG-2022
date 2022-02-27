using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Anime : MonoBehaviour
{
    private int givenFlowers = 0;
    [SerializeField] private Slider _slider;
    [SerializeField] private VisualEffect _effect;
    [SerializeField] private SapphiArtChan_AnimManager _sapphiArtChanAnimManager;
    [SerializeField] private GameObject cloth;
    void Start()
    {
        _effect.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Dupa");
        FlowerController fc = other.gameObject.GetComponent<FlowerController>();
        int flowers  = fc.checkFlower();

        if (flowers > 0)
        {
            givenFlowers += fc.RemoveAllFlowers();
            SetFill();
        }

        if (givenFlowers >= 8)
        {
            _effect.Play();
            _sapphiArtChanAnimManager.anim = "winpose";
            cloth.SetActive(false);
            
        }
    }

    private void SetFill()
    {
        _slider.value = 0.125f * givenFlowers;
    }
    
}
