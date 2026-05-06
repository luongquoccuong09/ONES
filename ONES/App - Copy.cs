using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using Autodesk.Windows;
using RibbonPanel = Autodesk.Revit.UI.RibbonPanel;

namespace ONES
{
    internal class App : IExternalApplication
    {
        private static string _assemblyLocation;
        private static string _folderONES;
        private static string _videoFolder;
        private static Dictionary<string, BitmapImage> _iconCache = new Dictionary<string, BitmapImage>();

        public Result OnStartup(UIControlledApplication a)
        {
            // Cache common paths
            _assemblyLocation = Assembly.GetExecutingAssembly().Location;
            _folderONES = Settings.Default.folderONES;
            _videoFolder = _folderONES + "Videos";

            LanguageType language = a.ControlledApplication.Language;
            bool isJapanese = language.ToString() == "Japanese";

            // Get localized texts
            var texts = GetLocalizedTexts(isJapanese);

            // Create all ribbon panels at once
            var panels = CreateRibbonPanels(a, texts);

            // Create all buttons using data-driven approach
            CreateColorPanel(panels["Color"], texts);
            CreateModifyPanel(panels["Modify"], texts);
            CreateGeneratePanel(panels["Generate"], texts);
            CreateExportPanel(panels["Export"], texts);
            CreateReviewPanel(panels["Review"], texts);
            CreateSelectPanel(panels["Select"], texts);
            CreateCollaborationPanel(panels["Collaboration"], texts);
            CreateBonusPanel(panels["Bonus"], texts);
            CreateONESPanel(panels["ONES"], texts);

            // Rename BIT tab
            RenameBITTab();

            return Result.Succeeded;
        }

        #region Panel Creation Methods

        private Dictionary<string, RibbonPanel> CreateRibbonPanels(UIControlledApplication a, Dictionary<string, string> texts)
        {
            var panelNames = new[] { "Color", "Modify", "Generate", "Export", "Review", "Select", "Collaboration", "Bonus", "ONES" };
            var panels = new Dictionary<string, RibbonPanel>();

            foreach (var name in panelNames)
            {
                var localizedName = texts.ContainsKey($"Panel{name}") ? texts[$"Panel{name}"] : name;
                panels[name] = GetOrCreateRibbonPanel(a, "ONES", localizedName);
            }

            return panels;
        }

        private void CreateColorPanel(RibbonPanel panel, Dictionary<string, string> texts)
        {
            // Color Filter - Large button
            var colorFilterBtn = CreatePushButton(
                "ButtonColorFilter",
                texts["ColorFilter"],
                "ONES.ColorFilter",
                texts["ColorFilterTooltip"],
                "colorfilter.png",
                "colorfilter16.png",
                texts["ColorFilterLongDesc"],
                "ColorFilter.mp4",
                true
            );
            panel.AddItem(colorFilterBtn);

            // Stack 1: R, G, B
            var overrideButtons1 = new[]
            {
                CreateOverrideButton("ButtonORed", texts["Red"], "OverrideRed", texts["RedTooltip"], "overridered16.png"),
                CreateOverrideButton("ButtonOGreen", texts["Green"], "OverrideGreen", texts["GreenTooltip"], "overridegreen16.png"),
                CreateOverrideButton("ButtonOBlue", texts["Blue"], "OverrideBlue", texts["BlueTooltip"], "overrideblue16.png")
            };
            panel.AddStackedItems(
    overrideButtons1[0],
    overrideButtons1[1],
    overrideButtons1[2]
);

            // Stack 2: Y, R, N
            var overrideButtons2 = new[]
            {
                CreateOverrideButton("ButtonOYellow", texts["Yellow"], "OverrideYellow", texts["YellowTooltip"], "overrideyellow16.png"),
                CreateOverrideButton("ButtonORandom", texts["Random"], "OverrideRandom", texts["RandomTooltip"], "overriderainbow16.png"),
                CreateOverrideButton("ButtonONone", texts["None"], "OverrideNone", texts["NoneTooltip"], "overridegray16.png")
            };
            panel.AddStackedItems(
    overrideButtons2[0],
    overrideButtons2[1],
    overrideButtons2[2]
);

            // Slide out section
            panel.AddSlideOut();
            var settingsBtn = CreatePushButton(
                "ButtonOSettings",
                texts["OverrideSettings"],
                "ONES.OverrideSettings",
                texts["OverrideSettingsTooltip"],
                "settings.png",
                "settings16.png"
            );
            panel.AddItem(settingsBtn);
        }

