using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000014 RID: 20
public class Paused : MonoBehaviour
{
	// Token: 0x06000040 RID: 64 RVA: 0x00003616 File Offset: 0x00001816
	private void Start()
	{
		if (this.Sens != null)
		{
			this.Sens.value = PlayerPrefs.GetFloat("sensitivity", 2f);
		}
	}

	// Token: 0x06000041 RID: 65 RVA: 0x00003634 File Offset: 0x00001834
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && !PlayerStatus.Died)
		{
			if (Paused.IsPaused)
			{
				this.Resume();
				return;
			}
			this.PauseUI.SetActive(true);
			Paused.IsPaused = true;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
			Time.timeScale = 0f;
		}

	}

	// Token: 0x06000042 RID: 66 RVA: 0x00003687 File Offset: 0x00001887
	public void Resume()
	{
		this.PauseUI.SetActive(false);
		Paused.IsPaused = false;
		Cursor.visible = false;
		Time.timeScale = 1f;
	}

	// Token: 0x06000043 RID: 67 RVA: 0x000036AB File Offset: 0x000018AB
	public void SendHimToTheMenu()
	{
		SceneManager.LoadScene("Menu");
		Paused.IsPaused = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
		Time.timeScale = 1f;
	}

	// Token: 0x06000044 RID: 68 RVA: 0x000036D3 File Offset: 0x000018D3
	public void SensNewSet()
	{
		PlayerPrefs.SetFloat("sensitivity", this.Sens.value);
		PlayerPrefs.Save();
	}

	// Token: 0x0400007D RID: 125
	public GameObject PauseUI;

	// Token: 0x0400007E RID: 126
	public Slider Sens;

	// Token: 0x0400007F RID: 127
	public static bool IsPaused;
}
