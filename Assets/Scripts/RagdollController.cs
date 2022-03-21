using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
	private bool isRagdoll;
	private Rigidbody mainRigidbody;
	private Collider mainCollider;
	private Animator animator;
	private List<Rigidbody> ragdollRigidbodies;
	private List<Collider> ragdollColliders;

	void Start()
	{
		//Load the variables
		mainRigidbody = GetComponent<Rigidbody>();
		mainCollider = GetComponent<Collider>();
		animator = GetComponent<Animator>();

		ragdollRigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
		ragdollColliders = new List<Collider>(GetComponentsInChildren<Collider>());

		//Remove the main Rigidbody and Collider from the list
		//Technically unnecessary as the Activate and Deactivate functions will handle this anyway, but still good to "idiot-proof"
		ragdollRigidbodies.Remove(mainRigidbody);
		ragdollColliders.Remove(mainCollider);

		//Start in correct Ragdoll setting
		if (isRagdoll)
		{
			ActivateRagdoll();
		}
		else
		{
			DeactivateRagdoll();
		}
	}

	public void ToggleRagdoll()
	{
		isRagdoll = !isRagdoll;
		if (isRagdoll)
		{
			ActivateRagdoll();
		}
		else
		{
			DeactivateRagdoll();
		}
	}

	public void ActivateRagdoll()
	{
		//Turn ON ALL of the ragdoll colliders
		foreach (Collider collider in ragdollColliders)
		{
			collider.enabled = true;
		}

		//Turn ON ALL of the ragdoll rigidbodies
		foreach (Rigidbody rb in ragdollRigidbodies)
		{
			rb.isKinematic = false;
		}

		//Turn OFF the main collider
		mainCollider.enabled = false;

		//Turn OFF the animator
		animator.enabled = false;

		//Turn OFF the main rigidbody
		mainRigidbody.isKinematic = true;
	}

	public void DeactivateRagdoll()
	{
		//Turn OFF ALL of the ragdoll colliders
		foreach (Collider collider in ragdollColliders)
		{
			collider.enabled = false;
		}

		//Turn OFF ALL of the ragdoll rigidbodies
		foreach (Rigidbody rb in ragdollRigidbodies)
		{
			rb.isKinematic = true;
		}

		//Turn ON the main collider
		mainCollider.enabled = true;

		//Turn ON the animator
		animator.enabled = true;

		//Turn ON the main rigidbody
		mainRigidbody.isKinematic = false;
	}
}
