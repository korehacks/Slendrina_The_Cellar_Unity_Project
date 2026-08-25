using System;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class DesTrigger : MonoBehaviour
{
	// Token: 0x06000017 RID: 23 RVA: 0x000028B1 File Offset: 0x00000AB1
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && !this.TP.Scared)
		{
			UnityEngine.Object.Destroy(this.TP.gameObject);
		}
	}

	// Token: 0x0400003C RID: 60
	public TriggerPC TP;
}
