using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Must fit the scenes build indexes
    public enum Scenes { Test = 0, Test1 = 1}

    public void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene((int)scene);
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
