#!/bin/bash

rm -rf Output/*

dotnet run

source env/bin/activate

python3 plot.py

mv *.txt Output/
mv *.png Output/
