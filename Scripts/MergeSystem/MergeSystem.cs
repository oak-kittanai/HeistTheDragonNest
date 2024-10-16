using UnityEngine;

public class MergeSystem : MonoBehaviour
{
    [SerializeField] int _id;
    [Header("Upgrade")]
    [SerializeField] GameObject _mergeObject;

    Transform _mergeObjbect1;
    Transform _mergeObjbect2;

    [Header("Setting")]
    [SerializeField] float _distance;
    [SerializeField] float _mergeSpeed;

    [SerializeField] bool _canMerge;

    [SerializeField] string _selfTag;

    void Start()
    {
        _id = GetInstanceID();
    }

    private void OnEnable()
    {
        _selfTag = gameObject.tag;
    }

    private void FixedUpdate()
    {
        MergeTras();
    }

    void MergeTras()
    {
        if (_canMerge == true)
        {
            transform.position = Vector2.MoveTowards(_mergeObjbect1.position, _mergeObjbect2.position, _mergeSpeed);
            if (Vector2.Distance(_mergeObjbect1.position, _mergeObjbect2.position) < _distance)
            {
                if (_id < _mergeObjbect2.gameObject.GetComponent<MergeSystem>()._id) { return; }
                GameObject UpgradeGameObject = Instantiate(_mergeObject, transform.position, Quaternion.identity) as GameObject;

                Destroy(_mergeObjbect2.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_selfTag))
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == gameObject.GetComponent<SpriteRenderer>().color) // Change the color to the Sprite
            {
                // Check The Sprite For the Score to add


                _mergeObjbect1 = transform;
                _mergeObjbect2 = collision.transform;
                _canMerge = true;
                
                Destroy(_mergeObjbect2.gameObject.GetComponent<Rigidbody2D>()); 
                Destroy(GetComponent<Rigidbody2D>());
            }
        }
    }
}
