# PRISM4 Default Schema --- Lambda Systems Inc.
Title "Default"
#CommonScenePath ""
ScenePath ""
ImagePath "..\\Image"
DataPath  "..\\Data"
TexturePath	"D:\\Lambda\\Texture"
LogoPath "D:\\Lambda\\Bin.V2\\Logo"
ThumbNailPath ""
OADevice	"GRID-EX32HD"
SceneIO		"Lambda.SioLocal.SceneIO"
# UseSceneFontCache
UseDevice Lambda.PcSound.Player { At Break Stop() }

Source "“s“¹•{Œ§" {
  Csv { , Comment "#" }
  SysVar {}
  Struct {
	Column "id" { L Ascent }
	Column "name" { S 256 }
	Column "X" { L }
	Column "Y" { L }
	Column "file name" { S 32 }
  }
}
Source "corona" {
  Csv { , Comment "#" }
  SysVar {}
  Struct {
	Column "“ú•t" { S 32 Descent }
	Column "‘S‘" { L }
	Column "–kŠC“¹" { L }
	Column "ÂX" { L }
	Column "Šâè" { L }
	Column "‹{é" { L }
	Column "H“c" { L }
	Column "RŒ`" { L }
	Column "•Ÿ“‡" { L }
	Column "ˆïé" { L }
	Column "“È–Ø" { L }
	Column "ŒQ”n" { L }
	Column "é‹Ê" { L }
	Column "ç—t" { L }
	Column "“Œ‹" { L }
	Column "_“Şì" { L }
	Column "VŠƒ" { L }
	Column "•xR" { L }
	Column "Îì" { L }
	Column "•Ÿˆä" { L }
	Column "R—œ" { L }
	Column "’·–ì" { L }
	Column "Šò•Œ" { L }
	Column "Ã‰ª" { L }
	Column "ˆ¤’m" { L }
	Column "Od" { L }
	Column " ‰ê" { L }
	Column "‹“s" { L }
	Column "‘åã" { L }
	Column "•ºŒÉ" { L }
	Column "“Ş—Ç" { L }
	Column "˜a‰ÌR" { L }
	Column "’¹æ" { L }
	Column "“‡ª" { L }
	Column "‰ªR" { L }
	Column "L“‡" { L }
	Column "RŒû" { L }
	Column "“¿“‡" { L }
	Column "ì" { L }
	Column "ˆ¤•Q" { L }
	Column "‚’m" { L }
	Column "•Ÿ‰ª" { L }
	Column "²‰ê" { L }
	Column "’·è" { L }
	Column "ŒF–{" { L }
	Column "‘å•ª" { L }
	Column "‹{è" { L }
	Column "­™“‡" { L }
	Column "‰«“ê" { L }
  }
}


Source "“V‹Cî•ñ" {
  Csv { , Comment "#" }
  SysVar {}
  Struct {
	Column "’n“_" { S 32 Descent }
	Column "Å‚‹C‰·" { L }
	Column "Å’á‹C‰·" { L }
	Column "“ú~…—Ê" { L }
	Column "Å‘å•—‘¬" { L }
  }
}
DataTable "ƒRƒƒi‚Ìî•ñ" { "corona" "V‹K—z«Ò”.csv" }
DataTable "“s“¹•{Œ§î•ñ" { "“s“¹•{Œ§" "“s“¹•{Œ§.csv" }
DataTable "“V‹Cî•ñ" { "“V‹Cî•ñ" "weather.csv" }