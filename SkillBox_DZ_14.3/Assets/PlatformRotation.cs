using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    [SerializeField] private float _time;
    private HingeJoint _hingeJoint;
    private JointSpring _jointSpring;

    private void Start()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _jointSpring = new JointSpring();
        _jointSpring.spring = 100f;
     
        StartCoroutine(Rotation());
    }

    private IEnumerator Rotation()
    {
        while (true)
        {
            _jointSpring.targetPosition = 0;
            _hingeJoint.spring = _jointSpring;
            yield return new WaitForSeconds(_time);
            
            _jointSpring.targetPosition = 180;
            _hingeJoint.spring = _jointSpring;
            yield return new WaitForSeconds(_time);
            
        }
    }
}
