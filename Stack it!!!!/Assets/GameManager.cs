using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static event Action OnBlockSpawned = delegate { }; 



    // Update is called once per frame
    private void Update()
    {


        if (Input.GetButtonDown("Fire1"))
        {
            if (Block.CurrentBlock != null)
                Block.CurrentBlock.Stop(); 

            

            FindObjectOfType<BlockSpawner>().SpawnBlock(Block.LastBlock); 

            OnBlockSpawned(); 

        }
        
            
        
    }
}
