$reg = "HKCU:\Software\Microsoft\Windows\CurrentVersion\Internet Settings"
Set-ItemProperty -Path $reg -Name ProxyServer -Value "http://172.24.32.2:9090"
Set-ItemProperty -Path $reg -Name ProxyEnable -Value 1
