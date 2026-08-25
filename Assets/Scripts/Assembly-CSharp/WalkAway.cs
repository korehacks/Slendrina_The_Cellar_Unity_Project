using System;
using UnityEngine;

// Token: 0x0200001D RID: 29
public class WalkAway : MonoBehaviour
{
	// Token: 0x0600005E RID: 94 RVA: 0x00003A08 File Offset: 0x00001C08
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.AnimH.Play("SlendrinaWalk");
			AudioSource.PlayClipAtPoint(this.Scare, base.transform.position);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400009E RID: 158
	public Animation AnimH;

	// Token: 0x0400009F RID: 159
	public AudioClip Scare;
}
