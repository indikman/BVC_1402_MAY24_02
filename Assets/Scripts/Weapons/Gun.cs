using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField] 
	Transform firePoint;
	
	[SerializeField]
	string bulletPoolName;
	
	[SerializeField]
	float bulletForce = 15f;
	
	
	public virtual void Shoot(Vector2 additionalVelocity = new Vector2())
	{
		// here, we will be using the pool manager instead of instantiate
		// Bullet bullet = Instantiate<Bullet>(bulletPrefab, firePoint);
		Bullet bullet = (Bullet)PoolManager.Instance.Spawn(bulletPoolName);
		
		bullet.transform.position = firePoint.transform.position;
		bullet.transform.rotation = firePoint.transform.rotation;
		
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //we create a new copy of a bullet and then we get its rigid body
		rb.velocity = additionalVelocity;
		rb?.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); //we add a force but we add an impulse force to represent a gun, because it is an impulse force
	}
	
}
