using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

// Token: 0x02000013 RID: 19
public class Menu : MonoBehaviour
{
	// Token: 0x0600003B RID: 59 RVA: 0x000035E7 File Offset: 0x000017E7
	public void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x000035F5 File Offset: 0x000017F5
	public void ChooseDiff(int Which)
	{
		PlayerPrefs.SetInt("Difficulty", Which);
		PlayerPrefs.Save();
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00003607 File Offset: 0x00001807
	public void LoadItUp(string SceneName)
	{
		SceneManager.LoadSceneAsync(SceneName);
	}

	// Token: 0x0600003E RID: 62 RVA: 0x0000360F File Offset: 0x0000180F
	public void QuitTheFuckingGame()
	{
		
		Application.Quit();
		#if UNITY_EDITOR
		if (EditorApplication.isPlaying == true) {
			EditorApplication.ExitPlaymode();
		}
		#endif
	}
}
