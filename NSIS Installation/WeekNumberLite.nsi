!include "MUI2.nsh" ;Include Modern UI
!include nsDialogs.nsh
!include LogicLib.nsh

; Windows 11 and I presume also Windows 10 will insist on this installer containing a trojan which is bullshit, but I will not include installer for the Lite version
;--------------------------------
;General
Unicode True

!ifndef VERSION
  !define VERSION "1.0.0.0"
!endif

;LoadLanguageFile "${NSISDIR}\Contrib\Language files\English.nlf"
;LoadLanguageFile "${NSISDIR}\Contrib\Language files\Swedish.nlf"

!define PRODUCT_NAME "WeekNumber Lite"
!define PRODUCT_VERSION ${VERSION}
!define PRODUCT_GROUP "WeekNumber Lite"
!define PRODUCT_PUBLISHER "Voltura AB"
!define PRODUCT_WEB_SITE "https://voltura.github.io/WeekNumberLite"
!define PRODUCT_ID "{9572BF42-EA3E-42B4-975D-02FF5B1222D8}"

;Name and file
Name "WeekNumber Lite"
OutFile "WeekNumber_Lite_${VERSION}_Installer.exe"
BrandingText `${PRODUCT_NAME} Installer`
Caption "${PRODUCT_NAME} ${VERSION} Installer"
VIProductVersion ${VERSION}
VIAddVersionKey ProductName "${PRODUCT_NAME} Installer"
VIAddVersionKey Comments "An installer for ${PRODUCT_NAME}"
VIAddVersionKey CompanyName "${PRODUCT_PUBLISHER}"
VIAddVersionKey LegalCopyright "Copyright © ${PRODUCT_PUBLISHER} 2022"
VIAddVersionKey FileDescription "${PRODUCT_NAME} Installer"
VIAddVersionKey FileVersion ${VERSION}
VIAddVersionKey ProductVersion ${VERSION}
VIAddVersionKey InternalName "${PRODUCT_NAME} Installer"
VIAddVersionKey OriginalFilename "WeekNumber_Lite_${VERSION}_Installer.exe"
VIAddVersionKey PrivateBuild "${VERSION}"
VIAddVersionKey SpecialBuild "${VERSION}"
;Default installation folder
InstallDir "$LOCALAPPDATA\Voltura AB\WeekNumber Lite"
;Get installation folder from registry if available
InstallDirRegKey HKCU "Software\WeekNumber Lite" ""
;Request application privileges for Windows
RequestExecutionLevel user

;--------------------------------
;Variables
Var StartMenuFolder

;--------------------------------
;Interface Settings
;Show all languages, despite user's codepage
!define MUI_LANGDLL_ALLLANGUAGES
!define MUI_ABORTWARNING
!define MUI_ICON "..\Resources\weekicon.ico"
!define MUI_UNICON "..\Resources\weekicon.ico"
!define MUI_HEADERIMAGE_BITMAP "..\Resources\WeekNumberLite.bmp"
!define MUI_HEADERIMAGE_BITMAP_STRETCH AspectFitHeight
!define MUI_HEADERIMAGE_UNBITMAP "..\Resources\WeekNumberLite.bmp"
!define MUI_HEADERIMAGE_UNBITMAP_STRETCH AspectFitHeight
!define MUI_CUSTOMFUNCTION_GUIINIT onGUIInit

;--------------------------------
;Language Selection Dialog Settings
;Remember the installer language
!define MUI_LANGDLL_REGISTRY_ROOT "HKCU" 
!define MUI_LANGDLL_REGISTRY_KEY "Software\WeekNumber Lite" 
!define MUI_LANGDLL_REGISTRY_VALUENAME "Installer Language" 
 
;--------------------------------
;Pages
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "$(LICENSETXT)"
!insertmacro MUI_PAGE_DIRECTORY
!define MUI_STARTMENUPAGE_REGISTRY_ROOT "HKCU" 
!define MUI_STARTMENUPAGE_REGISTRY_KEY "Software\WeekNumber Lite" 
!define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "Start Menu Folder"
!insertmacro MUI_PAGE_STARTMENU Application $StartMenuFolder
!insertmacro MUI_PAGE_INSTFILES
!define MUI_FINISHPAGE_RUN "$INSTDIR\WeekNumberLite.exe"
!define MUI_FINISHPAGE_RUN_TEXT "$(RUNWeekNumberLite)" 
!insertmacro MUI_PAGE_FINISH
!insertmacro MUI_UNPAGE_WELCOME
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

