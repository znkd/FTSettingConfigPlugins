using UnityEngine;
using UnityEditor;
using System.Collections;

using System.Xml;

public class FTSettingConfigWnd : EditorWindow {
	static string[][] fishroutingArray = new string[10][];

	static int WINDOW_WIDTH = (420);
	
	static int WINDOW_HEIGHT_MIN = (200);
	static int WINDOW_HEIGHT_MAX = (600);
	static bool bNeed = false;
#region Main Methods    //???????
	static FTSettingConfigWnd baseWnd;

	[MenuItem ("FTFishRoutingConfig/FishRoutingConfig...")]

	static void Init () {
		// Get existing open window or if none, make a new one:		
		baseWnd = (FTSettingConfigWnd)EditorWindow.GetWindow(typeof(FTSettingConfigWnd));
		baseWnd.titleContent = new GUIContent("Config");
		baseWnd.minSize = new Vector2(WINDOW_WIDTH,WINDOW_HEIGHT_MIN);
		baseWnd.maxSize = new Vector2(WINDOW_WIDTH,WINDOW_HEIGHT_MAX);
		readConfigFile();
		bNeed = true;
	}

	void OnGUI () {
	//	layoutForInit();
	}
	#endregion

	static void layoutForInit()
	{

		Debug.Log("sdfdsafdasgsdafdsa");
		//1: Lable->(fishtype)   textfield->(routetype) 
		GUILayout.BeginVertical();
		
		GUILayoutOption guiFishTypeWidth = GUILayout.Width(100);
		
		//header
		GUILayout.BeginHorizontal();
		GUILayout.Space(20);
		
		GUILayout.BeginVertical();
		GUILayout.Space(10);
		
		GUILayout.Label("fishtype",guiFishTypeWidth);
		
		GUILayout.Space(10);
		GUILayout.EndVertical();
		
		
		GUILayout.BeginVertical();
		GUILayout.Space(10);
		
		GUILayout.Label("routetype",guiFishTypeWidth);
		
		GUILayout.Space(10);
		GUILayout.EndVertical();
		
		GUILayout.EndHorizontal();
		
		//config file content
		for(int i = 0; i<10; i++)
		{
			horizontalLayoutLabelAndtextfield(fishroutingArray[i]);
		}
		
		//write file button
		GUILayout.Space(40);
		
		//GUILayoutOption options = GUILayoutOption(new uiFishTypeWidth,GUILayout.Height(80));
		GUILayout.Button("save config file",GUILayout.Width(200),GUILayout.Height(40));
		
		GUILayout.EndVertical();
	}
	static void horizontalLayoutLabelAndtextfield(string[] arr)
	{
		GUILayout.BeginHorizontal();
		GUILayout.Space(20);
		
		GUILayout.BeginVertical();
		GUILayout.Space(10);
		
		GUILayout.TextField(arr[0],GUILayout.Width(80));
		
		GUILayout.Space(10);
		GUILayout.EndVertical();

		
		GUILayout.BeginVertical();
		GUILayout.Space(10);
		
		GUILayout.TextField(arr[1],GUILayout.Width(80));
		
		GUILayout.Space(10);
		GUILayout.EndVertical();
		
		GUILayout.EndHorizontal();
	}

	static void readConfigFile()
	{
		XmlDocument doc = new XmlDocument();
		doc.Load("Assets/Scripts/fishAndrouting.xml");
		XmlNode root = doc.SelectSingleNode("config");
		XmlNodeList nodelist = root.ChildNodes;
		int elementsCnt = nodelist.Count;

		for(int i =0; i<elementsCnt; i++)
		{
			XmlElement elem = (XmlElement)(nodelist.Item(i));
			string fishtype = elem.GetAttribute("fishtype").ToString();
			string routingtype = nodelist[i].InnerText;
			Debug.Log(fishtype+"/"+routingtype);

			if(i < 10)
			{
				fishroutingArray[i][0] = fishtype.ToString();

				fishroutingArray[i][1] = routingtype.ToString();
			}
		}
	
		Debug.Log(fishroutingArray[9][0]+"$$$$"+fishroutingArray[9][1]);
	}
}
