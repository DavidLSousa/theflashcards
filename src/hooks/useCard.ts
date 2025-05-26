import { create } from 'zustand';

import { Card } from "@/src/models/Card";
import { CardRepository } from "@/src/repositories/cardRepository";

type CardType = {
  cards: Card[];
  fetchCards: () => Promise<void>;
  addCard: (quest: string, resp: string, category: string) => void;
  editCard: (cards: Card[], updatedCard: Card) => void;
  removeCard: (id: string) => void;
  toggleAnswer: (id: string) => void;
}

export const useCard = create<CardType>((set) => ({
  cards: [],
  fetchCards: async () => {
    const repo = new CardRepository();
    const cards = await repo.getAllCards();
    set({ cards });
  },
  addCard: (quest, resp, category) =>
    set((state) => {
      const newCard = new Card(quest, resp, category);
      const newCards = [...state.cards, newCard];

      // Repository
      const cardRepository = new CardRepository();
      cardRepository.saveCard(newCard);

      return { cards: newCards }
    }),
  editCard: (updatedCard: Partial<Card>) => 
    set((state) => {
      const updatedCards = state.cards.map((currentCard) => 
        currentCard.id === updatedCard.id 
          ? { ...currentCard, ...updatedCard } 
          : currentCard);

      // Update the repository with the new cards
      
      return { cards: updatedCards };
    }),
  removeCard: (id) =>  
    set((state) => {
      const updatedCards = state.cards.filter((card) => card.id !== id);
      
      // Remove the card from the repository

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
}));