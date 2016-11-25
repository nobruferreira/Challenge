# Challenge

Solução desenvolvida a partir do .NET Framework 4.6.1 - Visual Studio 2015, com a finalidade de consumir e exibir dados a partir da Api Marvel Comics(link: https://developer.marvel.com/), que disponibiliza para desenvolvedores do mundo inteiro, o acesso a informações referente uma vasta biblioteca de quadrinhos de Super Heróis da Marvel que foi criada a 70 anos atrás.

De modo resumido, abaixo seguem alguns dos principais conceitos, técnicas, pacotes e tecnologias utilizadas/aplicadas neste projeto: 

## WEB

- Front End desenvolvido com o framework Angular JS, sendo implementado o Provider de autenticação de acesso OAuth 2.0, em comunicação com a Web Api Rest C#. 

- Pacotes Web baixados via Bower.

- Assumindo que o usuário já possui cadastro efetuado na Marvel Comics Api, link: **https://marvel.com/register?referer=http%3A%2F%2Fmarvel.com%2Fcomics**, para que seja possível realizar a autenticação nesta aplicação, onde são solicitadas as chaves **PRIVATE_KEY** e **PUBLIC_KEY**, as mesmas poderão ser encontradas
na aba **My Developer Account** a partir do link **https://developer.marvel.com/account**

- Com isso, favor entrar com as chaves mencionadas, para que a autenticação dentro desta aplicação(Challenge - MarvelApi) seja realizada com sucesso.
	
## API
		
- Testes Unitários para simulação do comportamento esperado de uma respectiva ação em relação ao consumo à dados na Marvel Comics Api dentro da aplicação (conceito TDD).

- Estrutura em camadas, separação de responsabilidades, injeção de dependência, entre outros conceitos de SOLID e DDD.

- Uso do Banco de Dados Redis(NoSql), que possui a responsabilidade do armazenamento em cache dos dados em memória dentro da aplicação. Contudo para que seja possível executar esta aplicação em uma máquina local, será necessário realizar a instalação do Redis, a partir do site: http://redis.io/download, descompactar seu pacote e inicializar os aplicativos mencionados abaixo em qualquer pasta dentro do sistema operacional que neste caso está sendo utilizado o Windows.
	
	**redis-server.exe** (funcionará em memória dentro do Windows).
	
	**redis-cli.exe** (se conectará com o redis-server.exe).
	
	Veja este vídeo caso tenha alguma dúvida na instalação do Redis: https://www.youtube.com/watch?v=Pdapt2PFidE
	
- Para que o Redis trabalhe com o armazenamento em cash no Windows, será necessário comentar as seguintes linhas dentro do arquivo de configuração **redis.windows.conf**:
 
	Na sessão **####### SNAPSHOTTING #######** 
	
	acrescentar o caracter **#** nas seguintes linhas antes da palavra **save**.
	
	**#save 900 1**
	
	**#save 300 10**
	
	**#save 60 10000**
	
	Estas linhas significam: Quero sincronizar meu banco de dados com meu cache em **"x" segundos**, em relação ao número de **"x" transações** realizadas. 
	
- Isto fará com que somente o armazenamento em cache seja habilitado, pois por padrão já vem habilitado o armazenamento em cache(memória) em sincronismo com o banco de dados(disco/IO) levando em questao o tempo juntamente com o número de transações. 

- Com o Redis executando normalmente dentro de seu sistema operacional, o mesmo poderá ser consumido dentro do C# a partir da API **"NServiceKit.Redis"**, baixada via NuGet.

	Comando via Package Manager Console: > **Install-Package NServiceKit.Redis**
	
- Foi aplicado o conceito de AOP através do pacote baixado via NuGet **“Postsharp”** para implementar aspector no C# em relação as Entidades que obtiveram seus dados armazenados em cache a partir de uma segunda requisição vinda do Client.

	Comando via Package Manager Console: > **Install-Package Postsharp**

## PUBLICAÇÃO

Aplicação publicada na Amazon, porém com seu armazenamento em cache desabilitado atualmente. Segue o link:

- WEB: http://35.162.85.6/ChallengeWeb/#/login

## REFERÊNCIAS

- https://bower.io/
- http://getbootstrap.com/
- http://bootswatch.com/
- https://angular-ui.github.io/bootstrap/
- https://developer.marvel.com/
- http://redis.io/download
- https://www.youtube.com/watch?v=Pdapt2PFidE
- https://www.youtube.com/watch?v=58tazVSghA8
- https://www.postsharp.net/
