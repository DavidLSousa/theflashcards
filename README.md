﻿# The Flashcards

**The Flashcards** é um aplicativo para criação, organização e estudo de cartões de perguntas e respostas (flashcards). Ideal para estudantes, professores e entusiastas da aprendizagem, ele ajuda a revisar conteúdos de forma prática e eficiente.

## 📋 Funcionalidades

- 🖋 **Criação de Flashcards**: Adicione perguntas e respostas personalizadas.
- 📂 **Organização por Categorias**: Agrupe os flashcards em categorias para facilitar o estudo.
- 🔄 **Revisão Eficiente**: Use o modo de estudo para revisar as perguntas e verificar suas respostas.
- 💾 **Persistência de Dados**: Os flashcards são salvos localmente no dispositivo.
- 🌐 **Suporte Multiplataforma**: Disponível para Android e Windows.

## 🚀 Tecnologias Utilizadas

- **Framework**: .NET MAUI  
- **Linguagem**: C#  
- **Banco de Dados**: Arquivo JSON (armazenamento local)  
- **Arquitetura**: MVVM (Model-View-ViewModel)  

## 🛠 Como Usar

1. **Criação de Cartões**:  
   - Insira a pergunta no campo correspondente.  
   - Insira a resposta no campo abaixo.  
   - Insira a categora ou selecione uma ja existente.
   - Salve o cartão.  

2. **Modo de Estudo**:  
   - Escolha uma categoria.  
   - Responda às perguntas mentalmente ou escrevendo.  
   - Reveja as respostas para conferir.  

3. **Como importar seus cards**:  
   - Copie e cole o conteudo de AllCards.json na caixa de texto na pagina "importe seus cards"."
   - OU
   - Solicite a uma IA peguntas e respostas no formado no json abaixo.
   - Deixe claro que so deve alterar as informações do id(formado guid), Quest, Resp e Category(todos no formato de string).
   - Certifique-se que o json gerado esta no formato correto.
   - Copie e cole na cada de texto da pagina "importe seus cards"
[
  {
    "Id": "",
    "Quest": "",
    "Resp": "",
    "Category": "",
    "IsAnswerVisible": false,
    "TestResult": {
      "Id": "",
      "Answer": {
        "correct": 0,
        "wrong": 0
      },
      "Difficulty": {
        "easy": ,
        "medium": 0,
        "difficult": 0
      }
    }
  },
] 

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
