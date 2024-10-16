using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Group UI")]
    [SerializeField] GameObject _countdownGroup;

    [Header("CountDown UI")]
    [SerializeField] TMP_Text _countDownTimeText;

    void Start()
    {

    }


    void Update()
    {
        UpdataRandomGameObject();
        CountdownUpdate();
    }

    void UpdataRandomGameObject() // Need this to show what next
    {
        //GameObject CurrentGameObject = ;//PlayerController.Instance.gameObjects[GameManager.Instance._itemPrefab];
    }

    #region Countdown UI

    void CountdownUpdate() // Fix this
    {
        _countDownTimeText.text = GameManager.Instance.CountdownTime.ToString();

        if (GameManager.Instance.CountdownTime <= 0)
        {
            _countdownGroup.SetActive(false);
        }
    }

    #endregion
}
