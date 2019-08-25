using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    [SerializeField] int breakabaleBlocks;
    SceneLoader sceneLoader;

    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void countBreakableBlocks ()
    {
        breakabaleBlocks++;
    }

    public void blockDestroyed()
    {
        breakabaleBlocks--;
        if(breakabaleBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
