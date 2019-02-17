using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour     
{

    public GameObject player;       /*public object sem leyfir tengja camera og player í inspectornum*/

    private Vector3 offsetPos;      /*variable til að reikna millibil cameru og player*/

    void Start()
    {
        offsetPos = transform.position - player.transform.position;
    }

    void LateUpdate()               /*færir cameru með player*/
    {
        transform.position = player.transform.position + offsetPos;
    }
}