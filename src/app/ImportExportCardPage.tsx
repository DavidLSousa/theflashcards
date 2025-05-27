import { useState } from "react";
import { LinearGradient } from "expo-linear-gradient";
import { View } from "react-native";

import Header from "@/src/components/header";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles";
import { StatusBar } from "react-native";
import Button from "@/src/components/button";
import Input from "@/src/components/input";

export default function ImportExportCardPage() {
  const [importedCards, setImportedCards] = useState('');

  const copyCards = async () => {};

  const importCards = async () => {};

  return (
    <LinearGradient
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
      <StatusBar
        barStyle="light-content"
        backgroundColor={colors.blueLazuli}
      />

      <Header />

      <View style={styles.form}>

        <Input
          placeholder="Cole seus cards aqui"
          value={importedCards}
          onChangeText={setImportedCards}
          multiline
          numberOfLines={4}
        />

        <Button
          title="Importar Cards"
          onPress={importCards}
        />
      </View>

      <Button title="Copiar Cards" onPress={copyCards} />

    </LinearGradient>
  );
}