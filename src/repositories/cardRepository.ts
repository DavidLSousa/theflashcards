import * as FileSystem from 'expo-file-system';

import { Card } from '@/src/models/Card';

export class CardRepository {
  private path = `${FileSystem.documentDirectory}allCards.json`;

  public async saveCard(card: Card) {
    const fileExists = await FileSystem.getInfoAsync(this.path);
    if (!fileExists.exists) {
      await FileSystem.writeAsStringAsync(this.path, JSON.stringify([card], null, 2));
      return;
    }

    const fileContent = await FileSystem.readAsStringAsync(this.path);
    const savedCards: Card[] = JSON.parse(fileContent);
    savedCards.push(card);
    await FileSystem.writeAsStringAsync(this.path, JSON.stringify(savedCards, null, 2));
  }
  public editCard(card: Partial<Card>) {};
  public removeCard(id: string) {};

  public async getAllCards(): Promise<Card[]> {
    const fileExists = await FileSystem.getInfoAsync(this.path);
    if (!fileExists.exists) {
      return [];
    }
    const fileContent = await FileSystem.readAsStringAsync(this.path);
    return JSON.parse(fileContent);
  }
  public getCardBtCategory(category: string): Card[] {
    return [];
  }
}