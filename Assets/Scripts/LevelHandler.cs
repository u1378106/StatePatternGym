using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public GameObject gameoverScreen, winScreen;

    // Start is called before the first frame update
    void Start()
    {
        gameoverScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
