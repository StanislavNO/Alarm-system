﻿using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speedSoundChange;
    [SerializeField] private Animator[] _blocks;

    private AudioSource _sound;
    private string _animationTrigerInBlock = "Alarm";

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
        _sound.enabled = true;
        _sound.Play();

        OnTrigerBlock();

        StopAllCoroutines();
        StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void OffSignal()
    {
        OnTrigerBlock();

        StopAllCoroutines();
        StartCoroutine(ChangeVolume(_minVolume));
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