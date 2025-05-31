import { useState, useEffect } from "react";
import { ScrollView, StatusBar, Text } from "react-native";
import { LinearGradient } from "expo-linear-gradient";

import Header from "@/src/components/header";
import Category from "@/src/components/category";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles";

import { Category as CategoryModel } from "@/src/models/Category";
import { CategoryRepository } from "@/src/repositories/categoryRepository";

export default function CreateSimulatedPage() {
  const [categories, setCategories] = useState<CategoryModel[]>([]);
  const [selected, setSelected] = useState<Set<string>>(new Set());

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
    </LinearGradient>
  );
}

import { StyleSheet } from "react-native";

const style = StyleSheet.create({
  title: {
    color: colors.whiteIce,
    fontSize: 18,
    marginBottom: 16,
  },
});
