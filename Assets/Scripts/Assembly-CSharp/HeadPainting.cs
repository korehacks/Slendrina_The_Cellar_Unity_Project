using System;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class HeadPainting : MonoBehaviour
{
	// Token: 0x06000030 RID: 48 RVA: 0x00002E50 File Offset: 0x00001050
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.AnimH.Play("HeadTavla");
			AudioSource.PlayClipAtPoint(this.Scare, base.transform.position);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04000060 RID: 96
	public Animation AnimH;

	// Token: 0x04000061 RID: 97
	public AudioClip Scare;
}
