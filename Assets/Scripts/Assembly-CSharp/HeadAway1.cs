using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class HeadAway1 : MonoBehaviour
{
	// Token: 0x0600002C RID: 44 RVA: 0x00002D90 File Offset: 0x00000F90
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.AnimH.Play("SlendrinaHeadDoor");
			this.Door.Play("DoorSlam");
			AudioSource.PlayClipAtPoint(this.Scare, base.transform.position);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400005B RID: 91
	public Animation AnimH;

	// Token: 0x0400005C RID: 92
	public AudioClip Scare;

	// Token: 0x0400005D RID: 93
	public Animation Door;
}
