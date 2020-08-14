using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject end;
    public Animator animator;
    public float transitiontime = 4f;
    // Update is called once per frame
    public void nextlevel()
    {
        //StartCoroutine(Level(SceneManager.GetActiveScene().buildIndex + 1) );
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*IEnumerator Level(int index)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(transitiontime);

    }*/
}
