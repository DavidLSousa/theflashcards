import { useState } from "react";
import { LinearGradient } from "expo-linear-gradient";
import { View, StatusBar, Alert } from "react-native";

import Header from "@/src/components/header";
import Button from "@/src/components/button";
import Input from "@/src/components/input";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles";
import { useCard } from "@/src/hooks/useCard";

export default function ImportExportCardPage() {
  const [importedCards, setImportedCards] = useState('');
  const { copyCardsToClipboard, importNewCards } = useCard();

  const copyCards = async () => {
    await copyCardsToClipboard();
    
    Alert.alert('Tudo pronto...', 'Cards copiados!');
    // showModal('Cards copiados');
  };

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

      <Button 
        title="Copiar Cards" 
        onPress={copyCards} 
        />
    </LinearGradient>
  );
}