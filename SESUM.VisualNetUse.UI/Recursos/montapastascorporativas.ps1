$cred = Get-Credential -Message "Informe seu usuário e senha para acessar suas pastas" 
$letraDoDrive = "Z"
$caminho = "\\viana-0a\pastas$"
New-PSDrive -Name $letraDoDrive -Root $caminho -Persist  -Credential $cred -PSProvider FileSystem -Scope Global -ErrorAction Stop | Out-Null