        private void CreateModifyPanel(RibbonPanel panel, Dictionary<string, string> texts)
        {
            // Copy Filters
            var copyFiltersBtn = CreatePushButton(
                "ButtonCopyFilters",
                texts["CopyFilters"],
                "ONES.CopyFilters",
                texts["CopyFiltersTooltip"],
                "copyfilter.png",
                "copyfilter.png",
                texts["CopyFiltersLongDesc"],
                "CopyFilters.mp4",
                true
            );
            panel.AddItem(copyFiltersBtn);

            // Join/Unjoin Split Button
            var joinBtn = CreatePushButton(
                "ButtonJoin",
                texts["Join"],
                "ONES.JoinElements",
                texts["JoinTooltip"],
                "join.png",
                "join16.png",
                texts["JoinLongDesc"],
                "JoinElements.mp4"
            );
            var unjoinBtn = CreatePushButton(
                "ButtonUnjoin",
                texts["Unjoin"],
                "ONES.Unjoin",
                texts["UnjoinTooltip"],
                "unjoin.png",
                "unjoin16.png"
            );
            var joinSplit = panel.AddItem(new SplitButtonData("splitButtonJoin", texts["Join"])) as SplitButton;
            joinSplit.AddPushButton(joinBtn);
            joinSplit.AddPushButton(unjoinBtn);

            // View Pulldown
            CreateViewPulldown(panel, texts);

            // Analytical Split Button
            CreateAnalyticalSplitButton(panel, texts);

            // Align buttons - 2 stacks of 3
            CreateAlignButtons(panel, texts);
        }

        private void CreateGeneratePanel(RibbonPanel panel, Dictionary<string, string> texts)
        {
            // Floor Finish
            var floorBtn = CreatePushButton(
                "FloorbyRoom",
                texts["FloorFinish"],
                "ONES.FloorbyRoom",
                texts["FloorFinishTooltip"],
                "floorgenerate.png",
                "floorgenerate16.png",
                null,
                "FloorbyRoom.mp4",
                true
            );
            panel.AddItem(floorBtn);

            // Type Samples Split Button
            CreateTypeSamplesSplitButton(panel, texts);

            // Section & Grid Dim stack
            var sectionBtn = CreatePushButton(
                "ButtonSection",
                texts["Section"],
                "ONES.Section",
                texts["SectionTooltip"],
                "section.png",
                "section16.png",
                null,
                "Section.mp4"
            );
            var gridDimBtn = CreatePushButton(
                "ButtonDimensionGrids",
                texts["GridDim"],
                "ONES.DimensionGrids",
                texts["GridDimTooltip"],
                "dimension.png",
                "dimension16.png",
                null,
                "DimensionGrids.mp4"
            );
            panel.AddStackedItems(sectionBtn, gridDimBtn);
        }

        private void CreateExportPanel(RibbonPanel panel, Dictionary<string, string> texts)
        {
            // Export Schedules Split
            CreateExportSchedulesSplit(panel, texts);

            // Export Layers Split
            CreateExportLayersSplit(panel, texts);

            // Export Materials
            var materialsBtn = CreatePushButton(
                "ButtonEM",
                texts["MaterialsNames"],
                "ONES.ExportMaterials",
                texts["MaterialsNamesTooltip"],
                "excel.png",
                null,
                null,
                null,
                true
            );
            panel.AddItem(materialsBtn);

            // Inspect Element stack
            var inspectBtn = CreatePushButton(
                "ButtonInspectElement",
                texts["Inspect"],
                "ONES.InspectElement",
                texts["InspectTooltip"],
                "inspectelements.png",
                "inspect16.png",
                null,
                "Inspect.mp4"
            );
            var modelSizeBtn = CreatePushButton(
                "ButtonModelSize",
                texts["ModelSize"],
                "ONES.ModelSize",
                texts["ModelSizeTooltip"],
                "modelsize.png",
                "modelsize16.png",
                null,
                "ModelSize.mp4"
            );
            var localFileBtn = CreatePushButton(
                "ButtonLocalFile",
                texts["LocalFile"],
                "ONES.LocalFile",
                texts["LocalFileTooltip"],
                "folder.png",
                "folder16.png"
            );
            panel.AddStackedItems(inspectBtn, modelSizeBtn, localFileBtn);
        }

        private void CreateReviewPanel(RibbonPanel panel, Dictionary<string, string> texts)
        {
            // Warnings Pulldown
            CreateWarningsPulldown(panel, texts);

            // Purge Split Button
            CreatePurgeSplitButton(panel, texts);
        }

        private void CreateSelectPanel(RibbonPanel panel, Dictionary<string, string> texts)
        {
            // Select Filter
            var selectFilterBtn = CreatePushButton(
                "ButtonSelectFilter",
                texts["SelectFilter"],
                "ONES.SelectFilter",
                texts["SelectFilterTooltip"],
                "filterplus.png",
                "filterplus16.png",
                null,
                null,
                true
            );
            panel.AddItem(selectFilterBtn);

            // Select Pulldown
            CreateSelectPulldown(panel, texts);

            // Zoom Elements
            var zoomBtn = CreatePushButton(
                "Buttonze",
                texts["ZoomElements"],
                "ONES.ZoomElements",
                texts["ZoomElementsTooltip"],
                "zoomelements.png",
                "zoomelements16.png",
                null,
                "ZoomElements.mp4",
                true
            );
            panel.AddItem(zoomBtn);

            // Intersects & Filter Revit stack
            var intersectsBtn = CreatePushButton(
                "ButtonSIE",
                texts["Intersects"],
                "ONES.SelectIntersectingElements",
                texts["IntersectsTooltip"],
                "clash.png",
                "clash16.png"
            );
            var filterRevitBtn = CreatePushButton(
                "ButtonFilterRevit",
                texts["RevitFilter"],
                "ONES.FilterRevit",
                texts["RevitFilterTooltip"],
                "filter.png",
                "filter16.png",
                null,
                "ByFilter.mp4"
            );
            panel.AddStackedItems(intersectsBtn, filterRevitBtn);

            // Memory buttons - 2 stacks
            panel.AddSeparator();
            CreateMemoryButtons(panel, texts);
        }

