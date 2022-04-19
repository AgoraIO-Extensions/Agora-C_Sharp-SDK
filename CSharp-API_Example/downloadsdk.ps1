$agora_sdk = 'https://download.agora.io/sdk/release/Agora_C_Sharp_SDK_v3.6.2.test.zip'
$agora_des = '..\csharp.zip'
if (-not (Test-Path ..\libs)){
	echo "download $agora_des"
	mkdir ..\libs
	(New-Object System.Net.WebClient).DownloadFile($agora_sdk,$agora_des)
	Unblock-File $agora_des
	Expand-Archive -Path $agora_des -DestinationPath ..\libs -Force 
	Remove-Item  $agora_des -Recurse
}