using System.Linq;
using UnityEngine;

public class SlidePieceManager : MonoBehaviour
{
    private SlidePiecePoint[] slidePieces;
    public GameObject UI;

    private void OnEnable()
    {
        slidePieces = FindObjectsOfType<SlidePiecePoint>();
        
    }

    private void Start()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        if (slidePieces == null) return;
        if (slidePieces.Any(x => !x.Connected)) return;

        UI.gameObject.SetActive(true);
        Debug.Log("Puzzle Solved!");
    }
}
