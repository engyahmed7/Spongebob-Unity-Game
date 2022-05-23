using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MoveLocal : MonoBehaviour
{
    public GameObject game;
    GameObject player;
    UnityEngine.AI.NavMeshAgent agent;
    private Drive playerScript;
    private Animator spongebobAnimation;
    float speed;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerScript = GameObject.Find("plankton").GetComponent<Drive>();
        spongebobAnimation = GetComponent<Animator>();
        agent.speed=10.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (!playerScript.gameover || !playerScript.gameover2)
        {
            Vector3 move = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            agent.SetDestination(move);
        }

        if (playerScript.gameover || playerScript.gameover2)
        {
            spongebobAnimation.GetComponent<Animator>().enabled = false;
        }
    }
}


