import { LinearGradient } from "expo-linear-gradient";
import { useEffect, useState } from "react";
import { View, ScrollView, StatusBar, StyleSheet } from "react-native";

import { colors } from "@/src/constants/colors";
import { styles } from "./styles";
import Header from "@/src/components/header";
import Input from "@/src/components/input";
import Button from "@/src/components/button";
import ButtonCategory from "@/src/components/buttonCategory";

import { useCard } from "@/src/hooks/useCard";
import { CategoryRepository } from "@/src/repositories/categoryRepository";

export default function NewCardPage() {
  const [quest, setQuest] = useState("");
  const [resp, setResp] = useState("");
  const [category, setCategory] = useState("");

  const [showCategoryList, setShowCategoryList] = useState(false);
  const [availableCategories, setAvailableCategories] = useState<string[]>([]);

  useEffect(() => {
    async function loadCategories() {
      const repo = new CategoryRepository();
      const loaded = await repo.getAllCategories();
      console.log("Categorias carregadas:", loaded);
      const names = loaded.map(c => c.name);
      setAvailableCategories(names);
    }
    loadCategories();
  }, []);

  const handleCreateCard = () => {
    if (!quest.trim() || !resp.trim() || !category.trim()) {
      alert("Preencha todos os campos");
      return;
    }

    useCard.getState().addCard(quest, resp, category);

    setQuest("");
    setResp("");
  };

  const toggleShowCategories = () => {
    setShowCategoryList(prev => !prev);
  };

  return (
    <LinearGradient
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
      <StatusBar
        barStyle="light-content"
        backgroundColor={colors.blueLazuli}
      />

      <ScrollView contentContainerStyle={styles.scrollContent}>
        <Header />

        <View style={styles.form}>
          <Input
            placeholder="Pergunta"
            value={quest}
            onChangeText={setQuest}
            multiline
            numberOfLines={4}
          />
          <Input
            placeholder="Resposta"
            value={resp}
            onChangeText={setResp}
            multiline
            numberOfLines={4}
          />

          <View style={styleLocal.categoryRow}>
            <View style={styleLocal.categoryInputContainer}>
              <Input
                placeholder="Categoria"
                value={category}
                onChangeText={setCategory}
                editable={!showCategoryList}
              />
            </View>
            <View style={styleLocal.categoryButtonContainer}>
              <Button
                title="Usar categoria existênte"
                onPress={toggleShowCategories}
              />
            </View>
          </View>

          {showCategoryList && (
            <View style={styleLocal.categoryListContainer}>
              {availableCategories.map((cat) => (
                <View key={cat} style={styleLocal.radioItem}>
                  <ButtonCategory
                    title={category === cat ? `✓ ${cat}` : cat}
                    onPress={() => setCategory(cat)}
                  />
                </View>
              ))}
            </View>
          )}

          <Button
            title="Criar Flash Card"
            onPress={handleCreateCard}
          />
        </View>
      </ScrollView>
    </LinearGradient>
  );
}

const styleLocal = StyleSheet.create({
  categoryRow: {
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
    gap: 0,
  },

  categoryInputContainer: {
    flex: 1,
  },

  categoryButtonContainer: {
    flexShrink: 0,
  },

  categoryListContainer: {
    marginTop: 8,
    paddingVertical: 4,
    gap: 4,
  },

  radioItem: {
    width: "100%",
  },
});
