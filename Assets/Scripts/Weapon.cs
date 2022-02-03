using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    //Header for events
    [Header("Events")]

    //Unity Events for shooting mechanics
    public UnityEvent OnShoot;
    public UnityEvent OnPullTrigger;
    public UnityEvent OnReleaseTrigger;
    public UnityEvent OnAlternateAttackStart;
    public UnityEvent OnAlternateAttackEnd;
    public UnityEvent OnReload;

    //Header for states
    [Header("States")]
    public bool isAutoFiring;

    //Header for data
    [Header("Data")]    
    public float fireDelay; //Seconds between shots    
    private float countdown; //Timer for shots

    // Start is called before the first frame update
    public virtual void Start()
    {
        countdown = fireDelay;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //Subtract the time it took to play the last fram from our countdown
        countdown -= Time.deltaTime;

        if (isAutoFiring && countdown <= 0)
        {
            //Shoot
            OnShoot.Invoke();

            //Reset timer
            countdown = fireDelay;
        }
    }

    public void Shoot()
    {
        OnShoot.Invoke();
    }

    public void StartAutoFire()
    {
        isAutoFiring = true;
    }

    public void EndAutoFire()
    {
        isAutoFiring = false;
    }

    public void ToggleAutoFire()
    {
        isAutoFiring = !isAutoFiring;
    }
}
