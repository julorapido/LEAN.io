
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameManager>().gameHasEnded == false ){
            transform.position = player.position + offset;
        }else {
            transform.LookAt(player);
        }
    }


}
