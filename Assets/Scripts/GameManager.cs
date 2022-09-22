using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Singleton;

    private GroundPiece[] allGroundPieces;
    // Start is called before the first frame update
    void Start()
    {
        SetupNewLevel();
    }

  private void SetupNewLevel()
  {
    allGroundPieces=FindObjectsOfType<GroundPiece>();
  }
  
  private void Awake()
  {
    if(Singleton == null)
    {
      Singleton = this;
    } 
     else if (Singleton != this)
    {
      Destroy(gameObject);
      DontDestroyOnLoad(gameObject);
    }
  }
  
  private void OnEnable()
  {
   SceneManager.sceneLoaded += OnLevelFinishedLoading;
  }

  private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode )
  {
    SetupNewLevel();
  }

  public void CheckComplete()
  {
    bool isFinished = true;
    for(int i = 0; i < allGroundPieces.Length; i++)
    {
      if(allGroundPieces[i].isColored == false)
      {
        isFinished = false;
        break;
      }
    }
    if(isFinished)
    {
      //NextLevel
      NextLevel();
    }
  }
   private void NextLevel()
   {

    if(SceneManager.GetActiveScene().buildIndex == 1)
    {
      SceneManager.LoadScene(0);
    }
    else
    {SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

}
}
