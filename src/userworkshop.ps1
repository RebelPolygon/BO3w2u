# Written by: RebelPolygon
# Last Updated: 8-13-2023

# Assign Current Working Directory to $BO3
$BO3 = Get-Location

# Change directory to workshop folder
Set-Location -Path "..\..\workshop\content\311210"

# Iterate over workshop subdirectories
Get-ChildItem -Directory | ForEach-Object {
    $workshopJsonPath = Join-Path -Path $_.FullName -ChildPath "workshop.json"

    # Check if workshop.json file exists
    if (Test-Path $workshopJsonPath) {
        $type = (Get-Content $workshopJsonPath | Select-String -Pattern '"Type": "(.+?)"').Matches.Groups[1].Value
        $name = (Get-Content $workshopJsonPath | Select-String -Pattern '"Title": "(.+?)"').Matches.Groups[1].Value
        $path = (Get-Content $workshopJsonPath | Select-String -Pattern '"FolderName": "(.+?)"').Matches.Groups[1].Value

        if ($type -eq "map") {
            Write-Host "($type) $name [$path] -> /usermaps/"
            $targetPath = Join-Path -Path $BO3 -ChildPath "usermaps\$path\zone"
            New-Item -ItemType Directory -Path $targetPath -Force
            Move-Item -Path $_.FullName -Destination $targetPath -Force
        }

        if ($type -eq "mod") {
            Write-Host "($type) $name [$path] -> /mods/"
            $targetPath = Join-Path -Path $BO3 -ChildPath "mods\$path"
            New-Item -ItemType Directory -Path $targetPath -Force
            Move-Item -Path $_.FullName -Destination $targetPath -Force
        }
    }
}

# Display Confirmation Message
Write-Host "`n[DONE] You can unsubscribe to save space"
