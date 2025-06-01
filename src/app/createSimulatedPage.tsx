import { useState, useEffect } from "react";
import { ScrollView, StatusBar, Text, StyleSheet } from "react-native";
import { useNavigation } from "@react-navigation/native";
import { LinearGradient } from "expo-linear-gradient";


import Header from "@/src/components/header";
import Category from "@/src/components/category";
import Button from "@/src/components/button";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles";

import { Category as CategoryModel } from "@/src/models/Category";
import { CategoryRepository } from "@/src/repositories/categoryRepository";
import { CardRepository } from "@/src/repositories/cardRepository";

export default function CreateSimulatedPage() {
  const [categories, setCategories] = useState<CategoryModel[]>([]);
  const [selected, setSelected] = useState<Set<string>>(new Set());
  const cardsRepository = new CardRepository();

  useEffect(() => {
    async function loadCategories() {
      const repo = new CategoryRepository();
      const loaded = await repo.getAllCategories();
      setCategories(loaded);
    }
    loadCategories();
  }, []);

  function toggleCategory(name: string) {
    setSelected((prev) => {
      const copy = new Set(prev);
      copy.has(name) ? copy.delete(name) : copy.add(name);
      return copy;
    });
  }

  function CreateSimulate(selectedCategories: string[]) {
    const navigation = useNavigation<any>();

  const handleStart = async () => {
    try {
      const cards = await cardsRepository.getCardsByCategories(selectedCategories);

      if (cards.length === 0) {
        alert('Nenhum card encontrado para as categorias selecionadas.');
        return;
      }

      navigation.navigate('simulatedPage', { cards });

      } catch (error) {
        console.error('Erro ao buscar cards:', error);
        alert('Erro ao iniciar simulado. Tente novamente.');
      }
    };

    return handleStart;
  }

  return (
    <LinearGradient
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
      <StatusBar barStyle="light-content" backgroundColor={colors.blueLazuli} />
      <Header />

      <ScrollView contentContainerStyle={styles.scrollContent}>
        <Text style={style.title}>
          Selecione as categorias para o simulado:
        </Text>

        {categories.map((category) => (
          <Category
            key={category.name}
            name={category.name}
            selected={selected.has(category.name)}
            onPress={() => toggleCategory(category.name)}
          />
        ))}
      </ScrollView>

      <Button title="Criar Simulado" onPress={CreateSimulate(Array.from(selected))} />
    </LinearGradient>
  );
}

const style = StyleSheet.create({
  title: {
    color: colors.whiteIce,
    fontSize: 18,
    marginBottom: 16,
  },
});
