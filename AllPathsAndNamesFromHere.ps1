Get-ChildItem -Recurse | ForEach-Object { $_.FullName } | Set-Clipboard
Write-Output "Alle paths og filer er nu i din udklipsholder..."