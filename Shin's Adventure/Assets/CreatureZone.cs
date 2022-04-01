using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureZone : MonoBehaviour
{
    public GameObject creature;
    public string soundName;
    public float delay = 0f;

    public void WakeUpCreature()
    {
        creature.GetComponent<CreatureMovement>().WakeUpCreature();
        SoundManager.instance.PlayDelayed(soundName, delay);
    }
}
