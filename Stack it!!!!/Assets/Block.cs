using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static Block CurrentBlock { get; private set; }
    public static Block LastBlock {get; private set;}



    [SerializeField] float _speed = 1f; 
    

    private void OnEnable()
    {
        if (LastBlock == null)
           LastBlock = GameObject.Find("StartingBlock").GetComponent<Block>();
        
        CurrentBlock = this; 
    }

    internal void Stop()
    {
        _speed = 0;
        float hangover = transform.position.x - LastBlock.transform.position.x;
        Debug.Log(hangover);

        SplitBlockonX(hangover); 
    }

    private void SplitBlockonX(float hangover)
    {
        float newXSize = LastBlock.transform.localScale.x - Mathf.Abs(hangover); 
        float fallingBlockSize = transform.localScale.x - newXSize; 

        float newXPosition = LastBlock.transform.position.x + (hangover / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newXSize); 
        transform.position = new Vector3(transform.position.x, transform.position.y, newXPosition); 
    }


    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * _speed;
    }
}
