using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneIndexToLoad;
    public void LoadMain()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
