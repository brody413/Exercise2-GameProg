using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStuff : MonoBehaviour
{
    // GameObjects
    public GameObject fish;
    public GameObject bomb;
    
    //Variables
    private Vector2 Pos;
    private bool canSpawn = true;

   
    // Start Not Used
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calls my methid using a coroutine
        StartCoroutine(Spawn());
    }

    //Spawn Method
    IEnumerator Spawn()
    {
        //Checks if can spawn is true, if can spawn is true then it will spawn
        if (canSpawn)
        {
            canSpawn = false; // Sets can spawn to false to force a wait
            yield return new WaitForSeconds(1); // waits 1 second before every respwan
            
            int x = Random.Range(-7, 7); // gets the x cord rang of -7 to 7 for where i can spawn the objects
            Pos = new Vector2(x, 5); // sets the Vector2 Position of the spawn point using x and a hight of 5

            // Gets a random num between 0 and 21
            int i = Random.Range(0, 21);

            if (i % 2 == 0) // checks if its even
            {
                Instantiate(bomb, Pos, bomb.transform.rotation); // if the number is even spawn a bomb
            }
            else if (i % 2 != 0) // checks if not even
            {
                Instantiate(fish, Pos, fish.transform.rotation); // if not even spawn a fish
            }
            canSpawn = true; // set can spawn to true again so the method will reloop
        }
    }
}
