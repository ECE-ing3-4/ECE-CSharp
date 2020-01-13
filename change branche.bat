@echo off
git branch

set /P branchName=Entre le nom de la branche: 
git checkout %branchName%
pause