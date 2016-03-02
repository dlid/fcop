# FCOP
### FTP Changes OK Please
Powershell script to deploy only modified files to a FTP server

FCop is a PowerShell module that will let you deploy only detected changes from a local file system to an FTP server.

  - Enumerate local files (filecache)
  - Compare to previously created filecache (if exists)
  - If any changes
    - Connect to FTP server
    - Determine needed commands (Create folder, upload file, delete file etc)
    - Present commands to user
    - If user chooses to deploy
      - Execute FTP command list
      - Save filecache

### Version
none

### Tech

Dillinger uses a number of open source projects to work properly:

* [X] - x

License
----

MIT

   [X]: <http://angularjs.org>
