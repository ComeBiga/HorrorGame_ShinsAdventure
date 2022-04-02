using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour, Interactive, OnRaycast
{
    public GameObject fitDoor;

    public UnityEvent OnSelect;

    public AudioSource pickUpSound;

    public void Interact(GameObject g)
    {
        Debug.Log("Key");

        OnSelect.Invoke();
        SoundManager.instance.Play("PickUpKey");

        gameObject.SetActive(false);
    }

    public void OnRaycasted()
    {
        GetComponent<cakeslice.Outline>().eraseRenderer = false;
    }

    public void OnRaycastExit()
    {
        GetComponent<cakeslice.Outline>().eraseRenderer = true;
    }
}
