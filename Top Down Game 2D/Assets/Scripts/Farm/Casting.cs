using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    [SerializeField] private int percentage;//porcentagem de chance de pescar um peixe a cada tentativa
    [SerializeField] private GameObject fishPrefab;

    private PlayerItems player;
    private PlayerAnim playerAnim;

    private bool detectingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerItems>();
        playerAnim = player.GetComponent<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
       if(detectingPlayer && Input.GetKeyDown(KeyCode.E))
       {
         playerAnim.OnCastingStarted();
       } 
    }
    
     public void OnCasting()
    {
       int randomValue = Random.Range(1, 100);

       if(randomValue <= percentage)
       {
           //conseguiu pescar um peixe
           Instantiate(fishPrefab, player.transform.position + new Vector3(Random.Range(-2, -1), 0f, 0f), Quaternion.identity);
           Debug.Log("pescou");
       }
       else
       {
          //pescou vento
          Debug.Log("não pescou");
       }
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
