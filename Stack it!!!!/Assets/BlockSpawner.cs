using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block blockPrefab; 

    public void SpawnBlock(Block LastBlock)
    {
        Block newBlock = Instantiate(LastBlock);
        newBlock._speed = 3f; 


        if (Block.LastBlock != null && Block.LastBlock.gameObject != GameObject.Find("StartingBlock"))
        {
            newBlock.transform.position = new Vector3(-10.69f, Block.LastBlock.transform.position.y + 1, 1);
        }
       
    }

}
