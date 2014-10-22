using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class GUITextSpawner
{
	private List<GameObject> GUITextObjects;
	
	private string defaultText;
	public Vector2 defaultCoords;
	private int defaultFontSize;
	private FontStyle defaultFontStyle;
	private Color defaultColor;
	
	public GUITextSpawner() {
		defaultText = "";
		defaultCoords = new Vector2(0,0);
		defaultFontSize = 15;
		defaultFontStyle = FontStyle.Normal;
		defaultColor = Color.black;
		
		GUITextObjects = new List<GameObject> ();
	}
	
	public void SetDefaultSettings(string text, Vector2 coordinates, 
	                               int fontSize, Font font, FontStyle style, Color color) {
		defaultText = text;
		defaultCoords = coordinates;
		defaultFontSize = fontSize;
		defaultFontStyle = style;
		defaultColor = color;
	}
	
	public void ClearAll() {
		foreach (GameObject gObj in GUITextObjects) {
			Object.Destroy(gObj, 0);
		}
	}
	
	public void ClearText(GameObject guiText) {
		Object.Destroy(guiText, 0);
	}
	
	public void ClearText(string text) {
		foreach (GameObject gObj in GUITextObjects) {
			if (gObj.guiText.text == text) {
				Object.Destroy(gObj, 0);
			}
		}
	}
	
	public GameObject SpawnNew(string text) {
		GameObject newGuiText = new GameObject ();
		newGuiText.AddComponent (typeof(GUIText));
		newGuiText.guiText.text = text;
		newGuiText.guiText.fontSize = 15;
		newGuiText.guiText.fontStyle = defaultFontStyle;
		newGuiText.guiText.color = defaultColor;
		newGuiText.transform.position = 
			Camera.main.WorldToViewportPoint(defaultCoords);
		
		GUITextObjects.Add (newGuiText);
		
		return newGuiText;
	}
	
	public GameObject SpawnNew(string text, int? lineCharWidth, Vector2? coordinates, 
	                           int? fontSize, string fontName, FontStyle? style, Color? color) {
		GameObject newGuiText = new GameObject ();
		newGuiText.AddComponent (typeof(GUIText));
		
		if (text != null && lineCharWidth != null && lineCharWidth > 0) {
			StringBuilder stringBuilder = new StringBuilder ();
			bool appendReturn = false;
			
			for (int i =0; i < text.Length; i++) {
				Debug.Log("Current character: " + text[i].ToString());
				Debug.Log ("Current stringBuilder: " + stringBuilder.ToString());
				if (appendReturn == true) {
					stringBuilder.Append("\n");
					appendReturn = false;
					continue;
				}
				if ((i+1)%lineCharWidth == 0 && i > 0 && 
				    (string.Compare(text[i].ToString(), " ") == 0)){
					appendReturn = true;
				}
				
				stringBuilder.Append(text[i]);
			}
			text = stringBuilder.ToString();
			newGuiText.guiText.text = text;
		}
		if (fontSize != null) {
			newGuiText.guiText.fontSize = (int)fontSize;
		} else {
			newGuiText.guiText.fontSize = defaultFontSize;
		}
		if (style != null) {
			newGuiText.guiText.fontStyle = (FontStyle)style;
		} else {
			newGuiText.guiText.fontStyle = defaultFontStyle;
		}
		if (fontName != null) {
			Font font = (Font)Resources.Load("Fonts/" + "fontName");
			newGuiText.guiText.font = font;
		}
		if (color != null) {
			newGuiText.guiText.color = (Color)color;
		} else {
			newGuiText.guiText.color = defaultColor;
		}
		if (coordinates != null) {
			newGuiText.transform.position = 
				Camera.main.WorldToViewportPoint((Vector2)coordinates);
		} else {
			newGuiText.transform.position = 
				Camera.main.WorldToViewportPoint(defaultCoords);
		}
		
		GUITextObjects.Add (newGuiText);
		
		return newGuiText;
	}	
	
	public GameObject SpawnNew(string text, Vector2? coordinates, 
	                           int? fontSize, string fontName, FontStyle? style, Color? color) {
		GameObject newGuiText = new GameObject ();
		newGuiText.AddComponent (typeof(GUIText));
		if (text != null) {
			newGuiText.guiText.text = text;
		}
		if (fontSize != null) {
			newGuiText.guiText.fontSize = (int)fontSize;
		}
		if (style != null) {
			newGuiText.guiText.fontStyle = (FontStyle)style;
		}
		if (fontName != null) {
			Font font = (Font)Resources.Load("Fonts/" + "fontName");
			newGuiText.guiText.font = font;
		}
		if (color != null) {
			newGuiText.guiText.color = (Color)color;
		}
		if (coordinates != null) {
			newGuiText.transform.position = 
				Camera.main.WorldToViewportPoint((Vector2)coordinates);
		}
		
		GUITextObjects.Add (newGuiText);
		
		return newGuiText;
	}
}

