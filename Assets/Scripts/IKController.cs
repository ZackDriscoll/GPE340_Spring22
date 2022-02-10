using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{
    public Pawn pawn;
    private float rightHandWeight = 1.0f;
    private float leftHandWeight = 1.0f;

    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        pawn = GetComponent<Pawn>();
    }

    public void OnAnimatorIK(int layerIndex)
    {
        //Check that we have a weapon, because if no weapon, no IK
        if (pawn.weapon == null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);

            //Exit out of the function
            return;
        }

        //However, if weapon, then, we use the rightHandPoint and leftHandPoint
        //  NOTE: In the game itself, these will come from the Weapon. The Weapon tells you it's point

        //Get the points from the weapon
        if (pawn.weapon.RHPoint == null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
        }
        else
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, pawn.weapon.RHPoint.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand, pawn.weapon.RHPoint.rotation);
        }

        if (pawn.weapon.LHPoint == null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
        }
        else
        {
            anim.SetIKPosition(AvatarIKGoal.LeftHand, pawn.weapon.LHPoint.position);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, pawn.weapon.LHPoint.rotation);
        }

        //Tell the animator to move the hand to the position and rotation
        
        

       /* anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandWeight);
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandWeight);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);*/
    }
}
