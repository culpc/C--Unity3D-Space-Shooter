using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScore : MonoBehaviour
  
{

    public static int score = 0;


    void OnGUI()
    {
        GUI.Box(new Rect(100, 100, 100, 100), score.ToString());
    }
}