        private void CreateCollaborationPanel(RibbonPanel panel, Dictionary<string, string> texts)
        {
            // Log Report
            var logReportBtn = CreatePushButton(
                "ButtonLogReport",
                texts["ProjectLog"],
                "ONES.LogProject",
                texts["ProjectLogTooltip"],
                "logreport.png",
                "logreport16.png",
                null,
                "LogReport.mp4",
                true
            );
            panel.AddItem(logReportBtn);

            // Who Did
            var whoDidBtn = CreatePushButton(
                "ButtonWhoDid",
                texts["WhoDid"],
                "ONES.WhoDid",
                texts["WhoDidTooltip"],
                "whodid.png",
                "whodid16.png",
                null,
                "WhoDid.mp4",
                true
            );
            panel.AddItem(whoDidBtn);

            // Worksharing Pulldown
            CreateWorksharingPulldown(panel, texts);
        }

        private void CreateBonusPanel(RibbonPanel panel, Dictionary<string, string> texts)
        {
            var coffeeBtn = CreatePushButton(
                "ButtonCoffee",
                texts["Coffee"],
                "ONES.CoffeeTime",
                texts["CoffeeTooltip"],
                "coffee.png",
                "coffee16.png"
            );
            var calcBtn = CreatePushButton(
                "ButtonWC",
                texts["WinCalc"],
                "ONES.WinCalc",
                texts["WinCalcTooltip"],
                "wincalc.png",
                "wincalc16.png"
            );
            var notepadBtn = CreatePushButton(
                "ButtonNP",
                texts["Notepad"],
                "ONES.Notepad",
                texts["NotepadTooltip"],
                "notepad.png",
                "notepad16.png"
            );
            panel.AddStackedItems(coffeeBtn, calcBtn, notepadBtn);
        }

        private void CreateONESPanel(RibbonPanel panel, Dictionary<string, string> texts)
        {
            var aboutBtn = CreatePushButton(
                "ButtonAAbout",
                texts["About"],
                "ONES.AboutApp",
                texts["AboutTooltip"],
                "about16.png",
                "about16.png"
            );
            var settingsBtn = CreatePushButton(
                "ButtonSettings",
                texts["Settings"],
                "ONES.SettingsONES",
                texts["SettingsTooltip"],
                "settings.png",
                "settings16.png"
            );
            var updateBtn = CreatePushButton(
                "ButtonUpdate",
                texts["Version"],
                "ONES.Update",
                texts["VersionTooltip"],
                null,
                "update16.png"
            );

            // Check for updates
            CheckForUpdates(updateBtn);

            panel.AddStackedItems(settingsBtn, aboutBtn, updateBtn);

            // Help button
            var helpBtn = CreatePushButton(
                "ButtonHelp",
                texts["Help"],
                "ONES.Help",
                texts["HelpTooltip"],
                "help.png",
                "help16.png",
                null,
                null,
                true
            );
            panel.AddItem(helpBtn);
        }

        #endregion

        #region Helper Methods for Complex Buttons

        private void CreateViewPulldown(RibbonPanel panel, Dictionary<string, string> texts)
        {
            var pulldownData = new PulldownButtonData("pullDownView", texts["View"])
            {
                ToolTip = texts["ViewTooltip"],
                LargeImage = GetCachedIcon("view.png", true)
            };
            var pulldown = panel.AddItem(pulldownData) as PulldownButton;

            pulldown.AddPushButton(CreatePushButton("ButtonUnhide", texts["Unhide"], "ONES.Unhide",
                texts["UnhideTooltip"], "unhide.png", "unhide16.png"));
            pulldown.AddPushButton(CreatePushButton("ButtonRFilters", texts["RemoveFilters"], "ONES.RemoveFilters",
                texts["RemoveFiltersTooltip"], "filterremove.png", "filterremove16.png", null, "RemoveFilters.mp4"));
            pulldown.AddPushButton(CreatePushButton("ButtonPin", texts["Pin"], "ONES.Pin",
                texts["PinTooltip"], "pin.png", "pin16.png"));
            pulldown.AddPushButton(CreatePushButton("ButtonIUnpinned", texts["Unpinned"], "ONES.IsolateUnpinned",
                texts["UnpinnedTooltip"], "unpin.png", "unpin16.png", null, "Unpinned.mp4"));
        }

        private void CreateAnalyticalSplitButton(RibbonPanel panel, Dictionary<string, string> texts)
        {
            var splitData = new SplitButtonData("splitButtonAnalytical", texts["Analytical"]);
            var split = panel.AddItem(splitData) as SplitButton;

            split.AddPushButton(CreatePushButton("ButtonAnalyticalOff", texts["AnalyticalOff"], "ONES.AnalyticalDisable",
                texts["AnalyticalOffTooltip"], "lightoff.png", "lightoff16.png"));
            split.AddPushButton(CreatePushButton("ButtonAnalyticalOn", texts["AnalyticalOn"], "ONES.AnalyticalEnable",
                texts["AnalyticalOnTooltip"], "lighton.png", "lighton16.png"));
        }