;--------------------------------
;Languages
!insertmacro MUI_LANGUAGE "English" ; The first language is the default language
!insertmacro MUI_LANGUAGE "Swedish"

;Language strings
LicenseLangString LICENSETXT ${LANG_ENGLISH} "License.en-US.txt"

LicenseLangString LICENSETXT ${LANG_SWEDISH} "License.sv-SE.txt"

LangString RUNWeekNumberLite ${LANG_ENGLISH} "Run WeekNumber Lite"

LangString RUNWeekNumberLite ${LANG_SWEDISH} "Kör WeekNumber Lite"

LangString WeekNumberLiteIsRunning ${LANG_ENGLISH} "WeekNumber Lite is running, close it and run installer again."

LangString WeekNumberLiteIsRunning ${LANG_SWEDISH} "WeekNumber Lite startad, avsluta programmet installera igen."

LangString unWeekNumberLiteIsRunning ${LANG_ENGLISH} "WeekNumber Lite is running, close it and run uninstaller again."

LangString unWeekNumberLiteIsRunning ${LANG_SWEDISH} "WeekNumber Lite startad, avsluta programmet och avinstallera igen."

LangString ProductNameLanguageSpecific ${LANG_ENGLISH} "WeekNumber Lite by Voltura AB"

LangString ProductNameLanguageSpecific ${LANG_SWEDISH} "WeekNumber Lite av Voltura AB"

LangString StartWithWindows ${LANG_ENGLISH} "Start WeekNumber Lite with Windows"

LangString StartWithWindows ${LANG_SWEDISH} "Starta WeekNumber Lite med Windows"

LangString CheckIfWeekNumberLiteIsRunning ${LANG_ENGLISH} "Checking if WeekNumber Lite is running..."

LangString CheckIfWeekNumberLiteIsRunning ${LANG_SWEDISH} "Kontrollerar om WeekNumber Lite körs..."

LangString ConfigStartWithWindows ${LANG_ENGLISH} "Configuring WeekNumber Lite to start with Windows..."

LangString ConfigStartWithWindows ${LANG_SWEDISH} "Konfigurerar WeekNumber Lite att starta med Windows..."

LangString WeekNumberLiteRunningTryStop ${LANG_ENGLISH} "WeekNumber Lite is running, trying to stop it..."

LangString WeekNumberLiteRunningTryStop ${LANG_SWEDISH} "WeekNumber Lite körs, försöker stoppa..."

LangString WeekNumberLiteRunningAbortInstall ${LANG_ENGLISH} "Installation aborted - WeekNumber Lite is running"

LangString WeekNumberLiteRunningAbortInstall ${LANG_SWEDISH} "Installation avbruten - WeekNumber Lite körs"

LangString WeekNumberLiteRunningAbortUninstall ${LANG_ENGLISH} "Uninstall aborted - WeekNumber Lite is running"

LangString WeekNumberLiteRunningAbortUninstall ${LANG_SWEDISH} "Avinstallation avbruten - WeekNumber Lite körs"

LangString WeekNumberLiteRunningCloseBeforeInstall ${LANG_ENGLISH} "WeekNumber Lite is running. Please close before install."

LangString WeekNumberLiteRunningCloseBeforeInstall ${LANG_SWEDISH} "WeekNumber Lite körs. Vänligen stäng innan installation."

LangString WeekNumberLiteRunningCloseBeforeUninstall ${LANG_ENGLISH} "WeekNumber Lite is running. Please close before uninstall."

LangString WeekNumberLiteRunningCloseBeforeUninstall ${LANG_SWEDISH} "WeekNumber Lite körs. Vänligen stäng innan avinstallation."

LangString WeekNumberLiteNotRunning ${LANG_ENGLISH} "WeekNumber Lite is not running"

LangString WeekNumberLiteNotRunning ${LANG_SWEDISH} "WeekNumber Lite körs ej"

;--------------------------------
;Reserve Files
  !insertmacro MUI_RESERVEFILE_LANGDLL

