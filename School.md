# School

## Enable Proxy

### Enable Proxy Script

```powershell
$reg = "HKCU:\Software\Microsoft\Windows\CurrentVersion\Internet Settings"
Set-ItemProperty -Path $reg -Name ProxyServer -Value "http://172.24.32.2:9090"
Set-ItemProperty -Path $reg -Name ProxyEnable -Value 1
```

### Enable Proxy Shortcut

```text
"C:\Program Files\PowerShell\7\pwsh.exe" -File "C:\Tools\EnableProxy.ps1"
```

## Disable Proxy

### Disable Proxy Script

```powershell
$reg = "HKCU:\Software\Microsoft\Windows\CurrentVersion\Internet Settings"
Set-ItemProperty -Path $reg -Name ProxyEnable -Value 0
```

### Disable Proxy Shortcut

```text
"C:\Program Files\PowerShell\7\pwsh.exe" -File "C:\Tools\DisableProxy.ps1"
```
