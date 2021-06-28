

$cred = $host.UI.PromptForCredential("Usuario e senha TRE-MA","Informe seu usuario e senha do TRE (Igual ao do e-mail)" ,"TRE-MA\seu titulo aqui","")
$letraDoDrive = "Z"
$caminho = "\\viana-0a\pastas$"
New-PSDrive -Name $letraDoDrive -Root $caminho -Persist  -Credential $cred -PSProvider FileSystem -Scope Global -ErrorAction Stop | Out-Null
