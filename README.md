# theflashcards


### Tarefas para serem executadas:
[ ] Criar pagina de edi��o para cada categoria, assim como o mostrar todos os cards, mas para mostrar todos cards de uma categoria ou subcategoria e poder apagar e editar
   [x] Deletar card
       [x] Verificar se a pasta ficou completamente vazia, se sim, deletar a pasta tbm
       [x] Verificar se o arquivo json ficou vazio, se sim, deletar esse arquivo
       [x] So faz para o atual, precisa ter um for para verificar ate um diretorio que tem algo, para deletar em cascata
       [ ] Add confirma��o pra exclusao
   [x] Editar card
       [ ] Permitir mudar de categoria 
           [ ] Ao mudar de categoria, � preciso alterar a localiz���o do card do seu diretorio especifico
           [ ] Mostrar as categorias possiveis para escolher?

[ ] Satiniza��o dos dados
[ ] Limpar os campos(quest e resp) para uma novo Card quando for salvo com sucesso;
   // Pode ser um botao ao lado no entry que limpe isso ?
[ ] Add anima��o no bot�o para mostrar que foi clicado?
[ ] Mostrar as categorias que ja existem na hor de criar um novo card, para poder selecionar
[ ] 

[ ] Implementar pag de simulado automatico, gerado por uma IA;
    [ ] Intera��o com API ou salvar em diretorio cards pre-gerados?
[ ] 

OBS:
    [ ] Ajustar o cardServices.BuildFilePath, para retornar um obj e n�o um array
        // Rever o noe da variavel, n � sem categoria e sim sem arquivo json no path
    [ ] Porque a imagem na tela de carregamento esta sem fundo e nas paginas tem uam borda mais escura?
    [ ] Precisa de em buscador para fazer: "Usar essa pasta" ? para permitir usar uma pasta flashcards ja criada antes?
    [ ]
    [ ] Solicita��o de permi��o ainda n�o funciona
        // olhar: https://github.com/dotnet/maui/issues/6015
        // Storage Access Framework - Scope Storages
        // https://developer.android.com/training/data-storage/shared/documents-files?hl=pt-br#java
            // Restri��es de acesso - Conceder acesso ao conte�do de um diret�rio - Manuten��o de regras
        [ ] Importar AllCards dentro do app
    [ ] 
    [ ] EXLUIR DIRETORIOS ESPECIFICOS?