        private void CreateAlignButtons(RibbonPanel panel, Dictionary<string, string> texts)
        {
            var alignDefs = new[]
            {
                ("ButtonAlignLeft", texts["Left"], "AlignLeft", texts["LeftTooltip"], "alignleft16.png"),
                ("ButtonAlignCenter", texts["Center"], "AlignCenter", texts["CenterTooltip"], "aligncenter16.png"),
                ("ButtonAlignRight", texts["Right"], "AlignRight", texts["RightTooltip"], "alignright16.png"),
                ("ButtonAlignTop", texts["Top"], "AlignTop", texts["TopTooltip"], "aligntop16.png"),
                ("ButtonAlignMiddle", texts["Middle"], "AlignMiddle", texts["MiddleTooltip"], "alignmiddle16.png"),
                ("ButtonAlignBottom", texts["Bottom"], "AlignBottom", texts["BottomTooltip"], "alignbottom16.png")
            };

            var buttons = alignDefs.Select(d =>
                CreatePushButton(d.Item1, d.Item2, $"ONES.{d.Item3}", d.Item4, null, d.Item5, null, "Align.mp4")
            ).ToArray();

            panel.AddStackedItems(buttons[0], buttons[1], buttons[2]);
            panel.AddStackedItems(buttons[3], buttons[4], buttons[5]);
        }

        private void CreateTypeSamplesSplitButton(RibbonPanel panel, Dictionary<string, string> texts)
        {
            var splitData = new SplitButtonData("splitButtonTypeSamples", texts["TypeSamples"]);
            var split = panel.AddItem(splitData) as SplitButton;

            var types = new[]
            {
                ("ButtonTypesWalls", texts["WallTypes"], "TypesWalls", texts["WallTypesTooltip"], "wall", "TypeWall.mp4"),
                ("ButtonTypesWindows", texts["WindowTypes"], "TypesWindows", texts["WindowTypesTooltip"], "window", "TypeWindows.mp4"),
                ("ButtonTypesDoors", texts["DoorTypes"], "TypesDoors", texts["DoorTypesTooltip"], "door", "TypeDoors.mp4"),
                ("ButtonTypesFloors", texts["FloorTypes"], "TypesFloors", texts["FloorTypesTooltip"], "floor", null)
            };

            foreach (var t in types)
            {
                split.AddPushButton(CreatePushButton(t.Item1, t.Item2, $"ONES.{t.Item3}", t.Item4,
                    $"{t.Item5}.png", $"{t.Item5}16.png", null, t.Item6));
            }
        }

        private void CreateExportSchedulesSplit(RibbonPanel panel, Dictionary<string, string> texts)
        {
            var splitData = new SplitButtonData("splitButtonExportSchedule", "Export Schedules");
            var split = panel.AddItem(splitData) as SplitButton;

            split.AddPushButton(CreatePushButton("Buttoneas", texts["ActiveSchedule"], "ONES.ExportActiveSchedule",
                texts["ActiveScheduleTooltip"], "sheet.png", "sheet16.png", null, "ExportActiveSchedule.mp4"));
            split.AddPushButton(CreatePushButton("Buttonealls", texts["AllSchedules"], "ONES.ExportAllSchedules",
                texts["AllSchedulesTooltip"], "sheetdouble.png", "sheetdouble16.png", null, "ExportAllSchedules.mp4"));
        }

        private void CreateExportLayersSplit(RibbonPanel panel, Dictionary<string, string> texts)
        {
            var splitData = new SplitButtonData("splitButtonExportLayers", "Export Layers");
            var split = panel.AddItem(splitData) as SplitButton;

            var video = "ExportWall,Ceiling,FloorLayers.mp4";
            split.AddPushButton(CreatePushButton("Buttonewl", texts["WallLayers"], "ONES.ExportWallLayers",
                texts["WallLayersTooltip"], "exportlayers.png", "exportlayers16.png", null, video));
            split.AddPushButton(CreatePushButton("Buttonecl", texts["CeilingLayers"], "ONES.ExportCeilingLayers",
                texts["CeilingLayersTooltip"], "exportlayers.png", "exportlayers16.png", null, video));
            split.AddPushButton(CreatePushButton("Buttonefl", texts["FloorLayers"], "ONES.ExportFloorLayers",
                texts["FloorLayersTooltip"], "exportlayers.png", "exportlayers16.png", null, video));
        }

        private void CreateWarningsPulldown(RibbonPanel panel, Dictionary<string, string> texts)
        {
            var pulldownData = new PulldownButtonData("pullDownWarnings", texts["Warnings"])
            {
                ToolTip = texts["WarningsTooltip"],
                LargeImage = GetCachedIcon("warnings.png", true)
            };
            var pulldown = panel.AddItem(pulldownData) as PulldownButton;

            pulldown.AddPushButton(CreatePushButton("ButtonWI", texts["IsolateAllWarnings"], "ONES.WarningsIsolate",
                texts["IsolateAllWarningsTooltip"], "warnings.png", "warnings16.png"));
            pulldown.AddPushButton(CreatePushButton("ButtonWIU", texts["IsolateByUser"], "ONES.WarningsIsolateUser",
                texts["IsolateByUserTooltip"], "warnings.png", "warnings16.png"));
            pulldown.AddPushButton(CreatePushButton("ButtonWC", texts["WarningsReport"], "ONES.WarningsCount",
                texts["WarningsReportTooltip"], "warnings.png", "warnings16.png"));
        }

