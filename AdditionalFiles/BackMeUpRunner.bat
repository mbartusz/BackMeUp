START "" "fullPath/processToLookFor.exe"

timeout /t 30 /nobreak > NUL

START ""  "fullPath\BackMeUp.exe" -i "C:\CopyFrom" -o "C:\CopyTo" -p "Slack" -t 5