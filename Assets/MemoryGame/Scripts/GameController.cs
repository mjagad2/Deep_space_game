using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite BgImage;
    [SerializeField]
    private GameObject winText;

    public List<Button> btns = new List<Button>();
    public Sprite[] puzzles;
    public List<Sprite> GamePuzzles = new List<Sprite>();

    private int countGuesses, countCorrectGuesses,gameGuesses;
    private bool firstGuess, secondGuess;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle,secondGuessPuzzle;
    public static bool youWin1;
    // Start is called before the first frame update
    


     void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites");


    }
    void Start()
    {
        
        winText.SetActive(false);
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        shuffle(GamePuzzles);
        gameGuesses = GamePuzzles.Count / 2;
    }
    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for(int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = BgImage;
       
        }
    }
    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;
        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }

            GamePuzzles.Add(puzzles[index]);
            index++;
        }
    }
    void AddListeners()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(() => PickupPuzzle());
        }
    }


    public void PickupPuzzle(){
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        Debug.Log("You are clicking a button");
        if(!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = GamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = GamePuzzles[firstGuessIndex];

        }else if (!secondGuess){
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = GamePuzzles[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = GamePuzzles[secondGuessIndex];
            countGuesses++;
            StartCoroutine(CheckIfThePuzzlesMatch());
        }
        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            Debug.Log("match");
        }
        

    }
    IEnumerator CheckIfThePuzzlesMatch()
    {
        yield return new WaitForSeconds(1f);
        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0,0,0,0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);


            checkIfTheGameIsFinished();

        }
        else
        {
            btns[firstGuessIndex].image.sprite = BgImage;
            btns[secondGuessIndex].image.sprite = BgImage;

        }
        yield return new WaitForSeconds(.5f);
        firstGuess = secondGuess = false;


    }

    private void checkIfTheGameIsFinished()
    {
        countCorrectGuesses++;
        if (countCorrectGuesses == gameGuesses) 
        {
            Debug.Log("all  match");
            youWin1 = true;
            winText.SetActive(true);

        }
    }
    void shuffle(List<Sprite> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = UnityEngine.Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}

