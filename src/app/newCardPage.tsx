import { LinearGradient } from "expo-linear-gradient";
import { useState } from "react";
import { View, ScrollView, StatusBar } from "react-native";

import { colors } from "@/src/constants/colors";
import { styles } from "./styles";
import Header from "@/src/components/header";
import Input from "@/src/components/input";
import Button from "@/src/components/button";

import { useCard } from "@/src/hooks/useCard";

export default function NewCardPage() {
  const [quest, setQuest] = useState("");
  const [resp, setResp] = useState("");
  const [category, setCategory] = useState("");

  const handleCreateCard = () => {
    
    if (!quest.trim() || !resp.trim() || !category.trim()) {
      alert("Preencha todos os campos");
      return;
    }

    useCard.getState().addCard(quest, resp, category);

    setQuest("");
    setResp("");
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
          <Input
            placeholder="Categoria"
            value={category}
            onChangeText={setCategory}
          />

          <Button
            title="Criar Flash Card"
            onPress={handleCreateCard}
          />
        </View>
      </ScrollView>

    </LinearGradient>
  );
}