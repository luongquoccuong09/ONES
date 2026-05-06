using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ONES
{
	// Token: 0x02000077 RID: 119
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000283 RID: 643 RVA: 0x00028C86 File Offset: 0x00026E86
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000284 RID: 644 RVA: 0x00028C8D File Offset: 0x00026E8D
		// (set) Token: 0x06000285 RID: 645 RVA: 0x00028C9F File Offset: 0x00026E9F
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("C:\\\\ProgramData\\\\Autodesk\\\\Revit\\\\Addins\\\\Logs.txt")]
		public string LogsFile
		{
			get
			{
				return (string)this["LogsFile"];
			}
			set
			{
				this["LogsFile"] = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000286 RID: 646 RVA: 0x00028CAD File Offset: 0x00026EAD
		// (set) Token: 0x06000287 RID: 647 RVA: 0x00028CBF File Offset: 0x00026EBF
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("\\\\133.129.22.205\\bim_installer\\_Revit_2021\\その他必要に応じて\\社内試行RevitAddin1（ONES）\\")]
		public string folderONES
		{
			get
			{
				return (string)this["folderONES"];
			}
			set
			{
				this["folderONES"] = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000288 RID: 648 RVA: 0x00028CCD File Offset: 0x00026ECD
		// (set) Token: 0x06000289 RID: 649 RVA: 0x00028CDF File Offset: 0x00026EDF
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool ONESLogsOnOff
		{
			get
			{
				return (bool)this["ONESLogsOnOff"];
			}
			set
			{
				this["ONESLogsOnOff"] = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600028A RID: 650 RVA: 0x00028CF2 File Offset: 0x00026EF2
		// (set) Token: 0x0600028B RID: 651 RVA: 0x00028D04 File Offset: 0x00026F04
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("\\\\obyfs01\\09IPD\\02_プロジェクト関連\\11東京\\0065_Sビル\\Logs\\\\ONESLogs.txt")]
		public string ONESLogsFile
		{
			get
			{
				return (string)this["ONESLogsFile"];
			}
			set
			{
				this["ONESLogsFile"] = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600028C RID: 652 RVA: 0x00028D12 File Offset: 0x00026F12
		// (set) Token: 0x0600028D RID: 653 RVA: 0x00028D24 File Offset: 0x00026F24
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public int ONESUsage
		{
			get
			{
				return (int)this["ONESUsage"];
			}
			set
			{
				this["ONESUsage"] = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600028E RID: 654 RVA: 0x00028D37 File Offset: 0x00026F37
		// (set) Token: 0x0600028F RID: 655 RVA: 0x00028D49 File Offset: 0x00026F49
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("\\\\133.129.22.205\\bim_installer\\_Revit_2021\\その他必要に応じて\\社内試行RevitAddin1（ONES）\\ONES.dll")]
		public string ONESdll
		{
			get
			{
				return (string)this["ONESdll"];
			}
			set
			{
				this["ONESdll"] = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000290 RID: 656 RVA: 0x00028D57 File Offset: 0x00026F57
		// (set) Token: 0x06000291 RID: 657 RVA: 0x00028D69 File Offset: 0x00026F69
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("\\\\obyfs01\\09IPD\\02_プロジェクト関連\\11東京\\0065_Sビル\\\\Logs\\\\Logs.txt")]
		public string LogsFileServer
		{
			get
			{
				return (string)this["LogsFileServer"];
			}
			set
			{
				this["LogsFileServer"] = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000292 RID: 658 RVA: 0x00028D77 File Offset: 0x00026F77
		// (set) Token: 0x06000293 RID: 659 RVA: 0x00028D89 File Offset: 0x00026F89
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("C:\\\\ProgramData\\\\Autodesk\\\\Revit\\\\Addins\\\\Logs.txt")]
		public string LogsFileDefault
		{
			get
			{
				return (string)this["LogsFileDefault"];
			}
			set
			{
				this["LogsFileDefault"] = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000294 RID: 660 RVA: 0x00028D97 File Offset: 0x00026F97
		// (set) Token: 0x06000295 RID: 661 RVA: 0x00028DA9 File Offset: 0x00026FA9
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("\\\\133.129.22.205\\bim_installer\\_Revit_2021\\その他必要に応じて\\社内試行RevitAddin1（ONES）\\")]
		public string folderONESDefault
		{
			get
			{
				return (string)this["folderONESDefault"];
			}
			set
			{
				this["folderONESDefault"] = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000296 RID: 662 RVA: 0x00028DB7 File Offset: 0x00026FB7
		// (set) Token: 0x06000297 RID: 663 RVA: 0x00028DC9 File Offset: 0x00026FC9
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool OverrideLine
		{
			get
			{
				return (bool)this["OverrideLine"];
			}
			set
			{
				this["OverrideLine"] = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000298 RID: 664 RVA: 0x00028DDC File Offset: 0x00026FDC
		// (set) Token: 0x06000299 RID: 665 RVA: 0x00028DEE File Offset: 0x00026FEE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool OverrideSurface
		{
			get
			{
				return (bool)this["OverrideSurface"];
			}
			set
			{
				this["OverrideSurface"] = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600029A RID: 666 RVA: 0x00028E01 File Offset: 0x00027001
		// (set) Token: 0x0600029B RID: 667 RVA: 0x00028E13 File Offset: 0x00027013
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool OverrideNest
		{
			get
			{
				return (bool)this["OverrideNest"];
			}
			set
			{
				this["OverrideNest"] = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600029C RID: 668 RVA: 0x00028E26 File Offset: 0x00027026
		// (set) Token: 0x0600029D RID: 669 RVA: 0x00028E38 File Offset: 0x00027038
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool OverrideHalftone
		{
			get
			{
				return (bool)this["OverrideHalftone"];
			}
			set
			{
				this["OverrideHalftone"] = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600029E RID: 670 RVA: 0x00028E4B File Offset: 0x0002704B
		// (set) Token: 0x0600029F RID: 671 RVA: 0x00028E5D File Offset: 0x0002705D
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool OverrideCut
		{
			get
			{
				return (bool)this["OverrideCut"];
			}
			set
			{
				this["OverrideCut"] = value;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x00028E70 File Offset: 0x00027070
		// (set) Token: 0x060002A1 RID: 673 RVA: 0x00028E82 File Offset: 0x00027082
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public int OverrideTransparency
		{
			get
			{
				return (int)this["OverrideTransparency"];
			}
			set
			{
				this["OverrideTransparency"] = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x00028E95 File Offset: 0x00027095
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x00028EA7 File Offset: 0x000270A7
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("C:\\\\ProgramData\\\\Autodesk\\\\Revit\\\\Addins\\\\onesLogs\\\\")]
		public string LogsFileFolder
		{
			get
			{
				return (string)this["LogsFileFolder"];
			}
			set
			{
				this["LogsFileFolder"] = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x00028EB5 File Offset: 0x000270B5
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x00028EC7 File Offset: 0x000270C7
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("Default")]
		public string Language
		{
			get
			{
				return (string)this["Language"];
			}
			set
			{
				this["Language"] = value;
			}
		}

		// Token: 0x040001D2 RID: 466
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
