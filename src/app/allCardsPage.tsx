import { LinearGradient } from "expo-linear-gradient";
import { FlatList, StatusBar, View } from "react-native";
import { useEffect } from "react";
import { SafeAreaProvider, useSafeAreaInsets } from "react-native-safe-area-context";

import Card from "@/src/components/card";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles";
import { useCard } from "../hooks/useCard";

function AllCardsPageContent() {
  const { top } = useSafeAreaInsets(); // pega o padding superior seguro
  const { cards, fetchCards } = useCard();

  useEffect(() => {
    fetchCards();
  }, []);

  return (
    <LinearGradient
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={[styles.container, { paddingTop: top }]}
    >
      <StatusBar
        barStyle="light-content"
        backgroundColor={colors.blueLazuli}
      />

      <FlatList
        contentContainerStyle={styles.scrollContent}
        data={cards}
        keyExtractor={(item) => item.id}
        renderItem={({ item }) => <Card id={item.id} />}
      />
    </LinearGradient>
  );
}

export default function AllCardsPage() {
  return (
    <SafeAreaProvider>
      <AllCardsPageContent />
    </SafeAreaProvider>
  );
}
