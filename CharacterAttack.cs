
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
	public float range = 3.0f;    //Attack range
	public int knives = 1;   //One throwable knife

	public Transform attackPoint;    //Point knife is swung
	public GameObject hitParticles; //Attack impact

	public float slashRate = 1.0f;   //Speed player can slash while holding down m1
	float slashTimer;    //Time counter for slash rate

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetButton("Fire1"))
		{
			if (knives > 0)
				Fire(); //Attack when button is held
		}

		if (slashTimer < slashRate)
			slashTimer += Time.deltaTime;    //Add to time counter
	}

	void FixedUpdate()
	{

	}

	private void Fire()
	{
		if (slashTimer < slashRate) return;
		Debug.Log("Fire!");


		RaycastHit hit;

		if (Physics.Raycast(attackPoint.position, attackPoint.transform.forward, out hit, range))
		{
			Debug.Log("hit");

			//GameObject hitParticleEffect = Instantiate(hitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

			//Destroy(hitParticleEffect, 1f);
		}

		slashTimer = 0.0f;   //Reset fire timer
	}
}