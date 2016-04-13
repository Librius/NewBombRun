#pragma strict

//var isPause = false;
var MainMenu : Rect = Rect(80, 80, 1200, 1200);
  
 function Update () {
//  if( Input.GetKeyDown(KeyCode.Escape))
//    {
//       isPause = !isPause;
//       if(isPause)
//          Time.timeScale = 0;
//       else
//          Time.timeScale = 1;
//    }
//	Debug.Log(isPause);
 }
  
// function OnGUI()
// {
//    if(isPause)
//        GUI.Window(0, MainMenu, TheMainMenu, "Pause Menu");
// }
 
 function TheMainMenu () {
 if(GUILayout.Button("Main Menu",  GUILayout.Width(580), GUILayout.Height(100))){
 Application.LoadLevel("MenuScene");
 }
 if(GUILayout.Button("Restart",  GUILayout.Width(580), GUILayout.Height(100))){
 Application.LoadLevel(Application.loadedLevel);
 }
 if(GUILayout.Button("Quit",  GUILayout.Width(580), GUILayout.Height(100))){
 Application.Quit();
 }
 }

 function PauseButtonClicked(){

 }

 function PlayBtnClicked(){
 	Debug.Log("Play Clicked");
 	Application.LoadLevel("GameSelect");
 }

 function ExitBtnClicked(){
    Application.Quit();
 }

 function MainMenuBtnClicked(){
    Application.Quit();
    Application.LoadLevel("MenuScene");
 }

 function StoryBtnClicked(){
 	Debug.Log("Story Clicked");
 	Application.LoadLevel("Story");
 }

 function CityBtnClicked(){
 	Application.LoadLevel("City");
 }

 function AgainBtnClicked(){
 	Application.LoadLevel(Application.loadedLevel);
 }

 function BackBtnClicked(){
 	Debug.Log("Back Clicked");
 	Application.LoadLevel("MenuScene");
 }

