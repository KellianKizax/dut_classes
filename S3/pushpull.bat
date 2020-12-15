@echo OFF
echo Syncing from Laptop to Server
robocopy .\ "G:\- Kellian\IUT\dut_classes\S3" /MIR /XO /R:x /W:x

echo Syncing from Server to Laptop
robocopy "G:\- Kellian\IUT\dut_classes\S3" .\ /MIR /XO /R:x /W:x

echo Sync complete !
pause