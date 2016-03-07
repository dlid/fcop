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

The core function will compare the local filesystem with the filecache XML data. This operation will be very fast and based on detected changes the FTP commands needed for a deploy will be resolved.

### Version
1.0 - First working version

### Tech

* [edtFTPnet/Free] -  the popular free .NET FTP library

License
----

MIT

   [edtFTPnet/Free]: <http://enterprisedt.com/products/edtftpnet/>