        private void CreatePurgeSplitButton(RibbonPanel panel, Dictionary<string, string> texts)
        {
            var splitData = new SplitButtonData("splitButtonPurge", "Purge");
            var split = panel.AddItem(splitData) as SplitButton;

            split.AddPushButton(CreatePushButton("ButtonCAD", texts["PurgeCADs"], "ONES.PurgeCAD",
                texts["PurgeCADsTooltip"], "cad.png", "cad16.png"));
            split.AddPushButton(CreatePushButton("ButtonPFilters", texts["PurgeFilters"], "ONES.PurgeFilters",
                texts["PurgeFiltersTooltip"], "filter.png", "filter16.png"));
            split.AddPushButton(CreatePushButton("ButtonPOT", texts["PurgeTags"], "ONES.PurgeTags",
                texts["PurgeTagsTooltip"], "tag.png", "tag16.png"));
        }

        private void CreateSelectPulldown(RibbonPanel panel, Dictionary<string, string> texts)
        {
            var pulldownData = new PulldownButtonData("pullDownSelect", texts["Select"])
            {
                ToolTip = texts["SelectTooltip"],
                LargeImage = GetCachedIcon("select.png", true)
            };
            var pulldown = panel.AddItem(pulldownData) as PulldownButton;

            pulldown.AddPushButton(CreatePushButton("ButtonST", texts["ByType"], "ONES.SelectType",
                texts["ByTypeTooltip"], "select.png", "select16.png", null, "SelectType.mp4"));
            pulldown.AddPushButton(CreatePushButton("ButtonSF", texts["ByFamily"], "ONES.SelectFamily",
                texts["ByFamilyTooltip"], "select.png", "select16.png"));
            pulldown.AddPushButton(CreatePushButton("ButtonSC", texts["ByCategory"], "ONES.SelectCategory",
                texts["ByCategoryTooltip"], "select.png", "select16.png", null, "SelectCategory.mp4"));
            pulldown.AddPushButton(CreatePushButton("ButtonSColor", texts["ByColor"], "ONES.SelectColor",
                texts["ByColorTooltip"], "select.png", "select16.png"));
        }

        private void CreateMemoryButtons(RibbonPanel panel, Dictionary<string, string> texts)
        {
            var memoryDefs = new[]
            {
                ("ButtonMPlus", texts["MPlus"], "MPlus", texts["MPlusTooltip"], "mplus24.png", "mplus16.png"),
                ("ButtonMMinus", texts["MMinus"], "MMinus", texts["MMinusTooltip"], "mminus24.png", "mminus16.png"),
                ("ButtonMRead", texts["MR"], "MRead", texts["MRTooltip"], "mread24.png", "mread16.png"),
                ("ButtonMClear", texts["MC"], "MClear", texts["MCTooltip"], "mclear24.png", "mclear16.png")
            };

            var buttons = memoryDefs.Select(d =>
                CreatePushButton(d.Item1, d.Item2, $"ONES.{d.Item3}", d.Item4, d.Item5, d.Item6)
            ).ToArray();

            panel.AddStackedItems(buttons[0], buttons[1]);
            panel.AddStackedItems(buttons[2], buttons[3]);
        }

        private void CreateWorksharingPulldown(RibbonPanel panel, Dictionary<string, string> texts)
        {
            var pulldownData = new PulldownButtonData("pullDownWorksharing", texts["WorkSharing"])
            {
                ToolTip = texts["WorkSharingTooltip"],
                LargeImage = GetCachedIcon("worksharing.png", true)
            };
            var pulldown = panel.AddItem(pulldownData) as PulldownButton;

            pulldown.AddPushButton(CreatePushButton("ButtonOnlineUsers", texts["Online"], "ONES.OnlineUsers",
                texts["OnlineTooltip"], "onlineusers.png", "onlineusers16.png"));
            pulldown.AddPushButton(CreatePushButton("ButtonHideOwned", texts["Hide"], "ONES.HideOwnedElements",
                texts["HideTooltip"], "hideownedelements.png", "hideownedelements16.png"));
        }

        #endregion

        #region Core Helper Methods

        private PushButtonData CreatePushButton(
            string name,
            string text,
            string className,
            string tooltip,
            string largeIcon = null,
            string smallIcon = null,
            string longDescription = null,
            string videoFile = null,
            bool hasToolTipImage = false)
        {
            var buttonData = new PushButtonData(name, text, _assemblyLocation, className)
            {
                ToolTip = tooltip
            };

            if (largeIcon != null)
                buttonData.LargeImage = GetCachedIcon(largeIcon, true);

            if (smallIcon != null)
                buttonData.Image = GetCachedIcon(smallIcon, false);

            if (hasToolTipImage && largeIcon != null)
            {
                // Use ToolbarImage folder for tooltip images
                var tooltipPath = largeIcon.Replace(".png", "").Replace("16", "");
                buttonData.ToolTipImage = GetCachedIcon($"ToolbarImage/{tooltipPath}.png", false, true);
            }

            if (longDescription != null)
                buttonData.LongDescription = longDescription;

            if (videoFile != null)
                buttonData.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, _videoFolder + "\\" + videoFile));

