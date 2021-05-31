using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : UnityDebugLogService
{
   [SerializeField] private GameObject StartScreen = null;
   [SerializeField] private GameObject GameOverScreen = null;
   [SerializeField] private Button PlayBtn = null;
   [SerializeField] private Button RestartBtn = null;

   public GameContext _GameContext;
   private void Start()
   {
      PlayBtn.onClick.AddListener(Play);
      RestartBtn.onClick.AddListener(Restart);
      _Contexts = Contexts.sharedInstance;
    //  Debug.Log("Start");
   }

   public void StartScreenState(bool action)
   {
      StartScreen.SetActive(action);
   }
   public void GameOverScreenState(bool action)
   {
      GameOverScreen.SetActive(action);
   }
   
   private void Play()
   {
     //Debug.Log("Play");
      var entity = _GameContext.CreateEntity();
      entity.isGameStateChange = true;
   }
   private void Restart()
   {
      CleanUpGame();
      CleanUpInput();
      CleanUpDebug();
      CleanUpPhysics();
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   private void CleanUpGame()
   {
      var gameContext = _Contexts.game;
      foreach (var entity in gameContext.GetEntities())
      {
         entity.isComponentsDestroy = true;
      }
   }
   
   private void CleanUpInput()
   {
      var inputContext = _Contexts.input;
      foreach (var entity in inputContext.GetEntities())
      {
         entity.isComponentsDestroy = true;
      }
   }
   private void CleanUpDebug()
   {
      var debugContext = _Contexts.debug;
      foreach (var entity in debugContext.GetEntities())
      {
         entity.isComponentsDestroy = true;
      }
   }
   
   private void CleanUpPhysics()
   {
      var physicsContext = _Contexts.physics;
      foreach (var entity in physicsContext.GetEntities())
      {
         entity.isComponentsDestroy = true;
      }
   }
   
}