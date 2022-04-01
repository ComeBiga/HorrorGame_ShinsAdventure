using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public GameObject text;

    public float keysignTime = 3f;
    public float restartTime = 10f;

    bool availableQuit = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PressKeySign");
    }

    // Update is called once per frame
    void Update()
    {
        if(availableQuit)
        {
            if (Input.anyKeyDown) Application.Quit();

            StartCoroutine("Restart");
        }
    }

    IEnumerator PressKeySign()
    {
        yield return new WaitForSeconds(keysignTime);

        text.SetActive(true);

        availableQuit = true;
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(restartTime);

        SceneManager.LoadSceneAsync(1);
    }
}
