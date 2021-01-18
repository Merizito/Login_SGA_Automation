#Language pt-BR

@login
Funcionalidade: Realizar login no SGA
Como um estudante da universidade
Quero realizar login no Sistema de Gestão Acadêmica
Para ter acesso às suas funcionalidades

Contexto:
Dado ques estou na página de login do SGA
E não estou logado

Cenário: Login com sucesso
Quando insiro uma matrícula correta e válida no campo matrícula
E insiro uma senha correta e válida no campo senha
E seleciono origem correta referente à minha matrícula
E clico em entrar
Então o sistema deve realizar o login
E apresentar as opções de funcionalidades do sistema



#Tentativa de login com matrícula errada/inválida
Cenário: Login sem sucesso #1
Quando insiro uma matrícula inválida no campo matrícula
E insiro uma senha correta e válida no campo senha
E seleciono origem correta referente à minha matrícula
E clico em entrar
Então o sistema deve me apresentar um erro ao tentar realizar o login



#Tentativa de login com senha incorreta/inválida
Cenário: Login sem sucesso #2
Quando insiro uma matrícula correta e válida no campo matrícula
E insiro uma senha inválida no campo senha
E seleciono origem correta referente à minha matrícula
E clico em entrar
Então o sistema deve me apresentar um erro ao tentar realizar o login



#Tentativa de login com a origem incorreta/inválida
Cenário: Login sem sucesso #3
Quando insiro uma matrícula correta e válida no campo matrícula
E insiro uma senha correta e válida no campo senha
E seleciono uma origem incorreta referente à minha matrícula
E clico em entrar
Então o sistema deve me apresentar um erro ao tentar realizar o login