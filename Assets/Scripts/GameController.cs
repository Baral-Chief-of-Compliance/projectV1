using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{


    public Text scroeText;
    private Realm _realm;
    private GameModel _gameModel;

    void OnEnable(){
        _realm = Realm.GetInstance();
        _gameModel = _realm.Find<GameModel>("nraboy");

        if (_gameModel == null){
            _realm.Write(() => {
                _gameModel = _realm.Add(new GameModel("nraboy", 0, 0, 0));
            });
        }
    }


    void OnDisable(){
        _realm.Dispose();
    }

    public void SetButtonScore(string color, int inc ){
        switch(color){
            case "RedSquare":
                _realm.Write(() => {
                    _gameModel.redScore += inc; 
                });
                break;
            case "GreenSquare":
                _realm.Write(() => {
                    _gameModel.greenScore += inc; 
                });
                break;  

            case "WhiteSquare":
                _realm.Write(() => {
                    _gameModel.whiteScore += inc; 
                });
                break;  

            default:
                Debug.Log("Color not found");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scroeText.text = "Red: " + _gameModel.redScore + "\n" 
        + "Green: " + _gameModel.greenScore + "\n"
        + "White: " + _gameModel.whiteScore + "\n";
    }
}
