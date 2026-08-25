using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class Bucket : MonoBehaviour
{
	// Token: 0x06000008 RID: 8 RVA: 0x00002640 File Offset: 0x00000840
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.AnimH.Play("FlyingHink");
			AudioSource.PlayClipAtPoint(this.Scare, base.transform.position);
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
			}
		}
	}

	// Token: 0x04000024 RID: 36
	public Animation AnimH;

	// Token: 0x04000025 RID: 37
	public AudioClip Scare;
}
