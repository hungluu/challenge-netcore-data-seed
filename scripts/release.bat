dotnet publish "DataGen/DataGen.App" -c Release -r win10-x64 /p:TrimUnusedDependencies=true -o "../../Releases/datagen"
DEL ".\Releases\datagen.exe"
CALL "./Scripts/warp-packer.exe" --arch windows-x64 --input_dir "./Releases/datagen" --exec datagen.exe --output Releases/datagen.exe
RMDIR /Q/S "./Releases/datagen"