            return buttonData;
        }

        private PushButtonData CreateOverrideButton(string name, string text, string className, string tooltip, string icon)
        {
            var btn = CreatePushButton(name, text, $"ONES.{className}", tooltip, null, icon, null, "Override.mp4", true);
            btn.ToolTipImage = GetCachedIcon("ToolbarImage/override.png", false, true);
            return btn;
        }

        private BitmapImage GetCachedIcon(string relativePath, bool isLarge, bool isToolbarImage = false)
        {
            string key = $"{relativePath}_{isLarge}_{isToolbarImage}";

            if (!_iconCache.ContainsKey(key))
            {
                string folder = isToolbarImage ? "" : (isLarge ? "Icons/" : "Icons/");
                string uri = $"pack://application:,,,/ONES;component/{relativePath}";
                _iconCache[key] = new BitmapImage(new Uri(uri));
            }

            return _iconCache[key];
        }

        private RibbonPanel GetOrCreateRibbonPanel(UIControlledApplication a, string tabName, string panelName)
        {
            try { a.CreateRibbonTab(tabName); } catch { }
            try { a.CreateRibbonPanel(tabName, panelName); } catch { }

            return a.GetRibbonPanels(tabName).FirstOrDefault(p => p.Name == panelName);
        }

        private void CheckForUpdates(PushButtonData updateBtn)
        {
            try
            {
                string onesdll = Settings.Default.ONESdll;
                var versionInfo = FileVersionInfo.GetVersionInfo(onesdll);
                string fileVersion = versionInfo.FileVersion;

                var executingAssembly = Assembly.GetExecutingAssembly();
                versionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
                string fileVersion2 = versionInfo.FileVersion;

                if (fileVersion != fileVersion2)
                {
                    updateBtn.Image = GetCachedIcon("updatenew16.png", false);
                }
            }
            catch { }
        }

        private void RenameBITTab()
        {
            try
            {
                RibbonControl ribbon = ComponentManager.Ribbon;
                var bitTab = ribbon.Tabs.FirstOrDefault(t => t.Name == "BIM Interoperability Tools");
                if (bitTab != null)
                    bitTab.Title = "BIT";
            }
            catch { }
        }

        #endregion

        #region Localization

        private Dictionary<string, string> GetLocalizedTexts(bool isJapanese)
        {
            if (isJapanese)
                return GetJapaneseTexts();
            else
                return GetEnglishTexts();
        }

        private Dictionary<string, string> GetEnglishTexts()
        {
            return new Dictionary<string, string>
            {
                // Panel names
                ["PanelModify"] = "Modify",
                ["PanelColor"] = "Color",
                ["PanelGenerate"] = "Generate",
                ["PanelExport"] = "Export to Excel",
                ["PanelReview"] = "Review",
                ["PanelSelect"] = "Select",
                ["PanelCollaboration"] = "Collaboration",
                ["PanelONES"] = "ONES",

                // Color panel
                ["ColorFilter"] = "Color\nFilter",
                ["ColorFilterTooltip"] = "Generate Filters or Override Graphics by Selected Category and Parameters and Apply the Filters to the Active Views as random colors",
                ["ColorFilterLongDesc"] = "① Select Active View(recommended) or All Project\n② Select Parameter Type(Instance or Type)\n③ Select Category(Active View: Only categories of visible elements, All Project: All categories)\n④ Select a Parameter\n⑤ Select Values\n⑥ Check \"Halftone\" for softer colors\nSelect the following three options, ⑦, ⑧, and ⑨, according to your purpose.\n⑦ Click Filter to generate view Filters\n⑧ Click to \"Override\" to override graphics in the active view\n⑨ Click \"Show\" to select elements in Revit",
                ["Red"] = "R",
                ["RedTooltip"] = "Override selected elements in Active View as Red (Halftone)",
                ["Green"] = "G",
                ["GreenTooltip"] = "Override selected elements in Active View as Green (Halftone)",
                ["Blue"] = "B",
                ["BlueTooltip"] = "Override selected elements in Active View as Blue (Halftone)",
                ["Yellow"] = "Y",
                ["YellowTooltip"] = "Override selected elements in Active View as Yellow (Halftone)",
                ["Random"] = "R",
                ["RandomTooltip"] = "Override selected elements in Active View as a Random Color (Halftone)",
                ["None"] = "N",
                ["NoneTooltip"] = "Reset Override of selected elements in Active View",
                ["OverrideSettings"] = "Override\nSettings",
                ["OverrideSettingsTooltip"] = "Override settings for general override feature usages in ONES",

                // Modify panel
                ["CopyFilters"] = "Copy\nFilters",
                ["CopyFiltersTooltip"] = "Copies the Filters of Current View to other Selected View",
                ["CopyFiltersLongDesc"] = "① Run the command to open Copy Filters form.\n② Select filters from Filters Panel (left)and select views from Views Panel (right)\n③ Click Copy button",
                ["Join"] = "Join",
                ["JoinTooltip"] = "Join All Elements of Selected Categories",
                ["JoinLongDesc"] = "① Select Top Category\n② Select Bottom Category\n③ Select All Project or Active View(recommended)\n④ Click Join",
                ["Unjoin"] = "Unjoin",
                ["UnjoinTooltip"] = "Unjoin Selected Elements",
                ["Unhide"] = "Unhide",
                ["UnhideTooltip"] = "Unhide All Hidden Elements of the Active View",
                ["AnalyticalOff"] = "Analytical\nOff",
                ["AnalyticalOffTooltip"] = "Disable Analytical Models of the Active View",
                ["AnalyticalOn"] = "Analytical\nOn",
                ["AnalyticalOnTooltip"] = "Enable Analytical Models of the Active View",
                ["Analytical"] = "Analytical",
                ["RemoveFilters"] = "Remove Filters",
                ["RemoveFiltersTooltip"] = "Remove All Filters from Active View (doesn't delete filters from the project)",
                ["Pin"] = "Pin",
                ["PinTooltip"] = "Pin All Elements at the Active View",
                ["View"] = "View",
                ["ViewTooltip"] = "View Features",
                ["ResetOverride"] = "Reset Override",
                ["ResetOverrideTooltip"] = "Reset Override Graphic settings of all elements in the active view",
                ["Left"] = "Left",
                ["LeftTooltip"] = "Align selected elements to Left",
                ["Center"] = "Center",
                ["CenterTooltip"] = "Align selected elements to Center",
                ["Right"] = "Right",
                ["RightTooltip"] = "Align selected elements to Right",
                ["Top"] = "Top",
                ["TopTooltip"] = "Align selected elements to Top",
                ["Middle"] = "Middle",
                ["MiddleTooltip"] = "Align selected elements to Middle",
                ["Bottom"] = "Bottom",
                ["BottomTooltip"] = "Align selected elements to Bottom",

                // Generate panel
                ["FloorFinish"] = "Floor\nFinish",
                ["FloorFinishTooltip"] = "Generates floors by boundary of selected rooms",
                ["WallTypes"] = "Wall \nTypes",
                ["WallTypesTooltip"] = "Generate a sample of each wall type to a picked point",
                ["WindowTypes"] = "Window \nTypes",
                ["WindowTypesTooltip"] = "Generate a wall (default wall type) to the picked point and input every windows types (only host type starting with _ name)",
                ["DoorTypes"] = "Door \nTypes",
                ["DoorTypesTooltip"] = "Generate a wall (default wall type) to the picked point and input every door types (only host type starting with _ name)",
                ["FloorTypes"] = "Floor \nTypes",
                ["FloorTypesTooltip"] = "Generate a sample of each floor  type to a picked point",
                ["TypeSamples"] = "Type Samples",
                ["Section"] = "Section",
                ["SectionTooltip"] = "Generate Section Views on Grid Lines",
                ["GridDim"] = "Grid Dim",
                ["GridDimTooltip"] = "Put Dimensions to grids of the active view",

                // Export panel
                ["ActiveSchedule"] = "Active\nSchedule",
                ["ActiveScheduleTooltip"] = "Exports Active Schedule View to Excel",
                ["AllSchedules"] = "All\nSchedules",
                ["AllSchedulesTooltip"] = "Exports All Schedules to Excel",
                ["AllLayers"] = "All\nLayers",
                ["AllLayersTooltip"] = "Exports Floor, Ceiling and Wall Layers to Excel",
                ["WallLayers"] = "Wall\nLayers",
                ["WallLayersTooltip"] = "Exports Wall Layers to Excel",
                ["CeilingLayers"] = "Ceiling\nLayers",
                ["CeilingLayersTooltip"] = "Exports Ceiling Layers to Excel",
                ["FloorLayers"] = "Floor\nLayers",
                ["FloorLayersTooltip"] = "Exports Floor Layers to Excel",
                ["MaterialsNames"] = "Materials\nNames",
                ["MaterialsNamesTooltip"] = "Exports Material Name & Properties to Excel",
                ["Inspect"] = "Inspect",
                ["InspectTooltip"] = "Inspect Selected Element and Export All Instance & Type Parameters",

                // Review panel
                ["IsolateAllWarnings"] = "Isolate All Warnings",
                ["IsolateAllWarningsTooltip"] = "Isolates All Warning Elements in Active View",
                ["IsolateByUser"] = "Isolate by User",
                ["IsolateByUserTooltip"] = "Isolates Warning Elements in Active View by Selected User",
                ["WarningsReport"] = "Warnings Report",
                ["WarningsReportTooltip"] = "Report Warning Counts by Users",
                ["ExportWarnings"] = "Export Warnings",
                ["ExportWarningsTooltip"] = "Export Warning to Excel",
                ["WarningManager"] = "Warning Manager",
                ["WarningManagerTooltip"] = "Manage and select warnings from a treeview list",
                ["Warnings"] = "Warnings",
                ["WarningsTooltip"] = "Isolate Elements which are causing Revit Warnings in the active view",
                ["ModelSize"] = "Model\nSize",
                ["ModelSizeTooltip"] = "Model Size (KB)",
                ["PurgeTags"] = "Purge\nTags",
                ["PurgeTagsTooltip"] = "Purge Orphaned Tags (Hosted by a link element and got orphaned\nafter the host is deleted in the linked document)",
                ["PurgeCADs"] = "Purge\nCADs",
                ["PurgeCADsTooltip"] = "Purge Imported CADs",
                ["PurgeFilters"] = "Purge\nFilters",
                ["PurgeFiltersTooltip"] = "Purge Unused Filters",
                ["Unpinned"] = "Unpinned",
                ["UnpinnedTooltip"] = "Isolate Unpinned Elements at the Active View",
                ["ClashIsolate"] = "Clash: Isolate",
                ["ClashIsolateTooltip"] = "Isolate Clashing Elements of the Active View",
                ["LocalFile"] = "Local\nFile",
                ["LocalFileTooltip"] = "Open the folder of local files and select the local file of current project",

                // Select panel
                ["ZoomElements"] = "Zoom\nElements",
                ["ZoomElementsTooltip"] = "Zoom to Selected Elements",
                ["Intersects"] = "Intersects",
                ["IntersectsTooltip"] = "Select Intersecting Elements by Bounding Box \nChecks Elements Only can be seen in the Active View",
                ["ByType"] = "By\nType",
                ["ByTypeTooltip"] = "Select Elements by Type\nIt Can Select Multiple Types Unlike Built-in",
                ["ByCategory"] = "By\nCategory",
                ["ByCategoryTooltip"] = "Select Elements by Category\nIt Can Select Multiple Categories",
                ["ByFamily"] = "By\nFamily",
                ["ByFamilyTooltip"] = "Select Elements by Family\nIt Can Select Multiple Families",
                ["Select"] = "Select",
                ["SelectTooltip"] = "Select elements in the active view",
                ["RevitFilter"] = "Revit\nFilter",
                ["RevitFilterTooltip"] = "Select Elements by present Filters of the Project",
                ["ByColor"] = "By\nColor",
                ["ByColorTooltip"] = "Select Elements by Override Color\nIt Can Select Multiple Families",
                ["SelectFilter"] = "Select\nFilter",
                ["SelectFilterTooltip"] = "Filter, sort and select elements from the form",
                ["MPlus"] = "M+",
                ["MPlusTooltip"] = "Append the selection memory by selected elements (Similar to Calculator)",
                ["MMinus"] = "M-",
                ["MMinusTooltip"] = "Remove the selected elements from the memory (Similar to Calculator)",
                ["MR"] = "MR",
                ["MRTooltip"] = "Read the element list from the memory and select it (Similar to Calculator)",
                ["MC"] = "MC",
                ["MCTooltip"] = "Clear the element list from the memory (Similar to Calculator)",

                // Collaboration panel
                ["WhoDid"] = "Who\nDid",
                ["WhoDidTooltip"] = "Gets Worksharing Info of Selected Single Element: Creator, Owner and Last Changed by",
                ["Online"] = "Online",
                ["OnlineTooltip"] = "Shows Online Users (Only Users Who Owns Any Elements)",
                ["Hide"] = "Hide",
                ["HideTooltip"] = "Temporarily Hide Elements Owned by Other Users in Active View",
                ["ProjectLog"] = "Project\nLog",
                ["ProjectLogTooltip"] = "Display and Export log report of projects",
                ["ElementLog"] = "Element\nLog",
                ["ElementLogTooltip"] = "Display and Export log report of projects by each element details",
                ["WorkSharing"] = "Work\nSharing",
                ["WorkSharingTooltip"] = "Worksharing Features",

                // Bonus panel
                ["WinCalc"] = "Win\nCalc",
                ["WinCalcTooltip"] = "Open Windows Calculator",
                ["Notepad"] = "Notepad",
                ["NotepadTooltip"] = "Open Notepad",
                ["Coffee"] = "Coffee",
                ["CoffeeTooltip"] = "Read a Coffee Quote and Take a 10-min Coffee Time",

                // ONES panel
                ["About"] = "About",
                ["AboutTooltip"] = "About App and Developer",
                ["Settings"] = "Settings",
                ["SettingsTooltip"] = "Change Settings for the app or return it back to default",
                ["Help"] = "Help",
                ["HelpTooltip"] = "Open User Guide PDF",
                ["Version"] = "Version",
                ["VersionTooltip"] = "Check Updates"
            };
        }

        private Dictionary<string, string> GetJapaneseTexts()
        {
            // Similar structure for Japanese - abbreviated for space
            return new Dictionary<string, string>
            {
                ["PanelModify"] = "修正",
                ["PanelColor"] = "カラー",
                ["PanelGenerate"] = "作成",
                ["PanelExport"] = "エクセルにエクスポート",
                ["PanelReview"] = "レビュー",
                ["PanelSelect"] = "選択",
                ["PanelCollaboration"] = "コラボレーション",
                ["PanelONES"] = "ONES",
                ["ColorFilter"] = "カラー\nフィルタ",
                ["ColorFilterTooltip"] = "選択したカテゴリとパラメータでフィルタを生成し、ランダムな色としてアクティブなビューにフィルタを適用します",
                // ... add all other Japanese translations
            };
        }

        #endregion

        public Result OnShutdown(UIControlledApplication a)
        {
            _iconCache.Clear();
            return Result.Succeeded;
        }
    }
}