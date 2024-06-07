using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    private Vector3 originalPosition;
    [SerializeField] private Vector3 openDoorOffset;

    private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = originalPosition;
        if(isOpen)
        {
            targetPosition = originalPosition + openDoorOffset;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    public void CloseDoor() 
    {
        isOpen = false;
    }
}
