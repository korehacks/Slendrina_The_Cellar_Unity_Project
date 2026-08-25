using System;
using UnityEngine;

// Token: 0x0200000D RID: 13
public class HeadAway : MonoBehaviour
{
	// Token: 0x0600002A RID: 42 RVA: 0x00002D38 File Offset: 0x00000F38
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.AnimH.Play("SlendrinaHeadDoor");
			AudioSource.PlayClipAtPoint(this.Scare, base.transform.position);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04000059 RID: 89
	public Animation AnimH;

	// Token: 0x0400005A RID: 90
	public AudioClip Scare;
}
