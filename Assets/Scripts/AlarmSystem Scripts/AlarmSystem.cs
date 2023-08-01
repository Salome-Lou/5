using System.Collections;
using UnityEngine;

public class AlarmSystem: MonoBehaviour
{ 
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private  float _volumeStep = 0.1f;
    [SerializeField] private  float _timeOfOneSignal = 1f;
    [SerializeField] private  float _maxVolume = 1f;

    private static float _minVolume = 0f;
    private float _alarmVolume= _minVolume;
    private float _targetVolume;

    private void OnTriggerEnter(Collider collider )
    {
        {
            if (collider.TryGetComponent<CharacterController>(out CharacterController player))
            {
                if (_alarmVolume == _minVolume)
                {
                    _alarmVolume = _volumeStep;
                    StopAllCoroutines();
                    StartCoroutine(PlaySound());
                }
                else
                {
                    _targetVolume = _maxVolume;
                }
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<CharacterController>(out CharacterController player))
        {
            _targetVolume = _minVolume;
        }
    }

    private IEnumerator PlaySound()
    {
        _targetVolume = _maxVolume;

        while (_alarmVolume != _minVolume)
        {   
            _alarmVolume = Mathf.MoveTowards(_alarmVolume, _targetVolume, _volumeStep);
            _alarmSound.volume = _alarmVolume;
            Debug.Log(_alarmSound.volume);
            _alarmSound.Play();
            yield return new WaitForSeconds(_timeOfOneSignal);
        }
    }
}

    
