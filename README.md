# FCOP
### FTP Changes OK Please
Powershell script to deploy only modified files to a FTP server

FCop is a PowerShell module that will let you deploy only detected changes from a local file system to an FTP server.

- First deploy a local cache file will store information of deployed files.
- Following deploys will use the local cache file and compare it to the filesystem to determine which files to deploy anew.

See Wiki for details.

### Version
1.0 - First working version

### Tech

* [edtFTPnet/Free] -  the popular free .NET FTP library

License
----

MIT

   [edtFTPnet/Free]: <http://enterprisedt.com/products/edtftpnet/>
