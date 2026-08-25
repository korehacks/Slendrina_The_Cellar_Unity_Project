using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200001C RID: 28
public class TriggerPC : MonoBehaviour
{
	// Token: 0x0600005B RID: 91 RVA: 0x0000398C File Offset: 0x00001B8C
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && !this.Scared)
		{
			this.Scared = true;
			AudioSource.PlayClipAtPoint(this.Scare, base.transform.position);
			base.StartCoroutine(this.TimerPC());
			this.PC.material.mainTexture = this.Lol;
		}
	}

	// Token: 0x0600005C RID: 92 RVA: 0x000039F8 File Offset: 0x00001BF8
	private IEnumerator TimerPC()
	{
		yield return new WaitForSeconds(0.7f);
		this.PC.material.mainTexture = null;
		this.PC.material.color = Color.black;
		yield return new WaitForSeconds(0.1f);
		this.PC.material.mainTexture = this.Lol;
		this.PC.material.color = Color.white;
		yield return new WaitForSeconds(0.2f);
		this.PC.material.mainTexture = null;
		this.PC.material.color = Color.black;
		yield break;
	}

	// Token: 0x0400009A RID: 154
	public AudioClip Scare;

	// Token: 0x0400009B RID: 155
	public bool Scared;

	// Token: 0x0400009C RID: 156
	public Renderer PC;

	// Token: 0x0400009D RID: 157
	public Texture Lol;
}
