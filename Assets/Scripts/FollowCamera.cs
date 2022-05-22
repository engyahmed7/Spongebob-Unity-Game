using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    private MoveLocal playerScript;



    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        playerScript = GameObject.Find("Spongebob_Cute").GetComponent<MoveLocal>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;


    }

}

