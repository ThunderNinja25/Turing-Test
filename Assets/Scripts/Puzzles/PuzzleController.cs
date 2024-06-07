using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] private List<PuzzleRoom> puzzleRooms;
    [SerializeField] private PuzzleRoom currentRoom;


    private void Awake()
    {
        foreach(PuzzleRoom room in puzzleRooms)
        {
            room.InitializeRoom(this);
        }
    }


    public void ChangePuzzleRoom(PuzzleRoom newRoom)
    {
        if (currentRoom)
        {
            currentRoom.PuzzleExit();
        }

        currentRoom = newRoom;
        int tempVariable = puzzleRooms.IndexOf(currentRoom);
        if (tempVariable + 1 <= puzzleRooms.Count -1) { puzzleRooms[tempVariable + 1].InitializeRoom(this); }
        currentRoom.PuzzleEnter();
    }
}
