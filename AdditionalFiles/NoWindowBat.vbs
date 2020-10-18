Set oShell = CreateObject ("Wscript.Shell")
Dim strArgs
strArgs = "cmd /c BackMeUpRunner.bat"
oShell.Run strArgs, 0, false