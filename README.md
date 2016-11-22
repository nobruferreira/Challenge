# Challenge

Solução desenvolvida a partir do .NET Framework 4.6.1 - Visual Studio 2015, com a finalidade de consumir e exibir dados a partir da Api Marvel Comics, que disponibiliza para desenvolvedores do mundo inteiro, o acesso a informações referente uma vasta biblioteca de quadrinhos de Super Heróis da Marvel que foi criada a 70 anos atrás.

De modo resumido, abaixo seguem alguns dos principais conceitos, técnicas, pacotes e tecnologias utilizadas/aplicadas neste projeto: 

## WEB

- Front End desenvolvido com o framework Angular JS, sendo implementado o Provider de autenticação de acesso OAuth 2.0, em comunicação com a Web Api Rest C#.

- Pacotes Web baixados via Bower.
	
## API
		
- Testes Unitários para simulação do comportamento esperado de uma respectiva ação em relação ao consumo à dados na Marvel Comics Api dentro da aplicação (conceito TDD).

- Estrutura em camadas, separação de responsabilidades, injeção de dependência, entre outros conceitos de SOLID e DDD.

- Uso do Banco de Dados Redis(NoSql), que possui a responsabilidade do armazenamento em cache dos dados em memória dentro da aplicação. Contudo para que seja possível executar esta aplicacao em uma máquina local, será necessário realizar a instalacao do Redis, descompactar seu pacote e inicializar os aplicativos mencionados abaixo partir de qualquer pasta dentro do sitema operacional que neste caso está sendo utilizado o Windows.
	
	**redis-server.exe** (funcionará em memória dentro do Windows).
	**redis-cli.exe**
	
	Veja este vídeo caso tenha alguma dúvida na instalacao: https://www.youtube.com/watch?v=Pdapt2PFidE
	
- Para que o Redis trabalhe com o armazenamento em cash no Windows, será necessário comentar as seguintes linhas dentro do arquivo
**redis.windows.exe** 

	Na sessao **####### SNAPSHOTTING #######** 
	
	acrescentar o caracter **#** antes das palavras **save**.
	
	**#save 900 1**
	
	**#save 300 10**
	
	**#save 60 10000**

- Com o Redis executando normalmente dentro de seu sistema operacional, o mesmo poderá ser consumido dentro do C# a partir da API **"NServiceKit.Redis"**, baixada via NuGet.

	Comando via Package Manager Console: > **Install-Package NServiceKit.Redis**
	
- Foi aplicado o conceito de AOP através do pacote baixado via NuGet **“Postsharp”** para implementar aspector no C# em relação as Entidades que obtiveram seus dados armazenados em cache a partir de uma segunda requisição vinda do Client.

	Comando via Package Manager Console: > **Install-Package Postsharp**

## PUBLICAÇÃO

Aplicação publicada na Amazon, e disponível a partir dos seguintes links:

- WEB:
- API: 
