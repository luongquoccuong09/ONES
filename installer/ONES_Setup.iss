; Inno Setup Script để cài đặt ONES Addin
; Tác giả: [Tên của bạn]
; Ngày tạo: 2026-05-04

#define MyAppName "ONES Addin"
#define MyAppVersion "1.0"
#define MyAppPublisher "Your Company Name"

[Setup]
; Thông tin cơ bản
AppId={{5458198b-e69f-46a4-b930-1d7e6d8458aa}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={commonappdata}\Autodesk\Revit\Addins\2025
DisableProgramGroupPage=yes
OutputDir=Output
OutputBaseFilename=ONES_Addin_Setup
Compression=lzma
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=admin
DirExistsWarning=no

; Thư mục và icon
SetupIconFile=

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
; Copy ONES.dll và ONES.addin trực tiếp vào thư mục Revit Addins 2025
; C:\ProgramData\Autodesk\Revit\Addins\2025
Source: "ONES.dll"; DestDir: "{commonappdata}\Autodesk\Revit\Addins\2025"; Flags: ignoreversion
Source: "ONES.addin"; DestDir: "{commonappdata}\Autodesk\Revit\Addins\2025"; Flags: ignoreversion

[Code]
function InitializeSetup(): Boolean;
var
  AddinsPath: String;
begin
  Result := True;
  
  // Tạo thư mục Revit Addins 2025 nếu chưa tồn tại
  AddinsPath := ExpandConstant('{commonappdata}\Autodesk\Revit\Addins\2025');
  if not DirExists(AddinsPath) then
  begin
    if not ForceDirectories(AddinsPath) then
    begin
      MsgBox('Cannot create Revit Addins folder: ' + AddinsPath + #13#10 + 
             'Please make sure Revit 2025 is installed.', mbError, MB_OK);
      Result := False;
    end;
  end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    MsgBox('Installation completed successfully!' + #13#10 + 
           'ONES.dll and ONES.addin have been copied to:' + #13#10 +
           ExpandConstant('{commonappdata}\Autodesk\Revit\Addins\2025'), 
           mbInformation, MB_OK);
  end;
end;

[UninstallDelete]
; Xóa các file khi gỡ cài đặt
Type: files; Name: "{commonappdata}\Autodesk\Revit\Addins\2025\ONES.dll"
Type: files; Name: "{commonappdata}\Autodesk\Revit\Addins\2025\ONES.addin"

[Messages]
english.WelcomeLabel2=This will install ONES Addin for Revit 2025.%n%nFiles will be copied to C:\ProgramData\Autodesk\Revit\Addins\2025
