# The Flashcards

**The Flashcards** é um aplicativo para criação, organização e estudo de cartões de perguntas e respostas (flashcards). Ideal para estudantes, professores e entusiastas da aprendizagem, ele ajuda a revisar conteúdos de forma prática e eficiente.

## 📋 Funcionalidades

- 🖋 **Criação de Flashcards**: Adicione perguntas e respostas personalizadas.
- 📂 **Organização por Categorias**: Agrupe os flashcards em categorias para facilitar o estudo.
- 🔄 **Revisão Eficiente**: Use o modo de estudo para revisar as perguntas e verificar suas respostas.
- 💾 **Persistência de Dados**: Os flashcards são salvos localmente no dispositivo.
- 🌐 **Suporte Multiplataforma**: Disponível para Android e Windows.

## 🚀 Tecnologias Utilizadas

- **Framework**: React Native  
- **Linguagem**: TypeScript  
- **Banco de Dados**: Arquivo JSON (armazenamento local)    

## 🛠 Como Usar

1. **Criação de Cartões**:  
   - Insira a pergunta no campo correspondente.  
   - Insira a resposta no campo abaixo.  
   - Insira a categoria ou selecione uma já existente.  
   - Salve o cartão.  

2. **Modo de Estudo**:  
   - Escolha uma categoria.  
   - Responda às perguntas mentalmente ou escrevendo.  
   - Reveja as respostas para conferir.  

3. **Como importar seus cards**:  
   - Copie e cole o conteúdo de `AllCards.json` na caixa de texto na página "Importe seus cards".  
   - **OU**  
   - Solicite a uma IA perguntas e respostas no formato do JSON abaixo.  
   - Deixe claro que só deve alterar as informações do `Id` (formato GUID), `Quest`, `Resp` e `Category` (todos no formato de string).  
   - Certifique-se de que o JSON gerado está no formato correto.  
   - Copie e cole na caixa de texto da página "Importe seus cards".  

```json
[
  {
    "Id": "GUID_AQUI",
    "Quest": "Pergunta aqui",
    "Resp": "Resposta aqui",
    "Category": "Categoria aqui",
    "IsAnswerVisible": false,
    "TestResult": {
      "Id": "GUID_AQUI",
      "Answer": {
        "correct": 0,
        "wrong": 0
      },
      "Difficulty": {
        "easy": 0,
        "medium": 0,
        "difficult": 0
      }
    }
  }
]
```

## 📦 Instalação

### Android
1. Baixe o APK mais recente na [seção de Releases](#).
2. Instale no seu dispositivo Android.

### Windows
1. Faça o download do instalador para Windows na [seção de Releases](#).
2. Siga as instruções do instalador.

## 🤝 Contribuições

Contribuições são bem-vindas! Siga os passos abaixo:  
1. Faça um fork do repositório.  
2. Crie um branch para sua feature: `git checkout -b minha-feature`.  
3. Realize as alterações e comite: `git commit -m 'Adiciona minha feature'`.  
4. Faça um push para o branch: `git push origin minha-feature`.  
5. Abra um Pull Request.  

## 📝 Licença

Este projeto está licenciado sob a licença [MIT](LICENSE).

---

**The Flashcards** - Tornando o aprendizado mais fácil e divertido! 🎓✨
