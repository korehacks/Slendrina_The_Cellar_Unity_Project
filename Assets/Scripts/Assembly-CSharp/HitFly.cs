using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000011 RID: 17
public class HitFly : MonoBehaviour
{
	// Token: 0x06000032 RID: 50 RVA: 0x00002696 File Offset: 0x00000896
	private void Start()
	{
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00002696 File Offset: 0x00000896
	private void Update()
	{
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00002EA8 File Offset: 0x000010A8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "flyHead" && !this.Attacked)
		{
			this.AI.BorderBloodValue = 1f;
			this.Attacked = true;
			this.FPS.enabled = false;
			this.Anim.Play("PlayerFall");
			base.StartCoroutine(this.TimerFall());
		}
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00002F15 File Offset: 0x00001115
	private IEnumerator TimerFall()
	{
		yield return new WaitForSeconds(this.Anim["PlayerFall"].length);
		this.Attacked = false;
		this.FPS.enabled = true;
		yield break;
	}

	// Token: 0x04000062 RID: 98
	public Animation Anim;

	// Token: 0x04000063 RID: 99
	public bool Attacked;

	// Token: 0x04000064 RID: 100
	public FPSControl FPS;

	// Token: 0x04000065 RID: 101
	public AI_Slendrina AI;
}
