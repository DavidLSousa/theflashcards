# theflashcards

### DESIGN:
[ ] Baixar icones para Buttons da MainPage

### PROBS:
[ ] Satinização dos dados
[ ] Porque a imagem na tela de carregamento esta sem fundo e nas paginas tem uam borda mais escura?
[ ] Tela de Android quando apertada as labels Resposta e Pergunta saem da tela

### Tarefas para serem executadas:
1:  [ ] Implementar Estado de resp -> Se acertou ou errou
        // Salva o estado de acerto e erro ? OU Salva a contagem de numero de bzs que acertou ou errou? OU Essa contagem deve ser feita e mantida so nas estastisticas?
            // Acho que acerto ou erro deve:
                // levar a informação pra estatistica
                // Add a uma contagem e erros e acertos dentro do proprio obj Card
                    // Permite estatistica fultura de card por card
        // Isso vai para estatisticas

2:  [ ] Implementar Estatisticas
        // Vai receber as informações de dificuldade e acerto, sera instanciado e atualizado quando chamado
        // Vai ter um button, que leva a uma pagina com as estatisticas nela
        // Ideias ate agr:
            [ ] Numeração de cards classificados com Facil, Med e dif
                [ ] Mostrar evolução de cards de transtaram de dificuldade
                    // De dif virou med, de med virou facil e etc
            [ ] Montar grafico com historio de acertos e erros
                // será geral de todas as questoes
                // Como será feita a relação?
                    // Calculo a ser feito para montar esse gradico
                    // Mostrar acertos e erros por peridos de tempo -> diário e semanal
                        // E se nao fizer todo dia? ou toda semana?
                        // Terá um maximo de quantos dias/semanas no grafico?

3:  [ ] Avaliaçãos e dificudade do card -> Fácil, Medio e Dificil
        // Mostrar relação de atualização, quando ao classificar o card com uma dificuldade diferente da ultima selecionada
            // Aciona a mudança de estado e entra pra estatistica
        // Isso vai ser mostrado na tela de estatistica

4:  [ ] Implementar pag de simulado automatico, gerado por uma IA;
        [ ] button par cards gerados por IA
            // Leva a lista de Lista de testes (Nome da categoria, como na buildTest)
            // Leva a page de teste com os cards em ordem aleatoria
        [ ] Diretorio cards pre-gerados por uma IA?

5: [ ] Poderia ser utilizado um dicionario inves de um json?
        // Oq implicaria na hora de importar cards ?
        // Tortaria significativamente mais rapido o app? 
        // A consulta do Dict no C# é de (O)1?
        // 