@echo off
git pull
git branch -a
git log --oneline --decorate --graph --all
pause