;--------------------------------
;Installer Sections
Section "WeekNumberLite application" SecWeekNumberLite
  ;Uninstall old version
  ExecWait '"$INSTDIR\Uninstall WeekNumberLite.exe" /S _?=$INSTDIR'
  SetOutPath "$INSTDIR"
  File "..\bin\x64\Release\WeekNumberLite.exe"
  File "..\bin\x64\Release\WeekNumberLite.exe"
  SetOutPath "$INSTDIR\\sv-SE"
  SetOverwrite try
  File "..\bin\x86\Release\sv-SE\WeekNumberLite.resources.dll"
  SetOutPath "$INSTDIR\\en-US"
  File "..\bin\x86\Release\en-US\WeekNumberLite.resources.dll"
  ;Store installation folder
  WriteRegStr HKCU "Software\WeekNumber Lite" "" $INSTDIR
  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall WeekNumberLite.exe"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "DisplayName" "WeekNumber Lite by Voltura AB"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "UninstallString" "$\"$INSTDIR\Uninstall WeekNumberLite.exe$\""
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "QuietUninstallString" "$\"$INSTDIR\Uninstall WeekNumberLite.exe$\" /S"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "InstallLocation" "$\"$INSTDIR$\""
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "Publisher" "Voltura AB"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "Readme" "https://voltura.github.io/WeekNumberLite"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "URLUpdateInfo" "https://github.com/voltura/WeekNumberLite/releases/latest/download/VERSION.TXT"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "URLInfoAbout" "https://voltura.github.io/WeekNumberLite"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "HelpLink" "https://voltura.github.io/WeekNumberLite"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "DisplayVersion" "${VERSION}"
  WriteRegDWORD HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "NoModify" "1"
  WriteRegDWORD HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "NoRepair" "1"
  WriteRegDWORD HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "EstimatedSize" "512"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "Comments" "System tray app - shows current week number"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite" "DisplayIcon" "$\"$INSTDIR\WeekNumberLite.exe$\""
  
  !insertmacro MUI_STARTMENU_WRITE_BEGIN Application
    ;Create shortcuts
    CreateDirectory "$SMPROGRAMS\$StartMenuFolder"
    CreateShortcut "$SMPROGRAMS\$StartMenuFolder\WeekNumberLite.lnk" "$INSTDIR\WeekNumberLite.exe"
    CreateShortcut "$SMPROGRAMS\$StartMenuFolder\Uninstall WeekNumberLite.lnk" "$INSTDIR\Uninstall WeekNumberLite.exe"
  !insertmacro MUI_STARTMENU_WRITE_END
SectionEnd

;--------------------------------
;Uninstaller Section
Section "Uninstall"
  Delete "$INSTDIR\WeekNumberLite.exe"
  Delete "$INSTDIR\sv-SE\WeekNumberLite.resources.dll"
  Delete "$INSTDIR\en-US\WeekNumberLite.resources.dll"
  Delete "$INSTDIR\Uninstall WeekNumberLite.exe"
  
  ;do not remove install folder if silent uninstall (normally happens during auto-update), 
  ;we want to keep log file
  IfSilent +2
  RMDir "$INSTDIR"
  
  RMDir "$INSTDIR\sv-SE"
  RMDir "$INSTDIR\en-US"

  !insertmacro MUI_STARTMENU_GETFOLDER Application $StartMenuFolder
  Delete "$SMPROGRAMS\$StartMenuFolder\WeekNumberLite.lnk"
  Delete "$SMPROGRAMS\$StartMenuFolder\Uninstall WeekNumberLite.lnk"
  RMDir "$SMPROGRAMS\$StartMenuFolder"

  ;do not remove local appdata folder if silent uninstall (normally happens during auto-update), 
  ;we want to keep log file
  IfSilent +2
  RMDir "$LOCALAPPDATA\Voltura AB\WeekNumber Lite"

  DeleteRegKey HKCU "Software\WeekNumber Lite"
  DeleteRegKey HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\WeekNumber Lite"
  
SectionEnd

;--------------------------------
; Functions

Function onGUIInit
FunctionEnd

Function .onInstSuccess
  IfSilent 0 +2
  Exec '"$INSTDIR\WeekNumberLite.exe"'

FunctionEnd
