using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using Autodesk.Windows;
using RibbonPanel = Autodesk.Revit.UI.RibbonPanel;

namespace ONES
{
    // Token: 0x0200000B RID: 11
    internal class App : IExternalApplication
    {
        // Token: 0x06000024 RID: 36 RVA: 0x00003A54 File Offset: 0x00001C54
        public Result OnStartup(UIControlledApplication a)
        {
            LanguageType language = a.ControlledApplication.Language;
            string folderONES = Settings.Default.folderONES;
            string str = Settings.Default.folderONES + "Videos";
            string panelName = "Modify";
            string panelName2 = "Color";
            string panelName3 = "Generate";
            string panelName4 = "Export to Excel";
            string panelName5 = "Review";
            string panelName6 = "Select";
            string panelName7 = "Collaboration";
            string panelName8 = "ONES";
            string panelModify = LangButtonsEN.PanelModify;
            string text = "Color\nFilter";
            string toolTip = "Generate Filters or Override Graphics by Selected Category and Parameters and Apply the Filters to the Active Views as random colors";
            string longDescription = "① Select Active View(recommended) or All Project\n② Select Parameter Type(Instance or Type)\n③ Select Category(Active View: Only categories of visible elements, All Project: All categories)\n④ Select a Parameter\n⑤ Select Values\n⑥ Check “Halftone” for softer colors\nSelect the following three options, ⑦, ⑧, and ⑨, according to your purpose.\n⑦ Click Filter to generate view Filters\n⑧ Click to “Override” to override graphics in the active view\n⑨ Click “Show” to select elements in Revit";
            string text2 = "R";
            string toolTip2 = "Override selected elements in Active View as Red (Halftone)";
            string text3 = "G";
            string toolTip3 = "Override selected elements in Active View as Green (Halftone)";
            string text4 = "B";
            string toolTip4 = "Override selected elements in Active View as Blue (Halftone)";
            string text5 = "Y";
            string toolTip5 = "Override selected elements in Active View as Blue (Halftone)";
            string text6 = "R";
            string toolTip6 = "Override selected elements in Active View as a Random Color (Halftone)";
            string text7 = "N";
            string toolTip7 = "Reset Override of selected elements in Active View";
            string text8 = "Override\nSettings";
            string toolTip8 = "Override settings for general override feature usages in ONES";
            string text9 = "Copy\nFilters";
            string toolTip9 = "Copies the Filters of Current View to other Selected View";
            string longDescription2 = "① Run the command to open Copy Filters form.\n② Select filters from Filters Panel (left)and select views from Views Panel (right)\n③ Click Copy button";
            string text10 = "Join";
            string toolTip10 = "Join All Elements of Selected Categories";
            string longDescription3 = "① Select Top Category\n② Select Bottom Category\n③ Select All Project or Active View(recommended)\n④ Click Join";
            string text11 = "Unjoin";
            string toolTip11 = "Unjoin Selected Elements";
            string text12 = "Unhide";
            string toolTip12 = "Unhide All Hidden Elements of the Active View";
            string text13 = "Analytical\nOff";
            string toolTip13 = "Disable Analytical Models of the Active View";
            string text14 = "Analytical\nOn";
            string toolTip14 = "Enable Analytical Models of the Active View";
            string text15 = "Analytical";
            string text16 = "Remove Filters";
            string toolTip15 = "Remove All Filters from Active View (doesn't delete filters from the project)";
            string text17 = "Pin";
            string toolTip16 = "Pin All Elements at the Active View";
            string text18 = "View";
            string toolTip17 = "View Features";
            string text19 = "Reset Override";
            string toolTip18 = "Reset Override Graphic settings of all elements in the active view";
            string text20 = "S-Box\nLevels";
            string toolTip19 = "Generate section boxed on each levels";
            string text21 = "S-Box\nGrids";
            string toolTip20 = "Generate section boxed on each grids";
            string text22 = "Left";
            string toolTip21 = "Align selected elements to Left";
            string text23 = "Center";
            string toolTip22 = "Align selected elements to Center";
            string text24 = "Right";
            string toolTip23 = "Align selected elements to Right";
            string text25 = "Top";
            string toolTip24 = "Align selected elements to Top";
            string text26 = "Middle";
            string toolTip25 = "Align selected elements to Middle";
            string text27 = "Bottom";
            string toolTip26 = "Align selected elements to Bottom";
            string text28 = "Floor\nFinish";
            string toolTip27 = "Generates floors by boundary of selected rooms";
            string text29 = "Wall \nTypes";
            string toolTip28 = "Generate a sample of each wall type to a picked point";
            string text30 = "Window \nTypes";
            string toolTip29 = "Generate a wall (default wall type) to the picked point and input every windows types (only host type starting with _ name)";
            string text31 = "Door \nTypes";
            string toolTip30 = "Generate a wall (default wall type) to the picked point and input every door types (only host type starting with _ name)";
            string text32 = "Floor \nTypes";
            string toolTip31 = "Generate a sample of each floor  type to a picked point";
            string text33 = "Type Samples";
            string text34 = "Section";
            string toolTip32 = "Generate Section Views on Grid Lines";
            string longDescription4 = "";
            string text35 = "Grid Dim";
            string toolTip33 = "Put Dimensions to grids of the active view";
            string text36 = "Active\nSchedule";
            string toolTip34 = "Exports Active Schedule View to Excel";
            string text37 = "All\nSchedules";
            string toolTip35 = "Exports All Schedules to Excel";
            string text38 = "All\nLayers";
            string toolTip36 = "Exports Floor, Ceiling and Wall Layers to Excel";
            string text39 = "Wall\nLayers";
            string toolTip37 = "Exports Wall Layers to Excel";
            string text40 = "Ceiling\nLayers";
            string toolTip38 = "Exports Ceiling Layers to Excel";
            string text41 = "Floor\nLayers";
            string toolTip39 = "Exports Floor Layers to Excel";
            string text42 = "Materials\nNames";
            string toolTip40 = "Exports Material Name & Properties to Excel";
            string text43 = "Inspect";
            string toolTip41 = "Inspect Selected Element and Export All Instance & Type Parameters";
            string text44 = "Isolate All Warnings";
            string toolTip42 = "Isolates All Warning Elements in Active View";
            string text45 = "Isolate by User";
            string toolTip43 = "Isolates Warning Elements in Active View by Selected User";
            string text46 = "Warnings Report";
            string toolTip44 = "Report Warning Counts by Users";
            string text47 = "Export Warnings";
            string toolTip45 = "Export Warning to Excel";
            string text48 = "Warning Manager";
            string toolTip46 = "Manage and select warnings from a treeview list";
            string text49 = "Warnings";
            string toolTip47 = "Isolate Elements which are causing Revit Warnings in the active view";
            string text50 = "Model\nSize";
            string toolTip48 = "Model Size (KB)";
            string text51 = "Purge\nTags";
            string toolTip49 = "Purge Orphaned Tags (Hosted by a link element and got orphaned\nafter the host is deleted in the linked document)";
            string text52 = "Purge\nCADs";
            string toolTip50 = "Purge Imported CADs";
            string text53 = "Purge\nFilters";
            string toolTip51 = "Purge Unused Filters";
            string text54 = "Unpinned";
            string toolTip52 = "Isolate Unpinned Elements at the Active View";
            string text55 = "Clash: Isolate";
            string toolTip53 = "Isolate Clashing Elements of the Active View";
            string text56 = "Local\nFile";
            string toolTip54 = "Open the folder of local files and select the local file of current project";
            string text57 = "Zoom\nElements";
            string toolTip55 = "Zoom to Selected Elements";
            string text58 = "Intersects";
            string toolTip56 = "Select Intersecting Elements by Bounding Box \nChecks Elements Only can be seen in the Active View";
            string text59 = "By\nType";
            string toolTip57 = "Select Elements by Type\nIt Can Select Multiple Types Unlike Built-in";
            string text60 = "By\nCategory";
            string toolTip58 = "Select Elements by Category\nIt Can Select Multiple Categories";
            string text61 = "By\nFamily";
            string toolTip59 = "Select Elements by Family\nIt Can Select Multiple Families";
            string text62 = "Select";
            string toolTip60 = "Select elements in the active view";
            string text63 = "Revit\nFilter";
            string toolTip61 = "Select Elements by present Filters of the Project";
            string text64 = "By\nColor";
            string toolTip62 = "Select Elements by Override Color\nIt Can Select Multiple Families";
            string text65 = "Select\nFilter";
            string toolTip63 = "Filter, sort and select elements from the form";
            string text66 = "M+";
            string toolTip64 = "Append the selection memory by selected elements (Similar to Calculator)";
            string text67 = "M-";
            string toolTip65 = "Remove the selected elements from the memory (Similar to Calculator)";
            string text68 = "MR";
            string toolTip66 = "Read the element list from the memory and select it (Similar to Calculator)";
            string text69 = "MC";
            string toolTip67 = "Clear the element list from the memory (Similar to Calculator)";
            string text70 = "Who\nDid";
            string toolTip68 = "Gets Worksharing Info of Selected Single Element: Creator, Owner and Last Changed by";
            string text71 = "Online";
            string toolTip69 = "Shows Online Users (Only Users Who Owns Any Elements)";
            string text72 = "Hide";
            string toolTip70 = "Temporarily Hide Elements Owned by Other Users in Active View";
            string text73 = "Project\nLog";
            string toolTip71 = "Display and Export log report of projects";
            string text74 = "Element\nLog";
            string toolTip72 = "Display and Export log report of projects by each element details";
            string text75 = "Work\nSharing";
            string toolTip73 = "Worksharing Features";
            string text76 = "Win\nCalc";
            string toolTip74 = "Open Windows Calculator";
            string text77 = "Notepad";
            string toolTip75 = "Open Notepad";
            string text78 = "Coffee";
            string toolTip76 = "Read a Coffee Quote and Take a 10-min Coffee Time";
            string text79 = "About";
            string toolTip77 = "About App and Developer";
            string text80 = "Settings";
            string toolTip78 = "Change Settings for the app or return it back to default";
            string text81 = "Help";
            string toolTip79 = "Open User Guide PDF";
            string text82 = "Version";
            string toolTip80 = "Check Updates";
            if (language.ToString() == "Japanese")
            {
                panelName2 = "カラー";
                panelName = "修正";
                panelName3 = "作成";
                panelName4 = "エクセルにエクスポート";
                panelName5 = "レビュー";
                panelName6 = "選択";
                panelName7 = "コラボレーション";
                panelName8 = "ONES";
                text = "カラー\nフィルタ";
                toolTip = "選択したカテゴリとパラメータでフィルタを生成し、ランダムな色としてアクティブなビューにフィルタを適用します";
                longDescription = "① 現在のビュー（推奨）またはすべてのプロジェクトを選択します。\n② パラメータタイプ（インスタンスまたはタイプ）を選択します。\n③ カテゴリを選択します。（現在のビュー：表示されている要素のカテゴリのみ、すべてのプロジェクト：すべてのカテゴリ）\n④ パラメータを選択します。\n⑤ 値を選択します。\n⑥ より柔らかい色については「ハーフトーン」をチェックします。\n目的に合わせて下記⑦⑧⑨の3つの選択をします。\n⑦「フィルタ」をクリックしてビューフィルタを生成する。\n⑧「上書き」をクリックして要素のグラフィックを様々な色で上書きする。\n⑨「表示」をクリックしてRevitの要素を選択します。";
                text2 = "R";
                toolTip2 = "現在のビューで選択した要素を赤色（ハーフトーン）として上書きする";
                text3 = "G";
                toolTip3 = "現在のビューで選択した要素を緑色（ハーフトーン）として上書きする";
                text4 = "B";
                toolTip4 = "現在のビューで選択した要素を青い色（ハーフトーン）として上書きする";
                text5 = "Y";
                toolTip5 = "現在のビューで選択した要素を黄色（ハーフトーン）として上書きする";
                text6 = "R";
                toolTip6 = "現在のビューで選択した要素をランダム色（ハーフトーン）として上書きする";
                text7 = "N";
                toolTip7 = "現在のビューで選択した要素のオーバーライドをリセット";
                text8 = "上書きの設定";
                toolTip8 = "一般的なグラフィック上書きの設定を調整します";
                text9 = "フィルタの\nコピー";
                toolTip9 = "現在のビューのフィルタを他の選択したビューにコピーします";
                longDescription2 = "① コマンドを実行して、「フィルタのコピー」フォームを開きます。\n② 左のパネルからフィルタを選択し、右のパネルからビューを選択します。\n③ コピーボタンをクリックします。";
                text10 = "結合";
                toolTip10 = "選択したカテゴリのすべての要素に結合する";
                longDescription3 = "① 上位カテゴリを選択します。\n② 下位カテゴリを選択します。\n③ 現在のビューまたはすべてのプロジェクトを選択します。\n④「結合」をクリックします。";
                text11 = "結合\n解除";
                toolTip11 = "選択した要素を結合解除します";
                text12 = "再表示";
                toolTip12 = "現在のビューのすべての非表示要素を再表示";
                text13 = "解析の\n無効";
                toolTip13 = "解析モデルを無効にする";
                text14 = "解析の\n有効";
                toolTip14 = "解析モデルを有効にする";
                text16 = "フィルタの除去";
                toolTip15 = "現在のビューからすべてのフィルタを除去します。（フィルタは削除されない）";
                text17 = "ピン";
                toolTip16 = "現在のビューで要素を固定する";
                text54 = "固定解除";
                toolTip52 = "現在のビューで固定されていない要素を分離する";
                text18 = "ビュー\n機能";
                toolTip17 = "ビュの機能";
                text19 = "表示上書きの削除";
                toolTip18 = "現在のビューにある全ての要素のグラフィック表示上書きを削除します";
                text20 = "S-Box\nLevels";
                toolTip19 = "Generate section boxed on each levels";
                text21 = "S-Box\nGrids";
                toolTip20 = "Generate section boxed on each grids";
                text22 = "左";
                toolTip21 = "選択した要素を左揃え";
                text23 = "中央";
                toolTip22 = "選択した要素を左揃え";
                text24 = "右";
                toolTip23 = "選択した要素を左揃え";
                text25 = "上";
                toolTip24 = "選択した要素を上揃え";
                text26 = "中央";
                toolTip25 = "選択した要素を上下中央揃え";
                text27 = "下";
                toolTip26 = "選択した要素を下揃え";
                text28 = "仕上床の\n作成";
                toolTip27 = "選択した部屋の境界で床を作成します。";
                text29 = "壁の種類";
                toolTip28 = "プロジェクト内にある全ての壁タイプを作成します。";
                text30 = "窓の種類";
                toolTip29 = "プロジェクト内にある全ての窓タイプ（_で始まるホストタイプのみ）を任意の壁に生成します。";
                text31 = "ドアの種類";
                toolTip30 = "プロジェクト内にある全てのドアタイプ（_で始まるホストタイプのみ）を任意の壁に生成します。";
                text32 = "床の種類";
                toolTip31 = "プロジェクト内にある全ての床タイプ（_で始まるホストタイプのみ）を任意の壁に生成します。";
                text34 = "断面図";
                toolTip32 = "通り芯に断面図ビューを生成する";
                text35 = "通芯の寸法";
                toolTip33 = "アクティブなビューのグリッドに寸法を配置";
                text36 = "アクティブ\n集計表";
                toolTip34 = "アクティブなスケジュールビューをエクセルにエクスポート";
                text37 = "すべての\n集計表";
                toolTip35 = "すべてのスケジュールをエクセルにエクスポート";
                text38 = "すべての\nレイヤー";
                toolTip36 = "床、天井、壁のレイヤーをExcelにエクスポート";
                text39 = "壁の\nレイヤー";
                toolTip37 = "壁レイヤーをエクセルにエクスポート";
                text40 = "天井の\nレイヤー";
                toolTip38 = "天井レイヤーをエクセルにエクスポート";
                text41 = "床の\nレイヤー";
                toolTip39 = "エクセルにフロアレイヤーをエクスポート";
                text42 = "マテリアルの\n名前";
                toolTip40 = "マテリアル名をエクセルにエクスポート";
                text43 = "要素の調査";
                toolTip41 = "選択した要素を検査し、すべてのインスタンスとタイプパラメータをExcelにエクスポートします。";
                text50 = "モデルの容量";
                toolTip48 = "モデルサイズ（KB）";
                text44 = "全ての警告を表示";
                toolTip42 = "現在のビュー内のすべての警告要素を分離します";
                text45 = "ユーザー別表示";
                toolTip43 = "現在のビュー内の警告要素をユーザー別分離します";
                text46 = "警告リポート";
                toolTip44 = "ユーザーごとの警告カウントをリポートする";
                text49 = "警告";
                text51 = "タグの\nパージ";
                toolTip49 = "孤立したタグを削除します（リンク要素によってホストされ\nリンクされたドキュメントでホストが削除された後、孤立しました）";
                text52 = "CADの\nパージ";
                toolTip50 = "インポートされたCADをパージする";
                text53 = "フィルタの\nパージ";
                toolTip51 = "アイコンをクリックし、リストからフィルタを選択して削除します";
                text55 = "Clash: Isolate";
                toolTip53 = "Isolate Clashing Elements of the Active View";
                text56 = "ローカルファイル";
                toolTip54 = "ローカルファイルのフォルダを開き、現在のプロジェクトのローカルファイルを選択します";
                text57 = "要素に\nズーム";
                toolTip55 = "選択した要素にズーム";
                text58 = "交差する\n要素を選択";
                toolTip56 = "選択した要素と交差する要素を選択\nアクティブなビューでのみ表示できる要素をチェックします";
                text59 = "タイプ\n別";
                toolTip57 = "タイプで要素を選択\n複数のタイプを選択できます";
                text60 = "カテゴリ\n別";
                toolTip58 = "カテゴリで要素を選択（複数のカテゴリを選択できます）";
                text61 = "ファミリ\n別";
                toolTip59 = "ファミリで要素を選択（複数のファミリを選択できます）";
                text63 = "Revit\nフィルタ";
                toolTip61 = "プロジェクトの現在のフィルタで要素を選択";
                text62 = "選択";
                toolTip60 = "現在のビューで要素を選択します";
                text64 = "色\n別";
                toolTip62 = "色で要素を選択（複数の色を選択できます）";
                text65 = "Select\nFilter";
                toolTip63 = "Select Filter";
                text70 = "作成者\n修正者";
                toolTip68 = "選択した単一要素のワークシェアリング情報を取得：作成者、所有者、最終変更者";
                text71 = "オンライン\nユーザー";
                toolTip69 = "オンラインユーザーを表示（要素を所有するユーザーのみ）";
                text72 = "オーナーのある\n要素の非表示";
                toolTip70 = "現在のビューで他のユーザーが所有する要素を一時的に非表示にする";
                text73 = "プロジェクトの\nログ";
                toolTip71 = "Revitとプロジェクトのログ";
                text74 = "要素の\nログ";
                toolTip72 = "Revitとプロジェクトの要素のログ";
                text75 = "ワーク\nシェアリング";
                toolTip73 = "ワークシェアリングの機能";
                text76 = "電卓";
                toolTip74 = "Open Windows Calculator";
                text77 = "メモ帳";
                toolTip75 = "メモ帳を開く";
                text78 = "コーヒー";
                toolTip76 = "コーヒーの見積もりを読み、10分のコーヒータイムを取る";
                text79 = "アプリについて";
                toolTip77 = "アプリと開発者について";
                text80 = "設定";
                toolTip78 = "アプリの設定";
                text81 = "ヘルプ";
                toolTip78 = "ユーザーガイドpdfを開きます";
                text82 = "バージョン";
                toolTip80 = "アップデートをチェックする";
            }

            RibbonPanel ribbonPanel = this.RibbonPanel(a, "ONES", panelName2);
            RibbonPanel ribbonPanel2 = this.RibbonPanel(a, "ONES", panelName);
            RibbonPanel ribbonPanel3 = this.RibbonPanel(a, "ONES", panelName3);
            RibbonPanel ribbonPanel4 = this.RibbonPanel(a, "ONES", panelName4);
            RibbonPanel ribbonPanel5 = this.RibbonPanel(a, "ONES", panelName5);
            RibbonPanel ribbonPanel6 = this.RibbonPanel(a, "ONES", panelName6);
            RibbonPanel ribbonPanel7 = this.RibbonPanel(a, "ONES", panelName7);
            RibbonPanel ribbonPanel8 = this.RibbonPanel(a, "ONES", "Bonus");
            RibbonPanel ribbonPanel9 = this.RibbonPanel(a, "ONES", panelName8);
            string location = Assembly.GetExecutingAssembly().Location;
            PushButtonData pushButtonData = new PushButtonData("ButtonColorFilter", text, location, "ONES.ColorFilter")
            {
                ToolTip = toolTip,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/colorfilter.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/colorfilter16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/colorfilter.png")),
                LongDescription = longDescription
            };
            pushButtonData.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\ColorFilter.mp4"));
            PushButton pushButton = ribbonPanel.AddItem(pushButtonData) as PushButton;
            PushButtonData pushButtonData2 = new PushButtonData("ButtonORed", text2, location, "ONES.OverrideRed")
            {
                ToolTip = toolTip2,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/overridered16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/override.png"))
            };
            pushButtonData2.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Override.mp4"));
            PushButtonData pushButtonData3 = new PushButtonData("ButtonOGreen", text3, location, "ONES.OverrideGreen")
            {
                ToolTip = toolTip3,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/overridegreen16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/override.png"))
            };
            pushButtonData3.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Override.mp4"));
            PushButtonData pushButtonData4 = new PushButtonData("ButtonOBlue", text4, location, "ONES.OverrideBlue")
            {
                ToolTip = toolTip4,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/overrideblue16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/override.png"))
            };
            pushButtonData4.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Override.mp4"));
            ribbonPanel.AddStackedItems(pushButtonData2, pushButtonData3, pushButtonData4);
            PushButtonData pushButtonData5 = new PushButtonData("ButtonOYellow", text5, location, "ONES.OverrideYellow")
            {
                ToolTip = toolTip5,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/overrideyellow16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/override.png"))
            };
            pushButtonData5.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Override.mp4"));
            PushButtonData pushButtonData6 = new PushButtonData("ButtonORandom", text6, location, "ONES.OverrideRandom")
            {
                ToolTip = toolTip6,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/overriderainbow16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/override.png"))
            };
            pushButtonData6.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Override.mp4"));
            PushButtonData pushButtonData7 = new PushButtonData("ButtonONone", text7, location, "ONES.OverrideNone")
            {
                ToolTip = toolTip7,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/overridegray16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/overridereset.png"))
            };
            pushButtonData7.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Override.mp4"));
            ribbonPanel.AddStackedItems(pushButtonData5, pushButtonData6, pushButtonData7);
            ribbonPanel.AddSlideOut();
            PushButtonData pushButtonData8 = new PushButtonData("ButtonOSettings", text8, location, "ONES.OverrideSettings")
            {
                ToolTip = toolTip8,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/settings16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/settings.png"))
            };
            PushButton pushButton2 = ribbonPanel.AddItem(pushButtonData8) as PushButton;
            PushButtonData pushButtonData9 = new PushButtonData("ButtonCopyFilters", text9, location, "ONES.CopyFilters")
            {
                ToolTip = toolTip9,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/copyfilter.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/copyfilter.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/copyfilter.png")),
                LongDescription = longDescription2
            };
            pushButtonData9.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\CopyFilters.mp4"));
            PushButton pushButton3 = ribbonPanel2.AddItem(pushButtonData9) as PushButton;
            PushButtonData pushButtonData10 = new PushButtonData("ButtonJoin", text10, location, "ONES.JoinElements")
            {
                ToolTip = toolTip10,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/join.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/join16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/join.png")),
                LongDescription = longDescription3
            };
            pushButtonData10.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\JoinElements.mp4"));
            PushButtonData pushButtonData11 = new PushButtonData("ButtonUnjoin", text11, location, "ONES.Unjoin")
            {
                ToolTip = toolTip11,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/unjoin.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/unjoin16.png"))
            };
            SplitButtonData splitButtonData = new SplitButtonData("splitButtonJoin", text10);
            SplitButton splitButton = ribbonPanel2.AddItem(splitButtonData) as SplitButton;
            splitButton.AddPushButton(pushButtonData10);
            splitButton.AddPushButton(pushButtonData11);
            PushButtonData pushButtonData12 = new PushButtonData("ButtonUnhide", text12, location, "ONES.Unhide")
            {
                ToolTip = toolTip12,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/unhide.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/unhide16.png"))
            };
            PushButtonData pushButtonData13 = new PushButtonData("ButtonRFilters", text16, location, "ONES.RemoveFilters")
            {
                ToolTip = toolTip15,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/filterremove16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/filterremove.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/removefilters.png"))
            };
            pushButtonData13.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\RemoveFilters.mp4"));
            PushButtonData pushButtonData14 = new PushButtonData("ButtonPin", text17, location, "ONES.Pin")
            {
                ToolTip = toolTip16,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/pin16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/pin.png"))
            };
            PushButtonData pushButtonData15 = new PushButtonData("ButtonIUnpinned", text54, location, "ONES.IsolateUnpinned")
            {
                ToolTip = toolTip52,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/unpin16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/unpin.png"))
            };
            pushButtonData15.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Unpinned.mp4"));
            PushButtonData pushButtonData16 = new PushButtonData("ButtonResetOverride", text19, location, "ONES.ResetOverride");
            pushButtonData16.ToolTip = toolTip18;
            pushButtonData16.Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/reset16.png"));
            pushButtonData16.LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/reset.png"));
            PushButtonData pushButtonData17 = new PushButtonData("ButtonSectionBoxLevels", text20, location, "ONES.SectionBoxLevels");
            pushButtonData17.ToolTip = toolTip19;
            pushButtonData17.Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/reset16.png"));
            pushButtonData17.LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/reset.png"));
            PushButtonData pushButtonData18 = new PushButtonData("ButtonSectionBoxGrids", text21, location, "ONES.SectionBoxGrids");
            pushButtonData18.ToolTip = toolTip20;
            pushButtonData18.Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/reset16.png"));
            pushButtonData18.LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/reset.png"));
            PulldownButtonData pulldownButtonData = new PulldownButtonData("pullDownView", text18)
            {
                ToolTip = toolTip17,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/view.png"))
            };
            PulldownButton pulldownButton = ribbonPanel2.AddItem(pulldownButtonData) as PulldownButton;
            pulldownButton.AddPushButton(pushButtonData12);
            pulldownButton.AddPushButton(pushButtonData13);
            pulldownButton.AddPushButton(pushButtonData14);
            pulldownButton.AddPushButton(pushButtonData15);
            PushButtonData pushButtonData19 = new PushButtonData("ButtonAnalyticalOff", text13, location, "ONES.AnalyticalDisable")
            {
                ToolTip = toolTip13,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/lightoff16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/lightoff.png"))
            };
            PushButtonData pushButtonData20 = new PushButtonData("ButtonAnalyticalOn", text14, location, "ONES.AnalyticalEnable")
            {
                ToolTip = toolTip14,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/lighton16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/lighton.png"))
            };
            SplitButtonData splitButtonData2 = new SplitButtonData("splitButtonAnalytical", text15);
            SplitButton splitButton2 = ribbonPanel2.AddItem(splitButtonData2) as SplitButton;
            splitButton2.AddPushButton(pushButtonData19);
            splitButton2.AddPushButton(pushButtonData20);
            PushButtonData pushButtonData21 = new PushButtonData("ButtonAlignLeft", text22, location, "ONES.AlignLeft")
            {
                ToolTip = toolTip21,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/alignleft16.png"))
            };
            pushButtonData21.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Align.mp4"));
            PushButtonData pushButtonData22 = new PushButtonData("ButtonAlignCenter", text23, location, "ONES.AlignCenter")
            {
                ToolTip = toolTip22,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/aligncenter16.png"))
            };
            pushButtonData22.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Align.mp4"));
            PushButtonData pushButtonData23 = new PushButtonData("ButtonAlignRight", text24, location, "ONES.AlignRight")
            {
                ToolTip = toolTip23,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/alignright16.png"))
            };
            pushButtonData23.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Align.mp4"));
            PushButtonData pushButtonData24 = new PushButtonData("ButtonAlignTop", text25, location, "ONES.AlignTop")
            {
                ToolTip = toolTip24,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/aligntop16.png"))
            };
            pushButtonData24.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Align.mp4"));
            PushButtonData pushButtonData25 = new PushButtonData("ButtonAlignMiddle", text26, location, "ONES.AlignMiddle")
            {
                ToolTip = toolTip25,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/alignmiddle16.png"))
            };
            pushButtonData25.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Align.mp4"));
            PushButtonData pushButtonData26 = new PushButtonData("ButtonAlignBottom", text27, location, "ONES.AlignBottom")
            {
                ToolTip = toolTip26,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/alignbottom16.png"))
            };
            pushButtonData26.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Align.mp4"));
            PushButtonData pushButtonData27 = new PushButtonData("FloorbyRoom", text28, location, "ONES.FloorbyRoom")
            {
                ToolTip = toolTip27,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/floorgenerate.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/floorgenerate16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/floorbyroom.png"))
            };
            pushButtonData27.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\FloorbyRoom.mp4"));
            PushButton pushButton4 = ribbonPanel3.AddItem(pushButtonData27) as PushButton;
            PushButtonData pushButtonData28 = new PushButtonData("ButtonTypesWalls", text29, location, "ONES.TypesWalls")
            {
                ToolTip = toolTip28,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/wall16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/wall.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/typewalls.png"))
            };
            pushButtonData28.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\TypeWall.mp4"));
            PushButtonData pushButtonData29 = new PushButtonData("ButtonTypesWindows", text30, location, "ONES.TypesWindows")
            {
                ToolTip = toolTip29,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/window16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/window.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/typeswindows.png"))
            };
            pushButtonData29.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\TypeWindows.mp4"));
            PushButtonData pushButtonData30 = new PushButtonData("ButtonTypesDoors", text31, location, "ONES.TypesDoors")
            {
                ToolTip = toolTip30,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/door16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/door.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/typesdoors.png"))
            };
            pushButtonData30.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\TypeDoors.mp4"));
            PushButtonData pushButtonData31 = new PushButtonData("ButtonTypesFloors", text32, location, "ONES.TypesFloors")
            {
                ToolTip = toolTip31,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/floor16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/floor.png"))
            };
            SplitButtonData splitButtonData3 = new SplitButtonData("splitButtonTypeSamples", text33);
            SplitButton splitButton3 = ribbonPanel3.AddItem(splitButtonData3) as SplitButton;
            splitButton3.AddPushButton(pushButtonData28);
            splitButton3.AddPushButton(pushButtonData29);
            splitButton3.AddPushButton(pushButtonData30);
            splitButton3.AddPushButton(pushButtonData31);
            PushButtonData pushButtonData32 = new PushButtonData("ButtonSection", text34, location, "ONES.Section")
            {
                ToolTip = toolTip32,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/section16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/section.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/section.png")),
                LongDescription = longDescription4
            };
            pushButtonData32.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Section.mp4"));
            PushButtonData pushButtonData33 = new PushButtonData("ButtonDimensionGrids", text35, location, "ONES.DimensionGrids")
            {
                ToolTip = toolTip33,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/dimension.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/dimension16.png"))
            };
            pushButtonData33.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\DimensionGrids.mp4"));
            ribbonPanel3.AddStackedItems(pushButtonData32, pushButtonData33);
            PushButtonData pushButtonData34 = new PushButtonData("Buttoneas", text36, location, "ONES.ExportActiveSchedule")
            {
                ToolTip = toolTip34,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/sheet.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/sheet16.png"))
            };
            pushButtonData34.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\ExportActiveSchedule.mp4"));
            PushButtonData pushButtonData35 = new PushButtonData("Buttonealls", text37, location, "ONES.ExportAllSchedules")
            {
                ToolTip = toolTip35,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/sheetdouble.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/sheetdouble16.png"))
            };
            pushButtonData35.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\ExportAllSchedules.mp4"));
            SplitButtonData splitButtonData4 = new SplitButtonData("splitButtonExportSchedule", "Export Schedules");
            SplitButton splitButton4 = ribbonPanel4.AddItem(splitButtonData4) as SplitButton;
            splitButton4.AddPushButton(pushButtonData34);
            splitButton4.AddPushButton(pushButtonData35);
            PushButtonData pushButtonData36 = new PushButtonData("ButtonExportAll", text38, location, "ONES.ExportAllLayers")
            {
                ToolTip = toolTip36,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/exportlayers.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/exportlayers16.png"))
            };
            pushButtonData36.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\ExportWall,Ceiling,FloorLayers.mp4"));
            PushButtonData pushButtonData37 = new PushButtonData("Buttonewl", text39, location, "ONES.ExportWallLayers")
            {
                ToolTip = toolTip37,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/exportlayers.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/exportlayers16.png"))
            };
            pushButtonData37.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\ExportWall,Ceiling,FloorLayers.mp4"));
            PushButtonData pushButtonData38 = new PushButtonData("Buttonecl", text40, location, "ONES.ExportCeilingLayers")
            {
                ToolTip = toolTip38,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/exportlayers.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/exportlayers16.png"))
            };
            pushButtonData38.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\ExportWall,Ceiling,FloorLayers.mp4"));
            PushButtonData pushButtonData39 = new PushButtonData("Buttonefl", text41, location, "ONES.ExportFloorLayers")
            {
                ToolTip = toolTip39,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/exportlayers.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/exportlayers16.png"))
            };
            pushButtonData39.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\ExportWall,Ceiling,FloorLayers.mp4"));
            SplitButtonData splitButtonData5 = new SplitButtonData("splitButtonExportLayers", "Export Layers");
            SplitButton splitButton5 = ribbonPanel4.AddItem(splitButtonData5) as SplitButton;
            splitButton5.AddPushButton(pushButtonData37);
            splitButton5.AddPushButton(pushButtonData38);
            splitButton5.AddPushButton(pushButtonData39);
            PushButtonData pushButtonData40 = new PushButtonData("ButtonEM", text42, location, "ONES.ExportMaterials")
            {
                ToolTip = toolTip40,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/excel.png"))
            };
            PushButton pushButton5 = ribbonPanel4.AddItem(pushButtonData40) as PushButton;
            PushButtonData pushButtonData41 = new PushButtonData("ButtonInspectElement", text43, location, "ONES.InspectElement")
            {
                ToolTip = toolTip41,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/inspectelements.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/inspect16.png"))
            };
            pushButtonData41.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\Inspect.mp4"));
            PushButtonData pushButtonData42 = new PushButtonData("ButtonWI", text44, location, "ONES.WarningsIsolate")
            {
                ToolTip = toolTip42,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/warnings.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/warnings16.png"))
            };
            PushButtonData pushButtonData43 = new PushButtonData("ButtonWIU", text45, location, "ONES.WarningsIsolateUser")
            {
                ToolTip = toolTip43,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/warnings.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/warnings16.png"))
            };
            PushButtonData pushButtonData44 = new PushButtonData("ButtonWC", text46, location, "ONES.WarningsCount")
            {
                ToolTip = toolTip44,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/warnings16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/warnings.png"))
            };
            PushButtonData pushButtonData45 = new PushButtonData("ButtonWarningsExport", text47, location, "ONES.WarningsExport");
            pushButtonData45.ToolTip = toolTip45;
            pushButtonData45.Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/warnings16.png"));
            pushButtonData45.LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/warnings.png"));
            PushButtonData pushButtonData46 = new PushButtonData("ButtonWarningManager", text48, location, "ONES.WarningManager");
            pushButtonData46.ToolTip = toolTip46;
            pushButtonData46.Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/warnings16.png"));
            pushButtonData46.LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/warnings.png"));
            PulldownButtonData pulldownButtonData2 = new PulldownButtonData("pullDownWarnings", text49)
            {
                ToolTip = toolTip47,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/warnings.png"))
            };
            PulldownButton pulldownButton2 = ribbonPanel5.AddItem(pulldownButtonData2) as PulldownButton;
            pulldownButton2.AddPushButton(pushButtonData42);
            pulldownButton2.AddPushButton(pushButtonData43);
            pulldownButton2.AddPushButton(pushButtonData44);
            PushButtonData pushButtonData47 = new PushButtonData("ButtonPOT", text51, location, "ONES.PurgeTags")
            {
                ToolTip = toolTip49,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/tag16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/tag.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/purgetags.png"))
            };
            PushButtonData pushButtonData48 = new PushButtonData("ButtonCAD", text52, location, "ONES.PurgeCAD")
            {
                ToolTip = toolTip50,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/cad16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/cad.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/purgecad.png"))
            };
            PushButtonData pushButtonData49 = new PushButtonData("ButtonPFilters", text53, location, "ONES.PurgeFilters")
            {
                ToolTip = toolTip51,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/filter16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/filter.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/purgefilter.png"))
            };
            SplitButtonData splitButtonData6 = new SplitButtonData("splitButtonPurge", "Purge");
            SplitButton splitButton6 = ribbonPanel5.AddItem(splitButtonData6) as SplitButton;
            splitButton6.AddPushButton(pushButtonData48);
            splitButton6.AddPushButton(pushButtonData49);
            splitButton6.AddPushButton(pushButtonData47);
            PushButtonData pushButtonData50 = new PushButtonData("ButtonModelSize", text50, location, "ONES.ModelSize")
            {
                ToolTip = toolTip48,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/modelsize16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/modelsize.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/modelsize.png"))
            };
            pushButtonData50.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\ModelSize.mp4"));
            PushButtonData pushButtonData51 = new PushButtonData("ButtonLocalFile", text56, location, "ONES.LocalFile")
            {
                ToolTip = toolTip54,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/folder16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/folder.png"))
            };
            ribbonPanel5.AddStackedItems(pushButtonData41, pushButtonData50, pushButtonData51);
            PushButtonData pushButtonData52 = new PushButtonData("ButtonClashIsolate", text55, location, "ONES.ClashIsolate");
            pushButtonData52.ToolTip = toolTip53;
            pushButtonData52.Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/clash16.png"));
            pushButtonData52.LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/clash.png"));
            PushButtonData pushButtonData53 = new PushButtonData("ButtonSelectFilter", text65, location, "ONES.SelectFilter")
            {
                ToolTip = toolTip63,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/filterplus.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/filterplus16.png"))
            };
            PushButton pushButton6 = ribbonPanel6.AddItem(pushButtonData53) as PushButton;
            PushButtonData pushButtonData54 = new PushButtonData("ButtonST", text59, location, "ONES.SelectType")
            {
                ToolTip = toolTip57,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/select16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/select.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/selecttype.png"))
            };
            pushButtonData54.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\SelectType.mp4"));
            PushButtonData pushButtonData55 = new PushButtonData("ButtonSC", text60, location, "ONES.SelectCategory")
            {
                ToolTip = toolTip58,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/select16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/select.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/selectcategory.png"))
            };
            pushButtonData55.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\SelectCategory.mp4"));
            PushButtonData pushButtonData56 = new PushButtonData("ButtonSF", text61, location, "ONES.SelectFamily")
            {
                ToolTip = toolTip59,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/select.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/select16.png"))
            };
            PushButtonData pushButtonData57 = new PushButtonData("ButtonSColor", text64, location, "ONES.SelectColor")
            {
                ToolTip = toolTip62,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/select.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/select16.png"))
            };
            PulldownButtonData pulldownButtonData3 = new PulldownButtonData("pullDownSelect", text62)
            {
                ToolTip = toolTip60,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/select.png"))
            };
            PulldownButton pulldownButton3 = ribbonPanel6.AddItem(pulldownButtonData3) as PulldownButton;
            pulldownButton3.AddPushButton(pushButtonData54);
            pulldownButton3.AddPushButton(pushButtonData56);
            pulldownButton3.AddPushButton(pushButtonData55);
            pulldownButton3.AddPushButton(pushButtonData57);
            PushButtonData pushButtonData58 = new PushButtonData("Buttonze", text57, location, "ONES.ZoomElements")
            {
                ToolTip = toolTip55,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/zoomelements.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/zoomelements16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/zoomelements.png"))
            };
            pushButtonData58.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\ZoomElements.mp4"));
            PushButton pushButton7 = ribbonPanel6.AddItem(pushButtonData58) as PushButton;
            PushButtonData pushButtonData59 = new PushButtonData("ButtonSIE", text58, location, "ONES.SelectIntersectingElements")
            {
                ToolTip = toolTip56,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/clash.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/clash16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/selectintersects.png"))
            };
            PushButtonData pushButtonData60 = new PushButtonData("ButtonFilterRevit", text63, location, "ONES.FilterRevit")
            {
                ToolTip = toolTip61,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/filter.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/filter16.png"))
            };
            pushButtonData60.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\ByFilter.mp4"));
            ribbonPanel6.AddStackedItems(pushButtonData59, pushButtonData60);
            PushButtonData pushButtonData61 = new PushButtonData("ButtonMPlus", text66, location, "ONES.MPlus")
            {
                ToolTip = toolTip64,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/mplus24.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/mplus16.png"))
            };
            PushButtonData pushButtonData62 = new PushButtonData("ButtonMMinus", text67, location, "ONES.MMinus")
            {
                ToolTip = toolTip65,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/mminus24.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/mminus16.png"))
            };
            PushButtonData pushButtonData63 = new PushButtonData("ButtonMRead", text68, location, "ONES.MRead")
            {
                ToolTip = toolTip66,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/mread24.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/mread16.png"))
            };
            PushButtonData pushButtonData64 = new PushButtonData("ButtonMClear", text69, location, "ONES.MClear")
            {
                ToolTip = toolTip67,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/mclear24.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/mclear16.png"))
            };
            ribbonPanel6.AddSeparator();
            ribbonPanel6.AddStackedItems(pushButtonData61, pushButtonData62);
            ribbonPanel6.AddStackedItems(pushButtonData63, pushButtonData64);
            try
            {
                RibbonControl ribbon = ComponentManager.Ribbon;
                foreach (RibbonTab ribbonTab in ribbon.Tabs)
                {
                    if (ribbonTab.Name == "BIM Interoperability Tools")
                    {
                        ribbonTab.Title = "BIT";
                    }
                }
            }
            catch (Exception)
            {
            }

            PushButtonData pushButtonData65 = new PushButtonData("ButtonLogReport", text73, location, "ONES.LogProject")
            {
                ToolTip = toolTip71,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/logreport.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/logreport16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/logreport.png"))
            };
            pushButtonData65.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\LogReport.mp4"));
            PushButtonData pushButtonData66 = new PushButtonData("ButtonLogElement", text74, location, "ONES.LogElement");
            pushButtonData66.ToolTip = toolTip72;
            pushButtonData66.LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/logreport.png"));
            pushButtonData66.Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/logreport16.png"));
            PushButton pushButton8 = ribbonPanel7.AddItem(pushButtonData65) as PushButton;
            PushButtonData pushButtonData67 = new PushButtonData("ButtonWhoDid", text70, location, "ONES.WhoDid")
            {
                ToolTip = toolTip68,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/whodid.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/whodid16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/whodid.png"))
            };
            pushButtonData67.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, str + "\\WhoDid.mp4"));
            PushButton pushButton9 = ribbonPanel7.AddItem(pushButtonData67) as PushButton;
            PushButtonData pushButtonData68 = new PushButtonData("ButtonOnlineUsers", text71, location, "ONES.OnlineUsers")
            {
                ToolTip = toolTip69,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/onlineusers16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/onlineusers.png"))
            };
            PushButtonData pushButtonData69 = new PushButtonData("ButtonHideOwned", text72, location, "ONES.HideOwnedElements")
            {
                ToolTip = toolTip70,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/hideownedelements16.png")),
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/hideownedelements.png"))
            };
            PulldownButtonData pulldownButtonData4 = new PulldownButtonData("pullDownWorksharing", text75)
            {
                ToolTip = toolTip73,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/worksharing.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/worksharing16.png"))
            };
            PulldownButton pulldownButton4 = ribbonPanel7.AddItem(pulldownButtonData4) as PulldownButton;
            pulldownButton4.AddPushButton(pushButtonData68);
            pulldownButton4.AddPushButton(pushButtonData69);
            PushButtonData pushButtonData70 = new PushButtonData("ButtonCoffee", text78, location, "ONES.CoffeeTime")
            {
                ToolTip = toolTip76,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/coffee.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/coffee16.png")),
                ToolTipImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/ToolbarImage/coffeetime.png"))
            };
            PushButtonData pushButtonData71 = new PushButtonData("ButtonWC", text76, location, "ONES.WinCalc")
            {
                ToolTip = toolTip74,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/wincalc.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/wincalc16.png"))
            };
            PushButtonData pushButtonData72 = new PushButtonData("ButtonNP", text77, location, "ONES.Notepad")
            {
                ToolTip = toolTip75,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/notepad.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/notepad16.png"))
            };
            ribbonPanel8.AddStackedItems(pushButtonData70, pushButtonData71, pushButtonData72);
            PushButtonData pushButtonData73 = new PushButtonData("ButtonAAbout", text79, location, "ONES.AboutApp")
            {
                ToolTip = toolTip77,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/about16.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/about16.png"))
            };
            PushButtonData pushButtonData74 = new PushButtonData("ButtonSettings", text80, location, "ONES.SettingsONES")
            {
                ToolTip = toolTip78,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/settings.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/settings16.png"))
            };
            PushButtonData pushButtonData75 = new PushButtonData("ButtonUpdate", text82, location, "ONES.Update")
            {
                ToolTip = toolTip80,
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/update16.png"))
            };
            try
            {
                string onesdll = Settings.Default.ONESdll;
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(onesdll);
                string fileVersion = versionInfo.FileVersion;
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                versionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
                string fileVersion2 = versionInfo.FileVersion;
                if (fileVersion != fileVersion2)
                {
                    pushButtonData75.Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/updatenew16.png"));
                }
            }
            catch (Exception)
            {
            }

