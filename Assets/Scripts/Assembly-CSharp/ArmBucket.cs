using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class ArmBucket : MonoBehaviour
{
	// Token: 0x06000006 RID: 6 RVA: 0x000025E0 File Offset: 0x000007E0
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.AnimH.Play("Arm");
			AudioSource.PlayClipAtPoint(this.Scare, base.transform.position);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04000022 RID: 34
	public Animation AnimH;

	// Token: 0x04000023 RID: 35
	public AudioClip Scare;
}
