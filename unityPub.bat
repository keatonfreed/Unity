@echo off
cd C:\Users\keato\Documents\Unity
if "%1" == "" goto no
git commit -a -e
git status
goto end

:no

echo No Name Provided!
echo Use: unityPub (message to publish)
goto end

:end
