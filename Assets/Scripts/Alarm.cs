using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speedSoundChange;
    [SerializeField] private List<Animator> _houseBlock;

    private bool _isWork;
    private AudioSource _sound;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _sound.enabled = false;
        _sound.volume = 0;
    }

    private void OnTriggerEnter(Collider collider)
    {
        _isWork = true;

        if (collider.GetComponent<Thief>())
        {
            _sound.enabled = true;
            _sound.Play();

            ChangedAnimationHouse(_isWork);
            StopAllCoroutines();
            StartCoroutine(ChangeVolume(_maxVolume));
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        _isWork  = false;

        if (collider.GetComponent<Thief>())
        {
            StopAllCoroutines();
            StartCoroutine(ChangeVolume(_minVolume));
        }
    }

    private IEnumerator ChangeVolume(float endValue)
    {
        while (_sound.volume != endValue)
        {
            _sound.volume = Mathf.MoveTowards(
                _sound.volume, 
                endValue, 
                _speedSoundChange * Time.deltaTime);

            yield return null;
        }

        if (_sound.volume == _minVolume)
        {
            _sound.enabled = false;
            ChangedAnimationHouse(_isWork);
        }
    }

    private void ChangedAnimationHouse(bool isWork)
    {
        for (int i = 0; i < _houseBlock.Count; i++)
        {
            _houseBlock[i].GetComponent<Animator>().enabled = isWork;
        }
    }
}
