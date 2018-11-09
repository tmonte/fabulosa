#!/bin/bash

NUGET_KEY=$1

dotnet pack --configuration Release  --verbosity detailed --output nupkgs ./src/Fabulosa/Fabulosa.fsproj 
dotnet nuget push ./src/Fabulosa/nupkgs/Fabulosa.*.nupkg -k $NUGET_KEY -s https://api.nuget.org/v3/index.json
