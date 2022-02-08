using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{
    public Transform rightHandPoint;
    public Transform leftHandPoint;
    public float rightHandWeight;
    public float leftHandWeight;

    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnAnimatorIK(int layerIndex)
    {
        //TODO: Check that we have a weapon, because if no weapon, no IK

        //However, if weapon, then, we use the rightHandPoint and leftHandPoint
        //  NOTE: In the game itself, these will come from the Weapon.  The Weapon tells you it's point

        //Tell the animator to move the hand to the position and rotation
        anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandPoint.position);
        anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPoint.position);

        anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandPoint.rotation);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandPoint.rotation);

        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandWeight);
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandWeight);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);
    }
}
