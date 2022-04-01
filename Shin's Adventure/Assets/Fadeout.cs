using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour
{
    public UnityEvent OnFadeOut;

    public void DoFadeOut()
    {
        GetComponent<Animator>().SetBool("FadeOut", true);
        OnFadeOut.Invoke();
    }
}
