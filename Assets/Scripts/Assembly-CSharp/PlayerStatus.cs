using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000015 RID: 21
public class PlayerStatus : MonoBehaviour
{
	// Token: 0x06000046 RID: 70 RVA: 0x00002696 File Offset: 0x00000896
	private void Start()
	{
	}

	// Token: 0x06000047 RID: 71 RVA: 0x000036EF File Offset: 0x000018EF
	private void Update()
	{
		if (this.Health <= 0.1f && !PlayerStatus.Died)
		{
			PlayerStatus.Died = true;
			this.Dies();
		}
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00003714 File Offset: 0x00001914
	public void Dies()
	{
		this.Sounds.SetActive(false);
		this.Player.SetActive(false);
		this.SlendrinaFace.SetActive(true);
		this.Dot.SetActive(false);
		this.Ring.SetActive(false);
		this.Keys.SetActive(false);
		this.Need.SetActive(false);
		this.PageA.SetActive(false);
		base.GetComponent<Paused>().enabled = false;
		this.FPS.enabled = false;
		this.FPS.CameraAnim.enabled = false;
		base.StartCoroutine(this.TimerDied());
	}

	// Token: 0x06000049 RID: 73 RVA: 0x000037B7 File Offset: 0x000019B7
	private IEnumerator TimerDied()
	{
		yield return new WaitForSeconds(1.7f);
		this.Black.CrossFadeAlpha(1f, 0.3f, false);
		yield return new WaitForSeconds(2f);
		this.Gameover.SetActive(true);
		yield return new WaitForSeconds(4f);
		PlayerStatus.Died = false;
		SceneManager.LoadScene("Menu");
		yield break;
	}

	// Token: 0x04000080 RID: 128
	public float Health = 1f;

	// Token: 0x04000081 RID: 129
	public static bool Died;

	// Token: 0x04000082 RID: 130
	public GameObject Player;

	// Token: 0x04000083 RID: 131
	public GameObject SlendrinaFace;

	// Token: 0x04000084 RID: 132
	public GameObject Dot;

	// Token: 0x04000085 RID: 133
	public GameObject Ring;

	// Token: 0x04000086 RID: 134
	public GameObject Keys;

	// Token: 0x04000087 RID: 135
	public GameObject Need;

	// Token: 0x04000088 RID: 136
	public GameObject PageA;

	// Token: 0x04000089 RID: 137
	public GameObject Gameover;

	// Token: 0x0400008A RID: 138
	public GameObject Sounds;

	// Token: 0x0400008B RID: 139
	public Image Black;

	// Token: 0x0400008C RID: 140
	public FPSControl FPS;
}
