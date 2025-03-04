using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [Header("Prefab Setting")]
    [SerializeField] GameObject[] _itemCoinPrefab;//Change The name later
    [SerializeField] bool _isReadyToDrop;
    public int _itemPrefab;

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
        UpdateMousePos();
        InstantiateItem();
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
        if (_itemPrefab == null)
        {
            _itemPrefab = Random.Range(0, _itemCoinPrefab.Length);
        }
    }

    void InstantiateItem() 
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_isReadyToDrop)
            {
                StartCoroutine(ReadyToDropPrefab());
                _isReadyToDrop = false;
            }
            
        }
    }

    IEnumerator ReadyToDropPrefab()
    {
        yield return new WaitForSeconds(1f);

        Instantiate(_itemCoinPrefab[_itemPrefab], _transform.position, _transform.rotation); // need to use Gamemanger GameObject to be Deploy
        _isReadyToDrop = true;
    }
}
