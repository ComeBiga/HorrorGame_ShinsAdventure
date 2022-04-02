using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interacter : MonoBehaviour
{
    public List<GameObject> keys = new List<GameObject>();

    public bool hasKey = false;

    public Camera camera;

    public float range = 100f;

    public UnityEvent OnDie;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    void Interact()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log(hit.transform.GetComponentInParent<Interactive>());

                if(hit.transform.GetComponentInParent<Interactive>() != null)
                    hit.transform.GetComponentInParent<Interactive>().Interact(gameObject);
            }
        }
    }

    public void HaveKey(GameObject newKey)
    {
        keys.Add(newKey);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CreatureZone")
        {
            other.gameObject.SetActive(false);
            other.GetComponent<CreatureZone>().WakeUpCreature();
        }

        if(other.gameObject.tag == "ViewPoint")
        {
            other.GetComponent<ViewPoint>().OnViewPoint();
        }
        //if (other.gameObject.name == "CreatureZone")
        //{
        //    other.gameObject.SetActive(false);
        //    OnCreature.Invoke();
        //    SoundManager.instance.Play("CreatureAttack");
        //}

        //if (other.gameObject.name == "CreatureZone (1)")
        //{
        //    other.gameObject.SetActive(false);
        //    SoundManager.instance.Play("CreatureChasing");
        //}
    }

    public void ReLoadScene()
    {
        StartCoroutine("AfterSeconds", 7.5f);
    }

    IEnumerator AfterSeconds(float seconds)
    {
        float restTime = 3f;

        yield return new WaitForSeconds(seconds - restTime);
        OnDie.Invoke();
        yield return new WaitForSeconds(restTime);

        
        SceneManager.LoadScene(0);
    }
}

public interface OnRaycast
{
    void OnRaycasted();
    void OnRaycastExit();
}
