# Synker
<img src="https://www.ucpsystems.com/version/synker/synker_logo.png" width="100" height="100">
If you are an owner or have access to an FTP server, Synker provides a free alternative to cloud data storage as you see with Dropbox™ or OneDrive™. Why should you pay for something you already own? Even if you do not own an FTP server, some server providers are way more affordable than commercial solutions and Synker is the missing puzzle piece! Just connect Synker with the FTP and your files will automatically get uploaded and stored for later recall on another device. It also can be used to create regular backups of your work, without you doing anything.

## How to use
### The Setup dialog
The first time _Synker.exe_ starts, a setup dialog will be shown. The setup creates folders and the config file as well as, the desktop icon(optional) and a windows explorer pinned folder (optional). By default, the working directory will be located at _C:/Users/{USERNAME}/_ but this can be changed with the setup dialog. The working directory, the folder where all files will be stored, can only be set at setup and cannot be changed afterward. The setup contains an option to add the working directory to the navigation panel in the windows explorer which is useful to gain quicker access to your files. The desktop shortcut will be created as an absolute link which means if the .exe moves, the shortcut will no longer work. If you want to reopen the setup dialog after finishing the setup, delete or rename the _config.ucf_ and restart the application. 
 
### Establishing a connection
After finishing the setup, the connection window will open in the right bottom corner of the screen. This window closes automatically if the focus is lost, but it can be opened by right-clicking the _Synker_ icon in the taskbar and clicking the element “Synker”. This window manages the FTP connection and this is where to log in. _Synker_ will create two folders named “Synker” and “SynkerBackup” on the FTP server in the FTP user's root folder. Therefore it is suggested to create a new user just for _Synker_, at the correct path where all files should be placed. The folder “Synker” contains the mirror of the local files (always represents the latest version) and “SynkerBackup” stores the backup files (It is strongly advised against the manipulation of files on the FTP  which might result in data loss). If the login is successful a green check symbol should appear next to the “connect button”.

### The Menu
The menu can be opened by right-clicking the _Synker_ icon in the bottom right corner of the taskbar. 
1. “Synker” – Opens the connection menu.
2. “Create new Backup” – Creates a new backup of the local files.
3. “Backup” – Lists all available backups which can be pulled(downloaded) or deleted.
4. “Force Push” – Pushes(uploads) all local files to the server. 
5. “Force Pull” – Pulls(downloads) all server files on the local machine.
6. “Quit” – Closes the application.

## Config
The _config.ucf_ file is contained in the same directory as the executable. The config should be used to finetune the software to the server in use. The config files settings:
| Variable      | Type   | Default | Description |
|---------------|--------|---------|-------------|
| path          | string | -       | Path to the working directory. DO NOT CHANGE! |
| retrydelay    | int    | 500     | Delay in ms before a new download/upload is started.|
| retries       | int    | 3       | How many times a download/upload is retried before giving up.|
| showlog       | bool   | true    | If true, log is shown. |
| askforconsent | bool   | true    | If true, consent is asked before every operation except creating a backup.|




#### Disclaimer of Warranty
SOFTWARE IS PROVIDED UNDER THIS LICENSE ON AN "AS IS" BASIS, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING, WITHOUT LIMITATION, WARRANTIES THAT THE COVERED SOFTWARE IS FREE OF DEFECTS, MERCHANTABLE, FIT FOR A PARTICULAR PURPOSE OR NON-INFRINGING. 
For more information please visit: https://www.ucpsystems.com/?site=termsofservice

