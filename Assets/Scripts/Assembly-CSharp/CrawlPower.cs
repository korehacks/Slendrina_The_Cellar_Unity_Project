using System;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class CrawlPower : MonoBehaviour
{
	// Token: 0x06000010 RID: 16 RVA: 0x00002744 File Offset: 0x00000944
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.CrawlFace.SetActive(true);
			this.CrawlFace.GetComponent<CrawlFace>().StartHunt();
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x0400002D RID: 45
	public GameObject CrawlFace;
}
