# theflashcards


### Tarefas para serem executadas:
[ ] Criar pagina de edição para cada categoria, assim como o mostrar todos os cards, mas para mostrar todos cards de uma categoria ou subcategoria e poder apagar e editar
   [x] Deletar card
       [x] Verificar se a pasta ficou completamente vazia, se sim, deletar a pasta tbm
       [x] Verificar se o arquivo json ficou vazio, se sim, deletar esse arquivo
       [ ] So faz para o atual, precisa ter um for para verificar ate um diretorio que tem algo, para deletar em cascata
   [ ] Editar card
       [ ] Permitir mudar de categoria - Mostrar as categorias possiveis para escolher?

[ ] Satinização dos dados
[ ] Limpar os campos(quest e resp) para uma novo Card quando for salvo com sucesso;
   // Pode ser um botao ao lado no entry que limpe isso ?
[ ] Add animação no botão para mostrar que foi clicado?
[ ] Mostrar as categorias que ja existem na hor de criar um novo card, para poder selecionar
[ ] 

[ ] Implementar pag de simulado automatico, gerado por uma IA;
    [ ] Interação com API ou salvar em diretorio cards pre-gerados?
[ ] 

OBS:
    [ ] Ajustar o cardServices.BuildFilePath, para retornar um obj e não um array
        // Rever o noe da variavel, n é sem categoria e sim sem arquivo json no path
    [ ] Porque a imagem na tela de carregamento esta sem fundo e nas paginas tem uam borda mais escura?
    [ ] Precisa de em buscador para fazer: "Usar essa pasta" ? para permitir usar uma pasta flashcards ja criada antes?
    [ ]
    [ ] Solicitação de permição ainda não funciona
        // olhar: https://github.com/dotnet/maui/issues/6015
        // Storage Access Framework - Scope Storages
        // https://developer.android.com/training/data-storage/shared/documents-files?hl=pt-br#java
            // Restrições de acesso - Conceder acesso ao conteúdo de um diretório - Manutenção de regras
    [ ]
