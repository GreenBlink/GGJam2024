using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlay : MonoBehaviour
{
    [SerializeField] private Animator _animator;


    private void Awake()
    {
        _animator.Play("Comics");
    }
}
