using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas impactCanvas;
    [SerializeField] float impactTime = 0.3f;

    void Start() 
    {
        impactCanvas.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }
    IEnumerator ShowSplatter()
    {
        impactCanvas.enabled = true;
        yield return new WaitForSecondsRealtime(impactTime);
        impactCanvas.enabled = false;
    }
}
