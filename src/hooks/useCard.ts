import { create } from 'zustand';

import { Card } from "@/src/models/Card";
import { CardRepository } from "@/src/repositories/cardRepository";

type CardType = {
  cards: Card[];
  fetchCards: () => Promise<void>;
  addCard: (quest: string, resp: string, category: string) => void;
  editCard: (updatedCard: Partial<Card>) => void;
  removeCard: (id: string) => void;
  toggleAnswer: (id: string) => void;
  importNewCards: (importedCards: string) => Promise<void>;
  copyCardsToClipboard: () => Promise<void>;
}

const repo = new CardRepository();

export const useCard = create<CardType>((set) => ({
  cards: [],
  fetchCards: async () => {
    const cards = await repo.getAllCards();
    set({ cards });
  },
  addCard: (quest, resp, category) =>
    set((state) => {
      const newCard = new Card(quest, resp, category);
      const newCards = [...state.cards, newCard];

      repo.saveCard(newCard);

      return { cards: newCards }
    }),
  editCard: (updatedCard: Partial<Card>) => 
    set((state) => {
      const updatedCards = state.cards.map((currentCard) => 
        currentCard.id === updatedCard.id 
          ? { ...currentCard, ...updatedCard } 
          : currentCard);

      repo.editCard(updatedCard);
      
      return { cards: updatedCards };
    }),
  removeCard: (id) =>  
    set((state) => {
      const updatedCards = state.cards.filter((card) => card.id !== id);
      
      repo.removeCard(id);

      return { cards: updatedCards };
    }),
  toggleAnswer: (id) =>  
    set((state) => {
      const updatedCards = state.cards.map((card) => 
        card.id === id 
          ? { ...card, isAnswerVisible: !card.isAnswerVisible } 
          : card);
      
      return { cards: updatedCards };
    }),
  importNewCards: async (importedCards) => {
    await repo.importCards(importedCards);
  },
  copyCardsToClipboard: async () => {
    await repo.copyCardsToClipboard();
  }
}));