            ribbonPanel9.AddStackedItems(pushButtonData74, pushButtonData73, pushButtonData75);
            PushButtonData pushButtonData76 = new PushButtonData("ButtonHelp", text81, location, "ONES.Help")
            {
                ToolTip = toolTip79,
                LargeImage = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/help.png")),
                Image = new BitmapImage(new Uri("pack://application:,,,/ONES;component/Icons/help16.png"))
            };
            PushButton pushButton10 = ribbonPanel9.AddItem(pushButtonData76) as PushButton;
            return Result.Succeeded;
        }

        // Token: 0x06000025 RID: 37 RVA: 0x0000675C File Offset: 0x0000495C
        public RibbonPanel RibbonPanel(UIControlledApplication a, string tabName, string panelName)
        {
            RibbonPanel result = null;
            try
            {
                a.CreateRibbonTab(tabName);
            }
            catch
            {
            }

            try
            {
                RibbonPanel ribbonPanel = a.CreateRibbonPanel(tabName, panelName);
            }
            catch
            {
            }

            List<RibbonPanel> ribbonPanels = a.GetRibbonPanels(tabName);
            foreach (RibbonPanel ribbonPanel2 in ribbonPanels)
            {
                if (ribbonPanel2.Name == panelName)
                {
                    result = ribbonPanel2;
                }
            }

            return result;
        }

        // Token: 0x06000026 RID: 38 RVA: 0x000067F4 File Offset: 0x000049F4
        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
