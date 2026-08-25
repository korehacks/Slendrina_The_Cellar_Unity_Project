using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200001E RID: 30
public class ChatController : MonoBehaviour
{
	// Token: 0x06000060 RID: 96 RVA: 0x00003A5E File Offset: 0x00001C5E
	private void OnEnable()
	{
		this.ChatInputField.onSubmit.AddListener(new UnityAction<string>(this.AddToChatOutput));
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00003A7C File Offset: 0x00001C7C
	private void OnDisable()
	{
		this.ChatInputField.onSubmit.RemoveListener(new UnityAction<string>(this.AddToChatOutput));
	}

	// Token: 0x06000062 RID: 98 RVA: 0x00003A9C File Offset: 0x00001C9C
	private void AddToChatOutput(string newText)
	{
		this.ChatInputField.text = string.Empty;
		DateTime now = DateTime.Now;
		string text = string.Concat(new string[]
		{
			"[<#FFFF80>",
			now.Hour.ToString("d2"),
			":",
			now.Minute.ToString("d2"),
			":",
			now.Second.ToString("d2"),
			"</color>] ",
			newText
		});
		if (this.ChatDisplayOutput != null)
		{
			if (this.ChatDisplayOutput.text == string.Empty)
			{
				this.ChatDisplayOutput.text = text;
			}
			else
			{
				TMP_Text chatDisplayOutput = this.ChatDisplayOutput;
				chatDisplayOutput.text = chatDisplayOutput.text + "\n" + text;
			}
		}
		this.ChatInputField.ActivateInputField();
		this.ChatScrollbar.value = 0f;
	}

	// Token: 0x040000A0 RID: 160
	public TMP_InputField ChatInputField;

	// Token: 0x040000A1 RID: 161
	public TMP_Text ChatDisplayOutput;

	// Token: 0x040000A2 RID: 162
	public Scrollbar ChatScrollbar;
}
