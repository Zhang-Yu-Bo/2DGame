using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{

    public Animator animator;
    public float transitionTime = 1.0f;
    public Canvas canvas;

    public void LoadScene(int index)
    {
        StartCoroutine(this.LoadLevel(index));
    }

    IEnumerator LoadLevel(int index)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(this.transitionTime);

        SceneManager.LoadScene(index);
    }

    public void setEnable(int flag)
    {
        /*
        if (flag == 0)
        {
            this.canvas.enabled = false;
        }
        else
        {
            this.canvas.enabled = true;
        }
        */
        Debug.Log(1);
    }

}
