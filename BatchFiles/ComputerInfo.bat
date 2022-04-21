mkdir ComputerInfo
date /t >> ComputerInfo\ServerInstalledPrograms.txt
time /t >> ComputerInfo\ServerInstalledPrograms.txt
reg query HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall >> ComputerInfo\ServerInstalledPrograms.txt
date /t >> ComputerInfo\WindowsInstalledServices.txt
time /t >> ComputerInfo\WindowsInstalledServices.txt
reg query HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\ >> ComputerInfo\WindowsInstalledServices.txt
date /t >> ComputerInfo\WindowsUsers.txt
time /t >> ComputerInfo\WindowsUsers.txt
wmic useraccount get name,sid >> ComputerInfo\WindowsUsers.txt
date /t >> ComputerInfo\WebsitePing.txt
time /t >> ComputerInfo\WebsitePing.txt
Ping lokithedog.com >> ComputerInfo\WebsitePing.txt
date /t >> ComputerInfo\NetStat.txt
time /t >> ComputerInfo\NetStat.txt
NetStat -e >> ComputerInfo\NetStat.txt
date /t >> ComputerInfo\NptStat.txt
time /t >> ComputerInfo\NptStat.txt
NbtStat -r >> ComputerInfo\NptStat.txt
date /t >> ComputerInfo\ipconfig.txt
time /t >> ComputerInfo\ipconfig.txt
ipconfig >> ComputerInfo\ipconfig.txt
echo ------------------------
echo This one is going to take a while
echo ------------------------
date /t >> ComputerInfo\tree.txt
time /t >> ComputerInfo\tree.txt
tree \ /f /a >> ComputerInfo\tree.txt
start explorer ComputerInfo
MSCONFIG 
