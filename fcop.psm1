$path = Split-Path $script:MyInvocation.MyCommand.Path
[Reflection.Assembly]::LoadFile($path + "\bin\edtFTPnet.dll")


function Install-Fcop {
    param (
        [Parameter(Mandatory=$true)]
        [string]$Config
    )

    $global:taskdepth = 0
    $global:fcop = @{
        Commands = @()
    }


    Write-Host "*"
    Write-Host "* FTP Changes OK Please"
    Write-Host "* Copyight (C) 2016 David Lidström"
    Write-Host "*"
    Write-Host "*"

    $c = Initialize-FCopConfig -Config $Config
    
    New-FCopFilecache -Cfg $c
    
     Resolve-FCopChanges -Cfg $c

    # Connect to the FTP and see if we need to create folders and stuff
    Resolve-FcopFTPChanges -Cfg $c

     $commands = $c.fcop._runtime.Commands.Command
    [void]$c.Save($c.fcop._runtime.ResolvedRuntimeFilePath)

    if ($commands) {
        if ($commands.GetType().Name -eq "XmlElement") {
            $commands = @($commands)
        }

        Write-Host ""
        Write-Host ""
        Write-Host ($commands.Length.ToString() + " FTP Commands need to be executed")
        $uploads = $commands | where {$_.Type -eq "UPLOAD"}
        if ($uploads -and $uploads.Length) {
            Write-Host ($uploads.Length.ToString() + " file uploads")
        }
        $dirs = $commands | where {$_.Type -eq "MKD"}
        if ($dirs -and $dirs.Length) {
            Write-Host ($dirs.Length.ToString() + " folders to be created")
        }
        Write-Host ""
        Write-Host "  Choose an action   " -ForegroundColor Yellow -BackgroundColor Black
        Write-Host ""

        Write-Host "Action: [" -NoNewline
        Write-Host "D" -ForegroundColor Yellow -NoNewline
        Write-Host "]eploy / [S]ave updated filecache / [V]iew commands"
    
        $key = [Console]::ReadKey($true)
    
        Write-Host ("You choose " + $key.key) -ForegroundColor Cyan

    } else {
        Write-Host "No changes"
        $key = "_"
    }

   

    # Here, the FTP connection has been closed. We'll need to open it again later
#    foreach(

if ($key -eq "D") {
    $ftp = Connect-FCopFtp -Cfg $c

    $a = 0

    
     #[void]$c.Save("C:\git\CogFramework\Deploy\runtime.xml");
    
    $n = 0
    $taskName = ("Executing " + $c.fcop._runtime.Commands.Command.Length + " commands")
    $t = Start-FCopTask "Executing FTP commands"
    foreach($Command in $c.fcop._runtime.Commands.Command ) {
        
        if ($n -gt 0) {
            $a = ([math]::round( $n / $c.fcop._runtime.Commands.Command.Length, 2 ) * 100)
        }
        if ($command.Type -eq "MKD") {
            if (-not $ftp.DirectoryExists($Command.Target)) {
                Write-Progress -Activity $taskName -PercentComplete $a -CurrentOperation "$a% complete" ` -Status ("Creating remote directory " + $Command.Target)
                $ftp.CreateDirectory($Command.Target)
            }
        } elseif ($command.Type -eq "UPLOAD") {
                Write-Progress -Activity $taskName -PercentComplete $a -CurrentOperation "$a% complete" ` -Status ("Uploading file " + (Split-Path $Command.Source -Leaf))
            $target = $Command.Target
            $target += "/" + (Split-Path $Command.Source -Leaf)

            $ftp.UploadFile($Command.Source, $target)
        }
        $n++

    }

    $ftp.Close()




    Complete-FCopTask $t

    
    $t = Start-FCopTask ("Saving updated filecache" + $filecache_path)
    $filecache = [xml]"<?xml version='1.0' encoding='utf-8'?>"
    $filecache.AppendChild( $filecache.ImportNode($c.fcop._runtime.filecache, $true) ) 
    $filecache.Save($c.fcop._runtime.ResolvedFilecachePath)
    Complete-FCopTask $t

    }


   
    
    

}

#
# Setup the runtine configuration XML that is used in the session
# 
function Initialize-FCopConfig {
    param(
    [Parameter(Mandatory=$true)]
    [string]$Config)

    $resolvedPath = Resolve-path $Config
    Write-Host $resolvedPath -ForegroundColor Yellow
    $cc = Get-Content $resolvedPath
    if (-not $cc) {
        throw "Config content was empty"
    }

    [xml]$xmlCfg = $cc

    $sourceFolder = ($xmlCfg.fcop.Source | where { $_.Type -eq "File" }).InnerText
    $target = ($xmlCfg.fcop.Target | where { $_.Type -eq "FTP" })
    $targetFolder = $target.Path
   
     Write-Host $targetFolder -ForegroundColor Cyan

    if (-not $targetFolder.EndsWith("/")) {
        $targetFolder += "/"
    }


    Write-Host -ForegroundColor Cyan $sourceFolder
    if ($sourceFolder) {
        $sourceFolder = Resolve-Path $sourceFolder
    }


 
    $runtimeElement = $xmlCfg.CreateElement("_runtime")
    [void]$xmlCfg.DocumentElement.AppendChild($runtimeElement)

    $elm1 = $xmlCfg.CreateElement("ResolvedSourceFolder")
    [void]$elm1.AppendChild( $xmlCfg.CreateTextNode($sourceFolder))
    [void]$runtimeElement.AppendChild( $elm1 )

    $elm2 = $xmlCfg.CreateElement("ResolvedTargetFolder")
    [void]$elm2.AppendChild( $xmlCfg.CreateTextNode($targetFolder))
    [void]$runtimeElement.AppendChild( $elm2 )

    $elm = $xmlCfg.CreateElement("ResolvedConfigurationFilePath")
    [void]$elm.AppendChild( $xmlCfg.CreateTextNode($resolvedPath))
    [void]$runtimeElement.AppendChild( $elm )


    $configfolder = (Split-Path $resolvedPath -Parent)
    $filename = [io.path]::GetFileNameWithoutExtension($resolvedPath)
    $filecache_path = (Join-Path $configfolder ($filename  + ".fcopcache"))
    $runtime_path = (Join-Path $configfolder ($filename  + ".runtime.xml"))

    $elm = $xmlCfg.CreateElement("ResolvedFilecachePath")
    [void]$elm.AppendChild( $xmlCfg.CreateTextNode($filecache_path))
    [void]$runtimeElement.AppendChild( $elm )

    $elm = $xmlCfg.CreateElement("ResolvedRuntimeFilePath")
    [void]$elm.AppendChild( $xmlCfg.CreateTextNode($runtime_path))
    [void]$runtimeElement.AppendChild( $elm )

    $target = ($fcogcfg.fcop.Source | where { $_.Type -eq "FTP" })
    $targetFolder = $target.Path

    Set-Variable -Name "FcopCfg" -Scope Global -Value $xmlCfg


    $d = get-content $filecache_path -ErrorAction SilentlyContinue
    if ($d) {
        $cached = [xml]$d
        $cachedNode = $xmlCfg.CreateElement("cached")
        [void]$cachedNode.AppendChild($xmlCfg.ImportNode( $cached.DocumentElement, $true ))
        [void]$xmlCfg.fcop._runtime.AppendChild($cachedNode)
    }

    #Write-Host "Oh, got cached content" -ForegroundColor Yellow -BackgroundColor Black
    #Write-Host $d
   
    #   Read-Host "wait for it"

    return [System.Xml.XmlDocument]$xmlCfg
}

#
# 
#
function Resolve-FCopFTPChanges {
    param(
    [Parameter(Mandatory=$true)]
    [System.Xml.XmlDocument]$Cfg
    )

    $fnTask = Start-FCopTask "Checking changes for FTP server"
    $ftp = Connect-FCopFtp -Cfg $Cfg

    # Get all target directories
    $cmds = $Cfg.fcop._runtime.Commands.Command | where {$_.Type -eq "UPLOAD"}

    $uniqueTargetFolders = @($Cfg.fcop.Target.Path)

    $f = Start-FCopTask "Enumerating all folders"
    foreach($cmd in $cmds) {
        if (-not $uniqueTargetFolders.Contains($cmd.Target)) {
            $d = $cmd.Target.Split("/")
            #Write-host $cmd.Target -ForegroundColor Cyan
            for($i =0; $i -lt $d.Length; $i++) {
                $sofar = $d[0..$i]
                $path = $sofar -join("/")
              #  Write-Host $path
              #  Read-Host "..."
                if (-not $uniqueTargetFolders.Contains($path)) {
                    $uniqueTargetFolders += $path
                }
            }
        }
    }
    Complete-FCopTask $f

    $uniqueTargetFolders = $uniqueTargetFolders | Sort-Object

    Write-FCopInfo ($uniqueTargetFolders.Count.ToString() + " unique folders should be checked on FTP server")
    $mdirs = @()
   
    $f = Start-FCopTask "Checking existing folders on FTP server"
    do {
        foreach($folder in $uniqueTargetFolders ) {
            if (-not $ftp.DirectoryExists($folder)) {
                $others = $uniqueTargetFolders | where { $_.StartsWith($folder) }
                Write-FCopInfo ("MKD '" + $folder + "' (" + $others.Length + " subfolders)") 
                $mdirs+=$others
                $x = $uniqueTargetFolders | where { -not $_.StartsWith($folder) }
                $uniqueTargetFolders = $x
                break
            } else {
#                Write-FCopInfo ("Folder exists '" + $folder + "'") 
                $x = $uniqueTargetFolders | where { $_ -ne $folder }
                $uniqueTargetFolders = $x 
                break
            }
        }

    } while ($uniqueTargetFolders.Length -gt 0)
    Write-FCopInfo ("Found " + $mdirs.Length.ToString() + " folders that do not exist")
    Complete-FCopTask $f

    $mdirs = $mdirs | Sort-Object

    $allFoldersNode = $Cfg.CreateElement("AllFolders")
    [void]$Cfg.fcop._runtime.AppendChild($allFoldersNode)

     $f = Start-FCopTask "Adding MKD commands"
    foreach($folderToCreate in $mdirs){

       $n = $Cfg.CreateElement("Makedir")
       [void]$n.AppendChild( $Cfg.CreateTextNode($folderToCreate) )
       [void]$allFoldersNode.AppendChild($n)

        # Find the first UPLOAD command for this folder
        $x = $Cfg.fcop._runtime.Commands.Command | where { $_.Type -eq "UPLOAD" -and ($_.Target.StartsWith($folderToCreate))}
        if ($x -ne $null -and $x.GetType().Name -eq "Object[]") {
            $x = $x[0]
        } elseif ( $x.GetType().Name -ne "XmlElement") {
            $x = $null
        }

        if ($x) {
             $e = $Cfg.CreateElement("Command")
             [void]$e.SetAttribute("Type", "MKD")
             [void]$e.SetAttribute("Target", $folderToCreate)
             [void]$x.ParentNode.InsertBefore($e, $x)
        } else {       
            Write-FCopInfo ("No CMD '" +  $folderToCreate + "'") 
        }
    }
    Write-FCopInfo ("New Command Count: " + $Cfg.fcop._runtime.Commands.Command.Length)
    Complete-FCopTask $f

    if ($ftp) {
        Write-FCopInfo "Closing FTP Connection"
        $ftp.Close()
    }

    Complete-FCopTask  $fnTask

}

function Get-FCopFTPPassword {
    param(
    [Parameter(Mandatory=$true)]
    [System.Xml.XmlDocument]$Cfg,
    [switch]$Force
    )
    $password = $null
    $ConfigHash = ($Cfg.fcop._runtime.ResolvedConfigurationFilePath).GetHashCode().ToString() + ";" + $Cfg.fcop.Target.Username.GetHashCode().ToString()

    
    if (-not $Force) {
    
        $regitem = Get-ItemProperty -Path "HKCU:\Software\dlid.se\fcop" -ErrorAction SilentlyContinue
        if ($regitem) {
            $SecurePassword = $regitem.$ConfigHash
            if ($SecurePassword) {
               # Write-Host "Found secure password "$SecurePassword
                $password = $SecurePassword | ConvertTo-SecureString
               # Write-Host $password.GetType()
            }
        }
    }

    if (-not $password ) {
        #    $SecurePassword = (Get-ItemProperty -Path "HKCU:\Software\dlid.se\fcop").$ConfigHash | ConvertTo-SecureString
        #Write-Output "" -ForegroundColor Yellow
        #Write-Output "FTP Password not found for config file" -ForegroundColor Yellow
        #Write-Output "====================" -ForegroundColor Yellow
        #Write-Output
        #Write-Output "Password will be stored encrypted using your Windows Account in the System Registry" -ForegroundColor Gray
        #Write-Output
        $password = Read-Host ("Enter FTP Password (" + $Cfg.fcop.Target.Username + "@" + $Cfg.fcop.Target.Host +")") -AsSecureString 
        if ($password) {
            $secureStringPasswordText = $password | ConvertFrom-SecureString
            New-Item -Path "HKCU:\Software\dlid.se" -ErrorAction SilentlyContinue
            New-Item -Path "HKCU:\Software\dlid.se\fcop" -ErrorAction SilentlyContinue
            New-ItemProperty -Path "HKCU:\Software\dlid.se\fcop" -Name $ConfigHash -Value $secureStringPasswordText -Force
         #   Write-Output $password
         #   Write-Output $secureStringPasswordText | ConvertTo-SecureString
            

        } else {
            throw "No password provided. Exiting."
        }
    } else {
       # Write-FCopInfo ("Vi har password?" + $password)
    }

    $user = "DUMMY\user"
   # Write-Host ("usertype " + $user.GetType()) -ForegroundColor Red
    #Write-Host ("pwdtype " + $password.getType()) -ForegroundColor Red
    try {
        $Credentials = New-Object System.Management.Automation.PSCredential -ArgumentList $user, $password
    } catch {
        Write-Host "* " -ForegroundColor red -BackgroundColor Black
        Write-Host "* Error reading password" -ForegroundColor red -BackgroundColor Black
        Write-Host "* " -ForegroundColor red -BackgroundColor Black
        throw
    }
    return $Credentials.GetNetworkCredential().Password

}

function Connect-FCopFtp {
    param(
    [Parameter(Mandatory=$true)]
    [System.Xml.XmlDocument]$Cfg
    )

    # Password is preferably not saved in the config file
    # Attempt to get it

    [EnterpriseDT.Net.Ftp.FTPConnection]$ftp = New-Object EnterpriseDT.Net.Ftp.FTPConnection

    $ftpConnected = $true
    $password = Get-FCopFTPPassword -Cfg $Cfg
    do {
        $ftpConnected = $true
        $ftp.ServerAddress = $Cfg.fcop.Target.Host
        $ftp.UserName = $Cfg.fcop.Target.Username

        if ($password.GetType().Name -eq "Object[]" -and $password.Length -gt 0) {
            $password = $password[$password.Length-1]
        }

        if ($password.GetType().Name -ne "String") {
            throw ("Password is of wrong type. Expected String, found " + $password.GetType().Name)
        }

        $ftp.Password = $password
        Write-FCopInfo ("Username " + $ftp.UserName)
        Write-FCopInfo ("Pass " + $password.GetType())
        Write-FCopInfo ("Host" + $ftp.ServerAddress)
        Write-FCopInfo ("Port" + $ftp.ServerPort)

        try {
            $t = Start-FCopTask "Connecting to FTP Server"
            $ftp.Connect()
            Complete-FCopTask $t
            return $ftp
        } catch {
            try { $ftp.Close() } catch {}  
            $Message = $_.Exception.Message
            $ftpConnected = $false
            Write-FCopInfo $Message
            Stop-FCopTask $t

            if ($Message.ToLower().Contains("(code=530)")) {
                # Authentication failed
                $password = Get-FCopFTPPassword -Cfg $Cfg -Force
            } else {
                Write-Host "*" -ForegroundColor Red -BackgroundColor Black
                Write-Host "* Connection to FTP server failed" -ForegroundColor Red -BackgroundColor Black
                Write-Host "*" -ForegroundColor Red -BackgroundColor Black
                throw
            }
        }

    } while (-not $ftpConnected)
    return $null
}


function New-FCopUploadCommandElement {
     param(
    [Parameter(Mandatory=$true)]
    [System.Xml.XmlDocument]$Cfg,
    [Parameter(Mandatory=$true)]
    [object]$file,
    [Parameter(Mandatory=$true)]
    [object]$folder,
    [Parameter(Mandatory=$true)]
    [string]$reason,
    [Parameter(Mandatory=$true)]
    [ValidateSet('UPLOAD','DELETE')]
    [string]$type
    )
    
    $i = $file.SourcePath.LastIndexOf("\")
    $SourceFolderPathOnly = $file.SourcePath.Substring(0, $i)
    $folderTargetPath = $folder["fcop://TargetPath"]

    $cmdNode = $Cfg.CreateElement("Command")
    $cmdNode.SetAttribute("Type", $type)
    $cmdNode.SetAttribute("Source", (Join-Path (Join-Path $Cfg.fcop._runtime.ResolvedSourceFolder $folder.SourcePath) $file.SourcePath)   )
                 
    $finalTargetFolder = $Cfg.fcop._runtime.ResolvedTargetFolder 
    if ($SourceFolderPathOnly) {
     $finalTargetFolder = Join-Path $finalTargetFolder (Join-Path $folderTargetPath $SourceFolderPathOnly)
    } else {
     $finalTargetFolder = Join-Path $finalTargetFolder $folderTargetPath
    }

    $finalTargetFolder = $finalTargetFolder.Replace("\", "/")

    $cmdNode.SetAttribute("Target", $finalTargetFolder)
    $cmdNode.SetAttribute("Reason", $reason)
    return $cmdNode
}

function Convert-FCopFilecacheXmlToHashtable {
    param(
    [Parameter(Mandatory=$true)]
    [System.Xml.XmlNode]$filecache
    )

 #   $fnTask = Start-FCopTask "Converting XML to objects"
    $folderHashtable = @{}
    foreach($folder in $filecache.ChildNodes) {
        $filesHashtable = @{
            "fcop://TargetPath" = $folder.TargetPath
        }
        foreach($file in $folder.ChildNodes) {

            $fileItem = @{
                Bytes = $file.Bytes;
                Hash = $file.Hash;
                SourcePath = $file.SourcePath
            }    
            $filesHashtable.Add($file.SourcePath, $fileItem)
        }
        $folderHashtable.Add($folder.SourcePath, $filesHashtable)
    }
#    Complete-FCopTask $fnTask
    return $folderHashtable

}

function Resolve-FCopChanges {
    param(
    [Parameter(Mandatory=$true)]
    [System.Xml.XmlDocument]$Cfg
    )

    $fnTask = Start-FCopTask "Resolving changes"

    $cached = $Cfg.fcop._runtime.cached.filecache

    if (-not $cached) {
        Write-FCopInfo "Ok, no previous cache. Create empty element then"
        $cached = $Cfg.CreateElement("cached")
        [void]$Cfg.fcop._runtime.appendChild($cached)
    } 
    $commands = $Cfg.CreateElement("Commands")

    $addCommands = @()
    
    $folders = Convert-FCopFilecacheXmlToHashtable -filecache $Cfg.fcop._runtime.filecache
    if ($cached) {
        $cached = Convert-FCopFilecacheXmlToHashtable -filecache $cached
    }

  
    foreach($folderPath in $folders.Keys) {
        $folder = $folders[$folderPath]
        Write-Host -ForegroundColor Yellow -BackgroundColor black $folderPath

        if ($cached.ContainsKey($folderPath)) {
            $f2 = Start-FCopTask ("Checking changed and new files " +$folderPath)
            $cachedFolder = $cached[$folderPath]

            foreach($filePath in $folders[$folderPath].Keys) {
                $file = $folders[$folderPath][$filePath]
                if ($cachedFolder.ContainsKey($filePath)) {
                    $cachedFile = $cachedFolder[$filePath]
                    if ($cachedFile.Hash -ne $file.Hash) {
                        $cmdNode = New-FCopUploadCommandElement -Cfg $Cfg -file $file -folder $folder -reason "Changed" -type UPLOAD
                        [void]$commands.appendChild($cmdNode)
                    }
                } else {
                    $cmdNode = New-FCopUploadCommandElement -Cfg $Cfg -file $file -folder $folder -reason "New" -type UPLOAD
                    [void]$commands.appendChild($cmdNode)
                }
            }
            
            foreach($filePath in $cachedFolder.keys) {
               $existingfile = $folder.ContainsKey($filePath)
               if (-not -$existingfile) {
               Write-Host "DOES NOT EXIST"$filePath -ForegroundColor Red
                    $cmdNode = New-FCopUploadCommandElement -Cfg $Cfg -file $file -folder $folder -reason "Deleted" -type "DELETE"
                    [void]$commands.appendChild($cmdNode)
               }
            }

           # Write-Host ("Found in cache /w " + $folders[$folderPath].Length + " keys")
            Complete-FCopTask $f2
        } else {
            $cmdNode = New-FCopUploadCommandElement -Cfg $Cfg -file $file -folder $folder -reason "New" -type UPLOAD
            [void]$commands.appendChild($cmdNode)
        }

    }


    if (1 -eq 2) {
        foreach($folder in $Cfg.fcop._runtime.filecache.ChildNodes) {
        $cachedFolder = $cached.folder | where { $_.SourcePath -eq $folder.SourcePath } 
        if (-not $cachedFolder) {
            foreach($file in $folder.ChildNodes) {
                $cmdNode = New-FCopUploadCommandElement -Cfg $Cfg -file $file -folder $folder -reason "New" -type "UPLOAD"
                [void]$commands.appendChild($cmdNode)
            }
        } else {

            # Go through all local files and see if any hash has changed
            $f2 = Start-FCopTask ("Checking changed and new files " +$folder.SourcePath)
            foreach($file in $folder.ChildNodes) {
                $sourcepath = $file.SourcePath
               # $f2 = Start-FCopTask "ps style"
                $cachedFile = $cachedFolder.file | where { $_.SourcePath -eq $sourcepath } | select -First 1
               # Complete-FCopTask $f2

                #$f2 = Start-FCopTask "selectnodes style"
                #$cachedFile = $cachedFolder.SelectSingleNode("file[@SourcePath='" + $sourcepath + "']")
               # Complete-FCopTask $f2


                if ($cachedFile) {
                    if ($file.Hash -ne $cachedFile.Hash) {
                        $cmdNode = New-FCopUploadCommandElement -Cfg $Cfg -file $file -folder $folder -reason "Changed" -type "UPLOAD"
                   #     [void]$commands.appendChild($cmdNode)
                        $addCommands+=$cmdNode
                    }
                } else {
                    $cmdNode = New-FCopUploadCommandElement -Cfg $Cfg -file $file -folder $folder -reason "New" -type "UPLOAD"
                        $addCommands+=$cmdNode
                  #  [void]$commands.appendChild($cmdNode)
                }
            }
            Complete-FCopTask $f2

           # $f2 = Start-FCopTask "Checking deleted files"
            foreach($file in $cachedFolder.ChildNodes) {
                $sourcepath = $file.SourcePath
                $existingfile = $folder.file | where { $_.SourcePath -eq $sourcepath }| select -First 1
                if (-not $existingfile) {
                    $cmdNode = New-FCopUploadCommandElement -Cfg $Cfg -file $file -folder $folder -reason "Deleted" -type "DELETE"
                    $addCommands+=$cmdNode
                   # [void]$commands.appendChild($cmdNode)
                }
            }
           # Complete-FCopTask $f2

        }
    }
    }
    # $f2 = Start-FCopTask "Adding to XML"
    #foreach($cmd in $addCommands) {
    #    $commands.AppendChild($cmd)
   # }
    # Complete-FCopTask $f2

    [void]$Cfg.fcop._runtime.appendChild($commands)
    $Cfg.Save("C:\git\CogFramework\Deploy\temp.xml")
   # throw "x"
    Complete-FCopTask $fnTask

    return $commands
}

#
# Create a new filecache and put it in runtime config file
#
function New-FCopFilecache {
    param(
    [Parameter(Mandatory=$true)]
    [System.Xml.XmlDocument]$Cfg
    )
    

    $fnTask = Start-FCopTask "Creating filecache"

    $filecacheRoot = $Cfg.CreateElement("filecache")
    $now = get-date 
    $now = $now.ToUniversalTime();
    $filecacheRoot.SetAttribute("created", $now.ToString("yyyy-MM-ddTHH:mm:ssZ")) 

    [void]$Cfg.fcop._runtime.AppendChild($filecacheRoot)

           # Write-Host "[PROCESSING] " -ForegroundColor Yellow -NoNewline
           # Write-host "New-FCopFilecache" -NoNewline -ForegroundColor White
           # write-host "..." -NoNewline


    foreach($cmd in $Cfg.fcop.Commands.ChildNodes) {
        if ($cmd.LocalName -eq "Copy") {
            $sourceFolder = $Cfg.fcop._runtime.ResolvedSourceFolder
            $localpath = (join-path $sourceFolder $cmd.SourcePath)
            $files = Get-ChildItem  -Path $localpath -Recurse -ErrorAction SilentlyContinue -File
            [System.XML.XMLElement]$folderNode=$filecacheRoot.appendChild($Cfg.CreateElement("folder"))
            
            if (-not $cmd.TargetPath -or $cmd.TargetPath -eq ".") {
                $targetPath = $cmd.SourcePath;
            } else {
                $targetPath = $cmd.TargetPath
            }
            $folderNode.SetAttribute("SourcePath", $cmd.SourcePath);
            $folderNode.SetAttribute("TargetPath", $targetPath);
            $folderNode.SetAttribute("ResolvedSourcePath", $localpath)
            $n = 0
            $ignoredFiles = 0
            Write-FCopInfo ("Processing " + $localpath)
            foreach(  $fileo in $files) {
                [System.IO.FileInfo]$file = $fileo
                #$folderToMatch = $file.DirectoryName.Substring($localpath.Length)
                $sourcePath = $file.FullName.Substring($localpath.Length)
              #  Write-Host $cmd.ChildNodes.Length
                if ($cmd.HasChildNodes) {
                    foreach($ignored in $cmd.ChildNodes) {
                        if ($ignored.LocalName -eq "Ignore") {
                            if ($sourcePath -match $ignored.InnerText) {
                                $ignoredFiles ++
                                #Write-Host "IGNORE " $sourcePath
                                continue;
                            }
                        }
                    }
                }

                $fileHash = Get-FileHash $file.FullName -Algorithm MD5
                $fileNode = [System.XML.XMLElement]$Cfg.CreateElement("file")
               
                $fileNode.SetAttribute("SourcePath", $sourcePath )
                $fileNode.SetAttribute("Bytes", $file.Length)
                $fileNode.SetAttribute("Hash", $fileHash.Hash)
                #$fileNode.SetAttribute("Folder", $file.)
                [void]$folderNode.appendChild($fileNode)

               # [void]$folderNode.appendChild($oXMLSystem)
            }

            $folderNode.SetAttribute("IgnoredFiles", $ignoredFiles)
        }
    }

    Complete-FCopTask $fnTask


}

function Start-FCopTask {
     param(
    [Parameter(Mandatory=$true)]
    [string]$Title
    )
    $callstack = Get-PSCallStack

    if (-not $global:taskdepth) { $global:taskdepth = 0}
    $global:taskdepth ++
    $indent = " " * $global:taskdepth
    Write-Host ("[START] " + $indent) -ForegroundColor Yellow -NoNewline
    Write-Host $Title -ForegroundColor White -NoNewline
    Write-Host (" " + $callstack[1].FunctionName + " " + $callstack[1].Location) -ForegroundColor DarkGray
    
    return @{
        Title = $Title;
        StartTime = Get-Date;
        Function = $callstack[1].FunctionName
    }


}

# Fail a task
function Stop-FCopTask {
     param(
    [Parameter(Mandatory=$true)]
    [object]$Token
    )
    $global:taskdepth --
    $now = Get-Date
    $duration = New-TimeSpan -Start $Token.StartTime -End $now
    $indent = " " * $global:taskdepth

    Write-Host "[FAIL ] "$indent -ForegroundColor Red -NoNewline
    Write-Host $Token.Title -ForegroundColor White -NoNewline
    Write-Host " (" -NoNewline
    Write-Host $duration.ToString() -ForegroundColor DarkGray -NoNewline
    Write-Host ")"


}

function Write-FCopInfo {
     param(
    [Parameter(Mandatory=$true)]
    [string]$Text
    )

    $indent = " " * $global:taskdepth

    Write-Host "[INFO ] "$indent -ForegroundColor Cyan -NoNewline
    Write-Host $Text -ForegroundColor White


}


function Complete-FCopTask {
     param(
    [Parameter(Mandatory=$true)]
    [object]$Token
    )
    $global:taskdepth --
    $now = Get-Date
    $duration = New-TimeSpan -Start $Token.StartTime -End $now
    $indent = " " * $global:taskdepth
    Write-Host "[STOP ] "$indent -ForegroundColor Green -NoNewline
    Write-Host $Token.Title -ForegroundColor White -NoNewline
    Write-Host " (" -NoNewline
    Write-Host $duration.ToString() -ForegroundColor DarkGray -NoNewline
    Write-Host ")"

}

function Get-ScriptDirectory
{
  $Invocation = (Get-Variable MyInvocation -Scope 1).Value
  Split-Path $Invocation.MyCommand.Path
}


Export-ModuleMember "Install-Fcop"





   # $filecachexml = [io.path]::GetFileNameWithoutExtension($resolvedPath)
   # $filecachexml += ".filecache.xml"

   # $filecachezip = [io.path]::GetFileNameWithoutExtension($resolvedPath)
   # $filecachezip += ".filecache.zip"

   # $p = Split-Path $resolvedPath -Parent
   # $filecachexml = Join-Path $p  $filecachexml 
   # $filecachezip = Join-Path $p  $filecachezip 



   # Write-Host "Saving filecache " -NoNewline -ForegroundColor Yellow
   # Write-Host "..." -NoNewline
   # $xmlDocument.Save($filecachexml)
  #  Write-Host "OK" -ForegroundColor Green
  #  Write-Host "Compressing " -NoNewline -ForegroundColor Yellow
  #  Write-Host "..." -NoNewline
   # Compress-Archive -LiteralPath $filecachexml -CompressionLevel Optimal -DestinationPath $filecachezip -Force
  #  Write-Host "OK" -ForegroundColor Green



#    $SecurePasswordText = 'UWvDNdnrWMMVDv6y' | ConvertTo-SecureString -AsPlainText -Force | ConvertFrom-SecureString
#   New-Item -Name $pathHash -Path HKCU:\Software\Fcop -Value $SecurePasswordText

#    $ftpConnection = New-Object EnterpriseDT.Net.Ftp.FTPConnection

#   $ftpConnection.ServerAddress = "ftpcluster.loopia.se"
#   $ftpConnection.UserName = "davidlidstrom.com"
#   $ftpConnection.Password = "UWvDNdnrWMMVDv6y"
#   Write-Host $ftpConnection.serveraddress -ForegroundColor Red
#  $ftpConnection.Connect();