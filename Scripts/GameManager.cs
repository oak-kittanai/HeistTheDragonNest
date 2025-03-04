using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Prefab Setting")]
    public GameObject[] _itemCoinPrefab;//Change The name later
    public bool _isReadyToDrop = true;
    public bool IsRandomGameobject;
    public int itemPrefab;

    [Header("Countdown Setting")]
    public int CountdownTime = 3;
    [SerializeField] bool _isStartCDT = true;

    public int itemIndex;
    public bool isRandom;

    [Header("Score")]
    [SerializeField] int _currentScore;
    [SerializeField] int _highScore;

    [Header("Setting")]
    public bool isStartGame;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        Debug.Log(itemIndex);
        CheckGameStart();

    }

    public void CheckTheCurrentGameObject()
    {
        if (isRandom) // Need to Check the Current GameObject to the UI And let the Ui show the next Item
        {
            
            //itemIndex = Random.Range(0, gameObjects.Length);
        }
        
    }
    void CheckGameStart()
    {
        if (isStartGame)
        {
            Time.timeScale = 1;
            if (_isStartCDT)
            {
                StartCoroutine(CountdownStart());
                _isStartCDT = false;
            }
        }
        else
        {
            Time.timeScale = 0;
        }
        
    }

    #region Countdown Time

    IEnumerator CountdownStart()// Fix this
    {
        while (CountdownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            CountdownTime--;
        }

    }

    #endregion

    public void StartGameButton()
    {
        isStartGame = true;
    }
}
