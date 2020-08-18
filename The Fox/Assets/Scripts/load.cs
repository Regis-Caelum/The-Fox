using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(time());
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
