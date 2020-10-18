# BackMeUp - Description
This is a simple .NET Core Windows Desktop headless app allowing user to backup directory with its  
subdirectories in a specified destination path each x seconds, when a specific process is running.  
When a specified process name is not detected, application quits.

# BackMeUp - How it works
At launch app checks if a specified process is running.  
If yes an initial backup is created and every x seconds another backup appears in the destination folder.  
When process is killed, app will quit.

Available arguments to be passed:
```
-i, --input - (Required) Input full path directory
-o, --output - (Required) Output full path directory
-p, --processName - (Required) Process name to look for
-t, --timePeriod - (Required) Copy period in seconds
```

Example:  
```
START ""  "fullPath\BackMeUp.exe" -i "C:\bin\CopyFrom" -o "C:\bin\CopyTo" -p "Slack" -t 5
```

Note:  
Make sure to distinct initial and destination directory as copied data will exponentially grow.

# BackMeUp - Additional files  
There are 2 files available in *AdditionalFiles* folder.  
*.vbs file launches *.bat file in headless (no console window) mode.  
*.bat file launches a specified process, waits 30 seconds and launches *BackMeUp*.  
As BackMeUp is not a console app and no forms are available it will run also in a headless mode. 

# BackMeUp - Testing  
There is a mocked process included in *TestArtifacts* folder.  
During launch, test creates a Process instance, which itself is running for 10 seconds.  
At that time files are being backed up in the destination folder.  
After an assertion is made, output folders and files are deleted.