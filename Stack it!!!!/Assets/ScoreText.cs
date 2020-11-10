using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI text; 
    
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        GameManager.OnBlockSpawned += GameManager_OnBlockSpawned; 

        
    }



    private void GameManager_OnBlockSpawned()
    {
        score++; 
        text.text = "Score: " + score; 
    }
}
