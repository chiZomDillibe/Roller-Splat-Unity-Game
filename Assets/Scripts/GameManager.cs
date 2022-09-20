using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Singleton;

    private GroundPiece[] allGroundPieces;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  private void SetupNewLevel()
  {
    allGroundPieces=FindObjectsOfType<GroundPiece>();
  }
  
  
    // Update is called once per frame
    void Update()
    {
        
    }
}
