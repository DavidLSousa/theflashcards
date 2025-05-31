import * as FileSystem from 'expo-file-system';
import { Category } from '@/src/models/Category';
import { Card } from '@/src/models/Card';

export class CategoryRepository {
  private path = `${FileSystem.documentDirectory}categories.json`;

  public async saveCategory(category: string) {
    try {
      // Clean Category
      // if (true) {
      //   await FileSystem.deleteAsync(this.path);
      //   const fileExists = await FileSystem.getInfoAsync(this.path);
      //   console.log('exists: ', fileExists)
      //   return
      // }

      const fileExists = await FileSystem.getInfoAsync(this.path);

      if (!fileExists.exists) {
        await FileSystem.writeAsStringAsync(this.path, JSON.stringify([{ name: category }], null, 2));
        return;
      }

      const fileContent = await FileSystem.readAsStringAsync(this.path);
      const savedCategories: Category[] = JSON.parse(fileContent);

      // Usa Set para evitar duplicata
      const categorySet = new Set(savedCategories.map(c => c.name));
      categorySet.add(category);

      const uniqueCategories: Category[] = Array.from(categorySet).map(name => ({ name }));

      await FileSystem.writeAsStringAsync(this.path, JSON.stringify(uniqueCategories, null, 2));
    } catch (error) {
      console.error('saveCategory: ', error);
      if (error instanceof Error) throw new Error(error.message);
      throw new Error('Failed to save category');
    }
  }

  public async getAllCategories(): Promise<Category[]> {
    try {
      const fileExists = await FileSystem.getInfoAsync(this.path);
      if (!fileExists.exists) return [];

      const fileContent = await FileSystem.readAsStringAsync(this.path);
      return JSON.parse(fileContent);
    } catch (error) {
      console.error('getAllCategories: ', error);
      if (error instanceof Error) throw new Error(error.message);
      throw new Error('Failed to fetch categories');
    }
  }

//logica:
        /*
          Isso é um Set, entao se eu add e for repetido noa tem problema, ele nao vaiduplicar
          Se a categoria editada nao existir ele vai add
          Verificar apenas se ainda existe cards com a categoria anterior a edição
        */
  public async editCategory(originalCategory: string, editedCategory: string) {
  try {
    const fileContent = await FileSystem.readAsStringAsync(this.path);
    const savedCategories: Category[] = JSON.parse(fileContent);

    const cards: Card[] = await this.getCards();

    // Verifica se ainda há outros cards usando a categoria original
    const otherCardsStillUseOriginal = cards.filter(card => card.category === originalCategory).length > 1;

    // Monta um Set com as categorias considerando a edição
    const categorySet = new Set<string>();

    for (const card of cards) {
      if (card.category === originalCategory) {
        // Simula a mudança de categoria no card editado
        categorySet.add(editedCategory);
      } else {
        categorySet.add(card.category);
      }
    }

    // Se ainda tem outros cards usando a categoria original, ela deve continuar
    if (otherCardsStillUseOriginal) {
      categorySet.add(originalCategory);
    }

    // Transforma em array de objetos { name: string }
    const finalCategories: Category[] = Array.from(categorySet).map(name => ({ name }));
    console.log('finalCategories: ', finalCategories)
    await FileSystem.writeAsStringAsync(this.path, JSON.stringify(finalCategories, null, 2));

  } catch (error) {
    console.error('editCategory: ', error);
    if (error instanceof Error) throw new Error(error.message);
    throw new Error('Failed to edit category');
  }
}


  public async deleteCategory(cardId: string) {
    try {
      const fileContent = await FileSystem.readAsStringAsync(this.path);
      const savedCategories: Category[] = JSON.parse(fileContent);

      const cards: Card[] = await this.getCards();

      const cardToDelete = cards.find(card => card.id === cardId);
      if (!cardToDelete) throw new Error(`Card com id ${cardId} não encontrado.`);

      const category = cardToDelete.category;

      // Verifica se há outros cards usando essa categoria
      const categoryStillUsed = cards.some(card =>
        card.category === category && card.id !== cardId
      );

      if (categoryStillUsed) {
        console.log(`Categoria "${category}" ainda está em uso por outros cards. Não será removida.`);
        return;
      }

      // Remove a categoria do arquivo se não está sendo usada mais
      const updatedCategories = savedCategories.filter(c => c.name !== category);

      await FileSystem.writeAsStringAsync(this.path, JSON.stringify(updatedCategories, null, 2));
    } catch (error) {
      console.error('deleteCategory: ', error);
      if (error instanceof Error) throw new Error(error.message);
      throw new Error('Failed to delete category');
    }
  }

  public async importCategories(importedCards: string) {
    try {
      const importedCategoryNames = JSON.parse(importedCards).map((card: Card) => card.category);
      const importedCategorySet = new Set(importedCategoryNames);

      const fileExists = await FileSystem.getInfoAsync(this.path);
      let existingCategories: string[] = [];

      if (fileExists.exists) {
        const fileContent = await FileSystem.readAsStringAsync(this.path);
        const savedCategories: Category[] = JSON.parse(fileContent);
        existingCategories = savedCategories.map(c => c.name);
      }

      const mergedSet = new Set([...existingCategories, ...importedCategorySet]);
      const mergedCategories: Category[] = Array.from(mergedSet as Set<string>).map(name => ({ name }));


      await FileSystem.writeAsStringAsync(this.path, JSON.stringify(mergedCategories, null, 2));
    } catch (error) {
      console.error('importCategories: ', error);
      if (error instanceof Error) throw new Error(error.message);
      throw new Error('Failed to import categories');
    }
  }

  private async getCards(): Promise<Card[]> {
    return JSON.parse(await FileSystem.readAsStringAsync(`${FileSystem.documentDirectory}allCards.json`))
  }
}
