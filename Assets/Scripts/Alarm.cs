using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Events;


public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speedSoundChange;
    [SerializeField]private Animator[] _blocks;

    private string _animationTrigerInBlock = "Alarm";
    private AudioSource _sound;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _sound.enabled = false;
        _sound.volume = 0;
    }

    public void OnSignal()
    {
        float finishVolume = _maxVolume;

        _sound.enabled = true;
        _sound.Play();

        OnTrigerBlock();

        StopAllCoroutines();
        StartCoroutine(ChangeVolume(finishVolume));
    }

    public void OffSignal()
    {
        float finishVolume = _minVolume;

        OnTrigerBlock();

        StopAllCoroutines();
        StartCoroutine(ChangeVolume(finishVolume));
    }

    private void OnTrigerBlock()
    {
        foreach (var block in _blocks)
        {
            block.SetTrigger(_animationTrigerInBlock);
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
        }
    }
}