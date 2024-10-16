using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    

    [SerializeField] Transform _transform;

    [SerializeField] Camera _cameraMain;
    [SerializeField] Vector2 _mousePos;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (_transform == null)
        {
            _transform = this.transform;
        }
        _cameraMain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    void Update()
    {
        if (GameManager.Instance.isStartGame)
        {
            UpdateMousePos();
            InstantiateItem();
        }
        CheckPrefabIndex();
    }

    void UpdateMousePos()
    {
        if (Input.GetMouseButton(0)) // need to add limit to right and left
        {
            _mousePos = _cameraMain.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector2(_mousePos.x, 0);
        }
    }

    void CheckPrefabIndex()
    {
        if (GameManager.Instance.IsRandomGameobject)
        {
            GameManager.Instance.itemPrefab = Random.Range(0, GameManager.Instance._itemCoinPrefab.Length);
            GameManager.Instance.IsRandomGameobject = false;
        }
    }

    void InstantiateItem() 
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (GameManager.Instance._isReadyToDrop)
            {
                StartCoroutine(ReadyToDropPrefab());
                GameManager.Instance._isReadyToDrop = false;
            }
            
        }
    }

    IEnumerator ReadyToDropPrefab()
    {
        Instantiate(GameManager.Instance._itemCoinPrefab[GameManager.Instance.itemPrefab], _transform.position, _transform.rotation); // need to use Gamemanger GameObject to be Deploy
        GameManager.Instance.IsRandomGameobject = true;
        yield return new WaitForSeconds(1f);

        GameManager.Instance._isReadyToDrop = true;
        
    }
}
