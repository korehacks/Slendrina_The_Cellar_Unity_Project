using System;
using UnityEngine;

// Token: 0x0200000F RID: 15
public class HeadAway2 : MonoBehaviour
{
	// Token: 0x0600002E RID: 46 RVA: 0x00002DF8 File Offset: 0x00000FF8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.AnimH.Play("SlendrinaHeadDoor2");
			AudioSource.PlayClipAtPoint(this.Scare, base.transform.position);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400005E RID: 94
	public Animation AnimH;

	// Token: 0x0400005F RID: 95
	public AudioClip Scare;
}
