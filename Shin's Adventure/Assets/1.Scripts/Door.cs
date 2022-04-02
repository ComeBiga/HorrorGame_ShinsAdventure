using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Interactive
{
    public Transform door;

    public bool UseOffset = false;
    public bool isOpen = false;
    public bool keyNecessary = false;

    public float openAngle = 130f;
    public float openSpeed = 2.0f;
    //public float openSpeedHolding = 130f;

    float defaultAngle;
    float currentAngle;
    float openTime = 0;

    //bool holding = false;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();

        defaultAngle = 0;
        if (door != null) currentAngle = door.localEulerAngles.z;

        //if (!isOpen)
        //{
        //    //anim.SetBool("open", false);
        //    door.localRotation = Quaternion.Euler(0, 0, 0);

        //    //Debug.Log(transform.localRotation.eulerAngles);
        //}
        //else
        //{
        //    //anim.SetBool("open", true);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Mouse0))
        //{
        //    holding = false;
        //}

        //if (holding)
        //{
        //    float mouseX = Input.GetAxis("Mouse X");

        //    float goalAngle = currentAngle + mouseX * openSpeedHolding;

        //    float goalAngleLerp = Mathf.LerpAngle(currentAngle, goalAngle, Time.deltaTime);

        //    door.localEulerAngles = new Vector3(door.localEulerAngles.x, door.localEulerAngles.y, Mathf.Clamp(goalAngleLerp, defaultAngle, openAngle));

        //    currentAngle = goalAngle;

        //    return;
        //}

        if (UseOffset) return;

        if (openTime < 1)
        {
            openTime += Time.deltaTime * openSpeed;
        }

        if (door != null) door.localEulerAngles = new Vector3(door.localEulerAngles.x, door.localEulerAngles.y, Mathf.LerpAngle(currentAngle, defaultAngle + (isOpen ? openAngle : 0), openTime));
    }

    public virtual void Interact(GameObject g)
    {
        Debug.Log("Interact!");

        if (keyNecessary)
        {
            if (!g.GetComponent<Interacter>().keys.Exists(key => key.GetComponent<Key>().fitDoor == this.gameObject))
            {
                Debug.Log("Locked!");
                SoundManager.instance.Play("DoorLocked");
                return;
            }
        }

        //holding = true;
        UseOffset = false;
        //isOpen = !isOpen;
        if(isOpen)
        {
            SoundManager.instance.Play("DoorClose");
            isOpen = false;
        }
        else
        {
            SoundManager.instance.Play("DoorOpen");
            isOpen = true;
        }
        currentAngle = door.localEulerAngles.z;
        openTime = 0;

        //if (!isOpen)
        //{
        //    door.localRotation = Quaternion.Euler(0, 0, openAngle);

        //    //anim.SetBool("open", true);

        //    isOpen = true;
        //}
        //else
        //{
        //    door.localRotation = Quaternion.Euler(0, 0, 0);

        //    //anim.SetBool("open", false);

        //    isOpen = false;
        //}
    }

    private void OpenAndClose(float mouseX)
    {

    }
}
