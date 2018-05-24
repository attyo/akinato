using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class BoardGameDataForUnity_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/ExcelData/BoardGameDataForUnity.xls";
	private static readonly string exportPath = "Assets/ExcelData/BoardGameDataForUnity.asset";
	private static readonly string[] sheetNames = { "Sheet1", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			BOlist data = (BOlist)AssetDatabase.LoadAssetAtPath (exportPath, typeof(BOlist));
			if (data == null) {
				data = ScriptableObject.CreateInstance<BOlist> ();
				AssetDatabase.CreateAsset ((ScriptableObject)data, exportPath);
				data.hideFlags = HideFlags.NotEditable;
			}
			
			data.sheets.Clear ();
			using (FileStream stream = File.Open (filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
				IWorkbook book = null;
				if (Path.GetExtension (filePath) == ".xls") {
					book = new HSSFWorkbook(stream);
				} else {
					book = new XSSFWorkbook(stream);
				}
				
				foreach(string sheetName in sheetNames) {
					ISheet sheet = book.GetSheet(sheetName);
					if( sheet == null ) {
						Debug.LogError("[QuestData] sheet not found:" + sheetName);
						continue;
					}

					BOlist.Sheet s = new BOlist.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i<= sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						BOlist.Param p = new BOlist.Param ();
						
					cell = row.GetCell(0); p.english = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(1); p.japanese = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.headcount = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(3); p.time = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(4); p.difficulty = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(5); p.lucky = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(6); p.communication = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(7); p.card = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(8); p.forBeginner = (cell == null ? "" : cell.StringCellValue);
						s.list.Add (p);
					}
					data.sheets.Add(s);
				}
			}

			ScriptableObject obj = AssetDatabase.LoadAssetAtPath (exportPath, typeof(ScriptableObject)) as ScriptableObject;
			EditorUtility.SetDirty (obj);
		}
	}
}
