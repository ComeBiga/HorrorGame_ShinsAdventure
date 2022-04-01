using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverDoor : Door
{
    public UnityEvent OnGameOver;

    public override void Interact(GameObject g)
    {
        if (!g.GetComponent<Interacter>().keys.Exists(key => key.GetComponent<Key>().fitDoor == this.gameObject))
        {
            Debug.Log("Locked!");
            SoundManager.instance.Play("DoorLocked");
            return;
        }

        OnGameOver.Invoke();
        SoundManager.instance.Stop("CreatureChasing");
        Debug.Log("GameOver!");

        StartCoroutine("WaitLoadScene");
    }

    IEnumerator WaitLoadScene()
    {
        yield return new WaitForSeconds(8f);

        SceneManager.LoadScene(2);
    }
}
