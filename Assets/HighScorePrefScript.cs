using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePrefScript : MonoBehaviour
{
    public GameObject UIscore;

    // Start is called before the first frame update
    void Start()
    {
        UIscore.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("High Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
