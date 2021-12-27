@echo off
cd C:\Users\keato\Documents\Unity


git add *
git commit -a -e
git status
goto end

@REM if want to use args not -e
@REM if "%1" == "" goto no
@REM git commit -a -e
@REM git status
@REM goto end

@REM :no

@REM echo No Name Provided!
@REM echo Use: unityPub (message to publish)
@REM goto end

@REM :end

:end