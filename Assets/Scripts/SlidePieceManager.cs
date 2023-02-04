using System.Linq;
using UnityEngine;

public class SlidePieceManager : MonoBehaviour
{
    private SlidePiecePoint[] slidePieces;

    private void OnEnable()
    {
        slidePieces = FindObjectsOfType<SlidePiecePoint>();
    }

    private void Update()
    {
        if (slidePieces == null) return;
        if (slidePieces.Any(x => !x.Connected)) return;

        Debug.Log("Puzzle Solved!");
    }
}
