using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeBetweenCreatingMobs = 2f;
    [SerializeField] private Vector3 _firstPlaceOfAddingInScene;
    [SerializeField] private Vector3 _secondPlaceOfAddingInScene;

    public GameObject _mod;
    void Start()
    {
        StartCoroutine(CreateMobs());
    }
    private IEnumerator CreateMobs()
    { 
            while(true)
            {
                Instantiate(_mod,_firstPlaceOfAddingInScene, Quaternion.identity);
                yield return new WaitForSeconds(_timeBetweenCreatingMobs);
                Instantiate(_mod, _secondPlaceOfAddingInScene, Quaternion.identity);
                yield return new WaitForSeconds(_timeBetweenCreatingMobs);
            }
    }
}
