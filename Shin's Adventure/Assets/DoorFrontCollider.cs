using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFrontCollider : MonoBehaviour, Interactive
{
    public Door parent;

    public void Interact(GameObject g)
    {
        Debug.Log("FrontCollider");

        parent.Interact(g);
    }
}
