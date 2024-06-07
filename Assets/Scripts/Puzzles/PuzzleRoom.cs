using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleRoom : MonoBehaviour
{
    private IPuzzlePiece[] allPieces;
    [SerializeField] private bool isPuzzleCompleted;
    private PuzzleController puzzleController;

    public UnityEvent OnPuzzleStart;
    public UnityEvent OnPuzzleStop;
    public void InitializeRoom(PuzzleController controller)
    {
        puzzleController = controller;
        allPieces = GetComponentsInChildren<IPuzzlePiece>();
    }

    public void CheckRoomStatus()
    {
        isPuzzleCompleted = true;
        foreach (IPuzzlePiece piece in allPieces)
        {
            if (!piece.IsCorrect) isPuzzleCompleted = false;
        }

        if(isPuzzleCompleted)
        {
            Debug.Log("ALL REQUIREMENTS MET");
        }
    }

    public void PuzzleEnter()
    {
        OnPuzzleStart?.Invoke();
        Debug.Log("Player entered the Room");
    }

    public void PuzzleExit()
    {
        OnPuzzleStop?.Invoke();
        Debug.Log("Player exited the Room");
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        puzzleController.ChangePuzzleRoom(this);
    }


}
