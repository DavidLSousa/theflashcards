import { LinearGradient } from "expo-linear-gradient";
import { useState } from "react";
import { TextInput, TouchableOpacity, View, Text, StyleSheet } from "react-native";

import { colors } from "@/src/constants/colors";
import Header from "@/src/components/header";
import Input from "@/src/components/input";
import Button from "@/src/components/button";

export default function NewCardPage() {
  const [quest, setQuest] = useState("");
  const [resp, setResp] = useState("");
  const [category, setCategory] = useState("");

  const handleCreateCard = () => {
    console.log("Novo card:", { category, quest, resp });
    
    // Logic

    setQuest("");
    setResp("");
  };

  return (
    <LinearGradient
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
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

    </LinearGradient>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingHorizontal: 20,
    paddingTop: 60,
  },
  form: {
    marginTop: 30,
    gap: 16,
  }
});
