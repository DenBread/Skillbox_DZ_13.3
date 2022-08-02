using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _allRig;

    private void Awake()
    {
        for (int i = 0; i < _allRig.Length; i++)
        {
            _allRig[i].isKinematic = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MakePhysical();
        }
    }

    private void MakePhysical()
    {
        _animator.enabled = false;
        for (int i = 0; i < _allRig.Length; i++)
        {
            _allRig[i].isKinematic = false;
        }
    }
}
