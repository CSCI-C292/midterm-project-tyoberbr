using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static Block CurrentBlock { get; private set; }
    public static Block LastBlock {get; private set;}



    [SerializeField] public float _speed = 1f; 
    

    private void OnEnable()
    {
        
        if (LastBlock == null)
           LastBlock = GameObject.Find("StartingBlock").GetComponent<Block>();
        
        CurrentBlock = this; 

        transform.localScale = new Vector3(LastBlock.transform.localScale.x, transform.localScale.y, 1); 
    }

    internal void Stop()
    {
        
        float hangover = transform.position.x - LastBlock.transform.position.x;
        if (Mathf.Abs(hangover) >= LastBlock.transform.localScale.x)
        {
            LastBlock = null; 
            CurrentBlock = null; 
        }



        SplitBlockonX(hangover); 
        LastBlock = CurrentBlock; 
        _speed = 0;
    }

    private void SplitBlockonX(float hangover)
    {
        float newXSize = LastBlock.transform.localScale.x - Mathf.Abs(hangover); 
        float fallingBlockSize = transform.localScale.x - newXSize; 

        float newXPosition = LastBlock.transform.position.x + (hangover / 2);
        transform.localScale = new Vector3(newXSize, transform.localScale.y, 1); 
        transform.position = new Vector3(0, transform.position.y, newXPosition); 
        
        
    }


    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * _speed;
    }
}
