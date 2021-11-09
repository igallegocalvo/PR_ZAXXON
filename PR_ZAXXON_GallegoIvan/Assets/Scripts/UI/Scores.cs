using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("txMaxScore").GetComponent<Text>().text = GameManager.highScore + "pts";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
